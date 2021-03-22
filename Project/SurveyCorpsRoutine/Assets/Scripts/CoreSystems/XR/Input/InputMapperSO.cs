using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoreSystems.Input
{
    [CreateAssetMenu(fileName = "InputMapperSO", menuName = "Input/Mapper SO")]
    public abstract class InputMapperSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum> : ScriptableObject
        where boolEnum : Enum
        where floatEnum : Enum
        where vector2Enum : Enum
        where vector3Enum : Enum
        where quaternionEnum : Enum
    {
        [SerializeField] List<InputMapAndEnabledStatus> _InputMaps = new List<InputMapAndEnabledStatus>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action> _ActiveActionsWithGates
            = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action>();

        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction> _ProcessedBoolActions;
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction> _ProcessedFloatActions;
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action> _ProcessedVector2Actions;
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action> _ProcessedVector3Actions;
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction> _ProcessedQuaternionActions;

        private List<boolEnum> _ActivationGatesInputs = new List<boolEnum>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction> _MatchingBoolActions = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction> _MatchingFloatActions = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action> _MatchingVector2Actions = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action> _MatchingVector3Actions = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action>();
        private List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction> _MatchingQuaternionActions = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction>();


        private Dictionary<boolEnum, bool> _BoolInputs = new Dictionary<boolEnum, bool>();
        private Dictionary<floatEnum, float> _FloatInputs = new Dictionary<floatEnum, float>();
        private List<KeyValuePair<vector2Enum, Vector2>> _Vector2Inputs = new List<KeyValuePair<vector2Enum, Vector2>>();
        private List<KeyValuePair<vector3Enum, Vector3>> _Vector3Inputs = new List<KeyValuePair<vector3Enum, Vector3>>();
        private List<KeyValuePair<quaternionEnum, Quaternion>> _QuaternionInputs = new List<KeyValuePair<quaternionEnum, Quaternion>>();

        [System.Serializable]
        public class InputMapAndEnabledStatus
        {
            public InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum> map;
            public bool enabled;
        }
        protected abstract void CallBaseOnEnable();
        protected void OnEnable()
        {
            FillInputs();
            PopulateActivationGatesInputs();
        }
        private void OnDisable()
        {
            ClearInputs();
        }

        void ClearInputs()
        {
            _BoolInputs.Clear();
            _FloatInputs.Clear();
            _Vector2Inputs.Clear();
            _Vector3Inputs.Clear();
            _QuaternionInputs.Clear();
        }
        void FillInputs()
        {
            FillBoolInputs();
            FillFloatInputs();
            FillVector2Inputs();
            FillVector3Inputs();
            FillQuaternionInputs();
        }
        void FillBoolInputs()
        {
            Type boolEnumType = typeof(boolEnum);
            _BoolInputs = new Dictionary<boolEnum, bool>(10);
            foreach (var enumValue in Enum.GetValues(boolEnumType))
            {
                _BoolInputs.Add((boolEnum)enumValue, false);
            }
        }
        void FillFloatInputs()
        {
            Type boolEnumType = typeof(floatEnum);
            _FloatInputs = new Dictionary<floatEnum, float>(10);
            foreach (var enumValue in Enum.GetValues(boolEnumType))
            {
                _FloatInputs.Add((floatEnum)enumValue, 0);
            }
        }
        void FillVector2Inputs()
        {
            Type boolEnumType = typeof(vector2Enum);
            _Vector2Inputs = new List<KeyValuePair<vector2Enum, Vector2>>();
            foreach (var enumValue in Enum.GetValues(boolEnumType))
            {
                _Vector2Inputs.Add(new KeyValuePair<vector2Enum, Vector2>((vector2Enum)enumValue, new Vector2(0, 0)));
            }
        }
        void FillVector3Inputs()
        {
            Type boolEnumType = typeof(vector3Enum);
            _Vector3Inputs = new List<KeyValuePair<vector3Enum, Vector3>>();
            foreach (var enumValue in Enum.GetValues(boolEnumType))
            {
                _Vector3Inputs.Add(new KeyValuePair<vector3Enum, Vector3>((vector3Enum)enumValue, new Vector3(0, 0, 0)));
            }
        }
        void FillQuaternionInputs()
        {
            Type boolEnumType = typeof(quaternionEnum);
            _QuaternionInputs = new List<KeyValuePair<quaternionEnum, Quaternion>>();
            foreach (var enumValue in Enum.GetValues(boolEnumType))
            {
                _QuaternionInputs.Add(new KeyValuePair<quaternionEnum, Quaternion>((quaternionEnum)enumValue, Quaternion.identity));
            }
        }

        bool ActivationGatesValid(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action action)
        {
            List<boolEnum> ActivationGates;
            
            for (int i = 0; i < action.GetBindingsCount(); i++)
            {
                ActivationGates = action.GetActivationGates(i);
                bool foundValidGates = true;
                for (int j = 0; j < ActivationGates.Count; j++)
                {
                    if (!BoolInputIsPressed(ActivationGates[j]))
                    {
                        foundValidGates = false;
                    }
                }
                if (foundValidGates)
                {
                    action.SetPassedGatesIndx(i);
                    return true;
                }
            }
            return false;
        }
        void SetBoolAction(boolEnum inputTrigger, bool value)
        {
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction processedAction;
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedBoolActions = _InputMaps[i].map.GetBoolActions();
                    for (int j = 0; j < _ProcessedBoolActions.Count; j++)
                    {
                        processedAction = _ProcessedBoolActions[j];
                        //check if action button matches pressed button or if action butoon is set to any
                        if (processedAction.IsBindedToInput(inputTrigger))
                        {
                            processedAction.Set(value);
                        }
                    }
                }
            }
        }
        bool BoolInputIsPressed(boolEnum xRInputTriggerBool)
        {
            bool value;
            if (_BoolInputs.TryGetValue(xRInputTriggerBool, out value))
            {
                return value;
            }
            else
            {
                Debug.LogError("In " + this + " " + xRInputTriggerBool + " was not added to the BoolInputs dict");
                return false;
            }
        }
        void PopulateActivationGatesInputs()
        {
            _ActivationGatesInputs.Clear();
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ActivationGatesInputs.AddRange(_InputMaps[i].map.GetBoolActionGatesTriggers());
                }
            }
            _ActivationGatesInputs = _ActivationGatesInputs.Distinct().ToList();
        }
        //returns true if returned is only one action with activation gates
        bool PopulateMatchingBoolActions(boolEnum inputTrigger)
        {
            _MatchingBoolActions.Clear();
            bool isAnyActionWithGates = false;
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction processedAction;
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedBoolActions = _InputMaps[i].map.GetBoolActions();
                    for (int j = 0; j < _ProcessedBoolActions.Count; j++)
                    {
                        processedAction = _ProcessedBoolActions[j];
                        //check if action button matches pressed button
                        if (processedAction.IsBindedToInput(inputTrigger))
                        {
                            if (processedAction.HasActivationGates() && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingBoolActions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingBoolActions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (!processedAction.HasActivationGates())
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingBoolActions.Add(processedAction);
                                }
                            }
                        }
                    }
                }
            }
            return isAnyActionWithGates;
        }
        bool PopulateMatchingFloatActions(floatEnum inputTrigger)
        {
            _MatchingFloatActions.Clear();
            bool isAnyActionWithGates = false;
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction processedAction;
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedFloatActions = _InputMaps[i].map.GetFloatActions();
                    for (int j = 0; j < _ProcessedFloatActions.Count; j++)
                    {
                        processedAction = _ProcessedFloatActions[j];
                        //check if action button matches pressed button 
                        if (processedAction.IsBindedToInput(inputTrigger))
                        {
                            if (processedAction.HasActivationGates() && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingFloatActions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingFloatActions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (!processedAction.HasActivationGates())
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingFloatActions.Add(processedAction);
                                }
                            }
                        }
                    }
                }
            }
            return isAnyActionWithGates;
        }

        bool PopulateMatchingVector2Actions(vector2Enum inputTrigger)
        {
            _MatchingVector2Actions.Clear();
            bool isAnyActionWithGates = false;
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action processedAction;
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedVector2Actions = _InputMaps[i].map.GetVector2Actions();
                    for (int j = 0; j < _ProcessedVector2Actions.Count; j++)
                    {
                        processedAction = _ProcessedVector2Actions[j];
                        //check if action button matches pressed button 
                        if (processedAction.IsBindedToInput(inputTrigger))
                        {
                            if (processedAction.HasActivationGates() && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingVector2Actions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingVector2Actions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (!processedAction.HasActivationGates())
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingVector2Actions.Add(processedAction);
                                }
                            }
                        }
                    }
                }
            }
            return isAnyActionWithGates;
        }

        bool PopulateMatchingVector3Actions(vector3Enum inputTrigger)
        {
            _MatchingVector3Actions.Clear();
            bool isAnyActionWithGates = false;
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action processedAction;
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedVector3Actions = _InputMaps[i].map.GetVector3Actions();
                    for (int j = 0; j < _ProcessedVector3Actions.Count; j++)
                    {
                        processedAction = _ProcessedVector3Actions[j];
                        //check if action button matches pressed button
                        if (processedAction.IsBindedToInput(inputTrigger))
                        {
                            if (processedAction.HasActivationGates() && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingVector3Actions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingVector3Actions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (!processedAction.HasActivationGates())
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingVector3Actions.Add(processedAction);
                                }
                            }
                        }
                    }
                }
            }
            return isAnyActionWithGates;
        }
        bool PopulateMatchingQuaternionActions(quaternionEnum inputTrigger)
        {
            _MatchingQuaternionActions.Clear();
            bool isAnyActionWithGates = false;
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction processedAction;
            //check every enabled input map
            for (int i = 0; i < _InputMaps.Count; i++)
            {
                if (_InputMaps[i].enabled)
                {
                    _ProcessedQuaternionActions = _InputMaps[i].map.GetQuaternionActions();
                    for (int j = 0; j < _ProcessedQuaternionActions.Count; j++)
                    {
                        processedAction = _ProcessedQuaternionActions[j];
                        //check if action button matches pressed button 
                        if (processedAction.IsBindedToInput(inputTrigger) )
                        {
                            if (processedAction.HasActivationGates() && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingQuaternionActions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingQuaternionActions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (!processedAction.HasActivationGates())
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingQuaternionActions.Add(processedAction);
                                }
                            }
                        }
                    }
                }
            }
            return isAnyActionWithGates;
        }
        void DisableNotValidActionsWithGates()
        {
            InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action actionWithGates;
            List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action> ActiveActionsWithGatesCopy = new List<InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action>(_ActiveActionsWithGates);
            for (int i = 0; i < ActiveActionsWithGatesCopy.Count; i++)
            {
                actionWithGates = ActiveActionsWithGatesCopy[i];
                //if action gates are not longer valid
                if (!ActivationGatesValid(actionWithGates))
                {
                    //disable action
                    actionWithGates.SetValueDisabled();
                    //remove action from active actions with gates
                    _ActiveActionsWithGates.Remove(actionWithGates);
                }
            }
        }
        IEnumerable<T> ProcessActionsWithGates<T>(InputActionPhase phase) where T : InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Action
        {
            T actionWithGates;
            List<T> _MatchingActions;
            if (typeof(T) == typeof(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction))
            {
                _MatchingActions = _MatchingBoolActions as List<T>;
            }
            else if (typeof(T) == typeof(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction))
            {
                _MatchingActions = _MatchingFloatActions as List<T>;
            }
            else if (typeof(T) == typeof(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action))
            {
                _MatchingActions = _MatchingVector2Actions as List<T>;
            }
            else if (typeof(T) == typeof(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action))
            {
                _MatchingActions = _MatchingVector3Actions as List<T>;
            }
            else if (typeof(T) == typeof(InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction))
            {
                _MatchingActions = _MatchingQuaternionActions as List<T>;
            }
            else
            {
                _MatchingActions = new List<T>();
            }
            if (phase == InputActionPhase.Started)
            {
                for (int i = 0; i < _MatchingActions.Count; i++)
                {
                    actionWithGates = _MatchingActions[i];
                    List<boolEnum> ActivationGates = actionWithGates.GetActivationGates(actionWithGates.GetPassedGatesIndx());
                    for (int j = 0; j < ActivationGates.Count; j++)
                    {
                        //disable actions binded to the same inputTriggers as activation gates
                        SetBoolAction(ActivationGates[j], false);
                    }
                    _ActiveActionsWithGates.Add(actionWithGates);
                    yield return actionWithGates as T;
                    //return value
                }
            }
            //if returnedActionsWithGates and phase == canceled
            else
            {
                for (int i = 0; i < _MatchingActions.Count; i++)
                {
                    actionWithGates = _MatchingActions[i];
                    _ActiveActionsWithGates.Remove(actionWithGates);
                    yield return actionWithGates as T;

                    List<boolEnum> ActivationGates = actionWithGates.GetActivationGates(actionWithGates.GetPassedGatesIndx());
                    for (int j = 0; j < ActivationGates.Count; j++)
                    {
                        //enable actions binded to the inputs same as activation gates of current actionWithGates
                        BoolInputTriggered(ActivationGates[j], InputActionPhase.Started);
                    }
                    
                }
            }
        }
        public void BoolInputTriggered(boolEnum inputTrigger, InputActionPhase phase = InputActionPhase.Started)
        {
            if (phase == InputActionPhase.Started)
            {
                _BoolInputs[inputTrigger] = true;
            }
            else
            {
                _BoolInputs[inputTrigger] = false;
            }
            bool returnedActionsWithGates = PopulateMatchingBoolActions(inputTrigger);
            //if realeased input was potentialy a part of the gates for other action
            if (phase != InputActionPhase.Started && _ActivationGatesInputs.Contains(inputTrigger))
            {
                DisableNotValidActionsWithGates();
            }
            if (returnedActionsWithGates)
            {
                foreach (var boolAction in ProcessActionsWithGates
                    <InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.BoolAction>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        boolAction.Set(true);
                    }
                    else
                    {
                        boolAction.SetValueDisabled();
                    }
                }
            }
            else
            {
                if (phase == InputActionPhase.Started)
                {
                    for (int i = 0; i < _MatchingBoolActions.Count; i++)
                    {
                        _MatchingBoolActions[i].Set(true);
                    }
                }
                else
                {
                    for (int i = 0; i < _MatchingBoolActions.Count; i++)
                    {
                        _MatchingBoolActions[i].SetValueDisabled();
                    }
                }
            }


        }
        public void FloatInputTriggered(floatEnum inputTrigger, float value, InputActionPhase phase = InputActionPhase.Started)
        {

            if (phase == InputActionPhase.Started)
            {
                _FloatInputs[inputTrigger] = value;
            }
            else
            {
                _FloatInputs[inputTrigger] = 0;
            }
            bool returnedActionsWithGates = PopulateMatchingFloatActions(inputTrigger);

            if (returnedActionsWithGates)
            {
                foreach (var floatAction in ProcessActionsWithGates
                    <InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.FloatAction>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        floatAction.Set(value);
                    }
                    else
                    {
                        floatAction.SetValueDisabled();
                    }
                }
            }
            else
            {
                if (phase == InputActionPhase.Started)
                {
                    for (int i = 0; i < _MatchingFloatActions.Count; i++)
                    {
                        _MatchingFloatActions[i].Set(value);
                    }
                }
                else
                {
                    for (int i = 0; i < _MatchingFloatActions.Count; i++)
                    {
                        _MatchingFloatActions[i].SetValueDisabled();
                    }
                }
            }
        }
        public void Vector2InputTriggered(vector2Enum inputTrigger, Vector2 value, InputActionPhase phase = InputActionPhase.Started)
        {
            //using list instead of dictionary because, let's be honest, in the game will be not a lot of Vector2 inputs
            for (int i = 0; i < _Vector2Inputs.Count; i++)
            {
                if (_Vector2Inputs[i].Key.Equals(inputTrigger))
                {
                    _Vector2Inputs[i] = new KeyValuePair<vector2Enum, Vector2>(inputTrigger, value);
                    break;
                }
            }
            bool returnedActionsWithGates = PopulateMatchingVector2Actions(inputTrigger);

            if (returnedActionsWithGates)
            {
                foreach (var vector2Action in ProcessActionsWithGates
                    <InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector2Action>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        vector2Action.Set(value);
                    }
                    else
                    {
                        vector2Action.SetValueDisabled();
                    }
                }
            }
            else
            {
                if (phase == InputActionPhase.Started)
                {
                    for (int i = 0; i < _MatchingVector2Actions.Count; i++)
                    {
                        _MatchingVector2Actions[i].Set(value);
                    }
                }
                else
                {
                    for (int i = 0; i < _MatchingVector2Actions.Count; i++)
                    {
                        _MatchingVector2Actions[i].SetValueDisabled();
                    }
                }
            }
        }
        public void Vector3InputTriggered(vector3Enum inputTrigger, Vector3 value, InputActionPhase phase = InputActionPhase.Started)
        {
            //using list instead of dictionary because, let's be honest, in the game will be not a lot of Vector3 inputs
            for (int i = 0; i < _Vector3Inputs.Count; i++)
            {
                if (_Vector3Inputs[i].Key.Equals(inputTrigger))
                {
                    _Vector3Inputs[i] = new KeyValuePair<vector3Enum, Vector3>(inputTrigger, value);
                    break;
                }
            }
            bool returnedActionsWithGates = PopulateMatchingVector3Actions(inputTrigger);

            if (returnedActionsWithGates)
            {
                foreach (var vector3Action in ProcessActionsWithGates
                    <InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.Vector3Action>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        vector3Action.Set(value);
                    }
                    else
                    {
                        vector3Action.SetValueDisabled();
                    }
                }
            }
            else
            {
                if (phase == InputActionPhase.Started)
                {
                    for (int i = 0; i < _MatchingVector3Actions.Count; i++)
                    {
                        _MatchingVector3Actions[i].Set(value);
                    }
                }
                else
                {
                    for (int i = 0; i < _MatchingVector3Actions.Count; i++)
                    {
                        _MatchingVector3Actions[i].SetValueDisabled();
                    }
                }
            }
        }
        public void QuaternionInputTriggered(quaternionEnum inputTrigger, Quaternion value, InputActionPhase phase = InputActionPhase.Started)
        {
            //using list instead of dictionary because, let's be honest, in the game will be not a lot of Quaternion inputs
            for (int i = 0; i < _QuaternionInputs.Count; i++)
            {
                if (_QuaternionInputs[i].Key.Equals(inputTrigger))
                {
                    _QuaternionInputs[i] = new KeyValuePair<quaternionEnum, Quaternion>(inputTrigger, value);
                    break;
                }
            }
            bool returnedActionsWithGates = PopulateMatchingQuaternionActions(inputTrigger);

            if (returnedActionsWithGates)
            {
                foreach (var quaternionAction in ProcessActionsWithGates
                    <InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum>.QuaternionAction>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        quaternionAction.Set(value);
                    }
                    else
                    {
                        quaternionAction.SetValueDisabled();
                    }
                }
            }
            else
            {
                if (phase == InputActionPhase.Started)
                {
                    for (int i = 0; i < _MatchingQuaternionActions.Count; i++)
                    {
                        _MatchingQuaternionActions[i].Set(value);
                    }
                }
                else
                {
                    for (int i = 0; i < _MatchingQuaternionActions.Count; i++)
                    {
                        _MatchingQuaternionActions[i].SetValueDisabled();
                    }
                }
            }
        }



    }
}
