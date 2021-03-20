using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static CoreSystems.XR.Input.XRInputMap<
    CoreSystems.XR.Input.XRInputTriggerBool,
    CoreSystems.XR.Input.XRInputTriggerFloat,
    CoreSystems.XR.Input.XRInputTriggerVector2,
    CoreSystems.XR.Input.XRInputTriggerVector3,
    CoreSystems.XR.Input.XRInputTriggerQuaternion>;

namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMapperSO", menuName = "XR/Input/Mapper SO")]
    public class XRInputMapperSO : ScriptableObject
    {
        [SerializeField] XRInputEventsSO _inputEventsSO;
        [SerializeField] List<InputMapEnabledStatus> _InputMaps = new List<InputMapEnabledStatus>();

        public float floatActivationThreashold = 0.01f;

        private List<MappedInput> _ActiveActionsWithGates = new List<MappedInput>();

        private List<MappedInputBool> _ProcessedBoolActions;
        private List<MappedInputFloat> _ProcessedFloatActions;
        private List<MappedInputVector2> _ProcessedVector2Actions;
        private List<MappedInputVector3> _ProcessedVector3Actions;
        private List<MappedInputQuaternion> _ProcessedQuaternionActions;

        private List<int> _ActivationGatesInputs;
        private List<MappedInputBool> _MatchingBoolActions = new List<MappedInputBool>();
        private List<MappedInputFloat> _MatchingFloatActions = new List<MappedInputFloat>();
        private List<MappedInputVector2> _MatchingVector2Actions = new List<MappedInputVector2>();
        private List<MappedInputVector3> _MatchingVector3Actions = new List<MappedInputVector3>();
        private List<MappedInputQuaternion> _MatchingQuaternionActions = new List<MappedInputQuaternion>();


        private Dictionary<int, bool> BoolInputs = new Dictionary<int, bool>
        {
            { (int)XRInputTriggerBool.any,  false},
            { (int)XRInputTriggerBool.leftPrimaryButton,  false},
            { (int)XRInputTriggerBool.leftSecondaryButton,  false},
            { (int)XRInputTriggerBool.leftGripButton,  false},
            { (int)XRInputTriggerBool.leftTriggerButton,  false},
            { (int)XRInputTriggerBool.leftJoystickClick,  false},
            { (int)XRInputTriggerBool.leftJoystickUp,  false},
            { (int)XRInputTriggerBool.leftJoystickDown,  false},
            { (int)XRInputTriggerBool.leftJoystickRight,  false},
            { (int)XRInputTriggerBool.leftJoystickLeft,  false},
            { (int)XRInputTriggerBool.leftPrimaryButtonRelease,  false},
            { (int)XRInputTriggerBool.leftSecondaryButtonRelease,  false},
            { (int)XRInputTriggerBool.leftGripRelease,  false},
            { (int)XRInputTriggerBool.leftTriggerRelease,  false},
            { (int)XRInputTriggerBool.leftJoystickClickRelease,  false},
            { (int)XRInputTriggerBool.leftJoystickUpRelease,  false},
            { (int)XRInputTriggerBool.leftJoystickDownRelease,  false},
            { (int)XRInputTriggerBool.leftJoystickRightRelease,  false},
            { (int)XRInputTriggerBool.leftJoystickLeftRelease,  false},

            { (int)XRInputTriggerBool.rightPrimaryButton,  false},
            { (int)XRInputTriggerBool.rightSecondaryButton,  false},
            { (int)XRInputTriggerBool.rightGripButton,  false},
            { (int)XRInputTriggerBool.rightTriggerButton,  false},
            { (int)XRInputTriggerBool.rightJoystickClick,  false},
            { (int)XRInputTriggerBool.rightJoystickUp,  false},
            { (int)XRInputTriggerBool.rightJoystickDown,  false},
            { (int)XRInputTriggerBool.rightJoystickRight,  false},
            { (int)XRInputTriggerBool.rightJoystickLeft,  false},
            { (int)XRInputTriggerBool.rightPrimaryButtonRelease,  false},
            { (int)XRInputTriggerBool.rightSecondaryButtonRelease,  false},
            { (int)XRInputTriggerBool.rightGripRelease,  false},
            { (int)XRInputTriggerBool.rightTriggerRelease,  false},
            { (int)XRInputTriggerBool.rightJoystickClickRelease,  false},
            { (int)XRInputTriggerBool.rightJoystickUpRelease,  false},
            { (int)XRInputTriggerBool.rightJoystickDownRelease,  false},
            { (int)XRInputTriggerBool.rightJoystickRightRelease,  false},
            { (int)XRInputTriggerBool.rightJoystickLeftRelease,  false},

        };
        private Dictionary<XRInputTriggerFloat, float> FloatInputs = new Dictionary<XRInputTriggerFloat, float>(){
            { XRInputTriggerFloat.leftGrip,  0},
            { XRInputTriggerFloat.leftTrigger,  0},
            { XRInputTriggerFloat.rightGrip,  0},
            { XRInputTriggerFloat.rightTrigger,  0},
        };
        private List<KeyValuePair<XRInputTriggerVector2, Vector2>> Vector2Inputs = new List<KeyValuePair<XRInputTriggerVector2, Vector2>>()
        {
            new KeyValuePair<XRInputTriggerVector2, Vector2>(XRInputTriggerVector2.leftJoystick, Vector2.zero),
            new KeyValuePair<XRInputTriggerVector2, Vector2>(XRInputTriggerVector2.rightJoystick, Vector2.zero),
        };
        private List<KeyValuePair<XRInputTriggerVector3, Vector3>> Vector3Inputs = new List<KeyValuePair<XRInputTriggerVector3, Vector3>>()
        {
            new KeyValuePair<XRInputTriggerVector3, Vector3>(XRInputTriggerVector3.headPos, Vector2.zero),
            new KeyValuePair<XRInputTriggerVector3, Vector3>(XRInputTriggerVector3.rightHandPos, Vector2.zero),
            new KeyValuePair<XRInputTriggerVector3, Vector3>(XRInputTriggerVector3.leftHandPos, Vector2.zero),

        };
        private List<KeyValuePair<XRInputTriggerQuaternion, Quaternion>> QuaternionInputs = new List<KeyValuePair<XRInputTriggerQuaternion, Quaternion>>()
        {
            new KeyValuePair<XRInputTriggerQuaternion, Quaternion>(XRInputTriggerQuaternion.headRot, Quaternion.identity),
            new KeyValuePair<XRInputTriggerQuaternion, Quaternion>(XRInputTriggerQuaternion.rightHandRot, Quaternion.identity),
            new KeyValuePair<XRInputTriggerQuaternion, Quaternion>(XRInputTriggerQuaternion.leftHandRot, Quaternion.identity),

        };

        [System.Serializable]
        public class InputMapEnabledStatus
        {
            public XRInputMap<
                XRInputTriggerBool,
                XRInputTriggerFloat,
                XRInputTriggerVector2,
                XRInputTriggerVector3,
                XRInputTriggerQuaternion> 
                map;
            public bool enabled;
        }

        private void OnEnable()
        {
            BindActions();
            InputSystem.onAfterUpdate += OnAfterUpdate;
            PopulateActivationGatesInputs();
        }
        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= OnAfterUpdate;
            UnbindActions();

        }

        void FillInputs()
        {
            
        }
        void FillBoolInputs()
        {
           
        }
        void OnAfterUpdate()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                ResetRealeaseButtons();

        }

        /// <summary>
        /// Resets all values for actions triggered by inputTriggers release
        /// </summary>
        void ResetRealeaseButtons()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftPrimaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftSecondaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftGripRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftTriggerRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickClickRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUpRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDownRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRightRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeftRelease, InputActionPhase.Canceled);

            BoolInputTriggered((int)XRInputTriggerBool.rightPrimaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightSecondaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightGripRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightTriggerRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickClickRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUpRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDownRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRightRelease, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeftRelease, InputActionPhase.Canceled);
        }
        void BindActions()
        {
            _inputEventsSO.onHeadPosition += OnHeadPosition;
            _inputEventsSO.onHeadRotation += OnHeadRotation;

            _inputEventsSO.onLeftPosition += OnLeftPosition;
            _inputEventsSO.onLeftRotation += OnLeftRotation;
            _inputEventsSO.onLeftPrimaryAxis += OnLeftJoystick;
            _inputEventsSO.onLeftGripButton += OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased += OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton += OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased += OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftPrimaryAxisClick += OnLeftJoystickClicked;
            _inputEventsSO.onLeftPrimaryAxisClickReleased += OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton += OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased += OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton += OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased += OnLeftSecondaryButtonReleased;
            _inputEventsSO.onLeftGrip += OnLeftGrip;
            _inputEventsSO.onLeftTrigger += OnLeftTrigger;


            _inputEventsSO.onRightPosition += OnRightPosition;
            _inputEventsSO.onRightRotation += OnRightRotation;
            _inputEventsSO.onRightPrimaryAxis += OnRightJoystick;
            _inputEventsSO.onRightGripButton += OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased += OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton += OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased += OnRightTriggerButtonReleased;
            _inputEventsSO.onRightPrimaryAxisClick += OnRightJoystickClicked;
            _inputEventsSO.onRightPrimaryAxisClickReleased += OnRightJoystickReleased;
            _inputEventsSO.onRightPrimaryButton += OnRightPrimaryButton;
            _inputEventsSO.onRightPrimaryButtonReleased += OnRightPrimaryButtonReleased;
            _inputEventsSO.onRightSecondaryButton += OnRightSecondaryButton;
            _inputEventsSO.onRightSecondaryButtonReleased += OnRightSecondaryButtonReleased;
            _inputEventsSO.onRightGrip += OnRightGrip;
            _inputEventsSO.onRightTrigger += OnRightTrigger;
        }
        void UnbindActions()
        {
            _inputEventsSO.onHeadPosition -= OnHeadPosition;
            _inputEventsSO.onHeadRotation -= OnHeadRotation;

            _inputEventsSO.onLeftPosition -= OnLeftPosition;
            _inputEventsSO.onLeftRotation -= OnLeftRotation;
            _inputEventsSO.onLeftPrimaryAxis -= OnLeftJoystick;
            _inputEventsSO.onLeftGripButton -= OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased -= OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton -= OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased -= OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftPrimaryAxisClick -= OnLeftJoystickClicked;
            _inputEventsSO.onLeftPrimaryAxisClickReleased -= OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton -= OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased -= OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton -= OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased -= OnLeftSecondaryButtonReleased;

            _inputEventsSO.onLeftPosition -= OnRightPosition;
            _inputEventsSO.onLeftRotation -= OnRightRotation;
            _inputEventsSO.onRightPrimaryAxis -= OnRightJoystick;
            _inputEventsSO.onRightGripButton -= OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased -= OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton -= OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased -= OnRightTriggerButtonReleased;
            _inputEventsSO.onRightPrimaryAxisClick -= OnRightJoystickClicked;
            _inputEventsSO.onRightPrimaryAxisClickReleased -= OnRightJoystickReleased;
            _inputEventsSO.onRightPrimaryButton -= OnRightPrimaryButton;
            _inputEventsSO.onRightPrimaryButtonReleased -= OnRightPrimaryButtonReleased;
            _inputEventsSO.onRightSecondaryButton -= OnRightSecondaryButton;
            _inputEventsSO.onRightSecondaryButtonReleased -= OnRightSecondaryButtonReleased;
        }

        /*Type GetInputTriggerType(XRInputTrigger inputTrigger)
        {
            //if inputTrigger input is a bool value
            if (inputTrigger >= XRInputTrigger.any && inputTrigger < XRInputTrigger.leftGrip)
            {
                return typeof(bool);
            }
            //if inputTrigger input is a float value
            else if (inputTrigger >= XRInputTrigger.leftGrip && inputTrigger < XRInputTrigger.leftJoystick)
            {
                return typeof(float);
            }
            //if inputTrigger input is a vector2 value
            else if (inputTrigger >= XRInputTrigger.leftJoystick && inputTrigger < XRInputTrigger.headPos)
            {
                return typeof(UnityEngine.Vector2);
            }
            //if inputTrigger input is a vector3 value
            else if (inputTrigger >= XRInputTrigger.headPos && inputTrigger < XRInputTrigger.headRot)
            {
                return typeof(UnityEngine.Vector3);
            }
            //if inputTrigger input is a quaternion value
            else if (inputTrigger >= XRInputTrigger.headRot && inputTrigger < XRInputTrigger.rightHandRot)
            {
                return typeof(UnityEngine.Quaternion);
            }
            else
            {
                Debug.LogError("In " + this + " input type is not recognized");
                return null;
            }
        }*/

        bool ActivationGatesValid(MappedInput mappedInput)
        {
            for (int i = 0; i < mappedInput.activationGates.Count; i++)
            {
                int inputTrigger = (int)mappedInput.activationGates[i];
                //if any of action activation inputTriggers is not pressed - return value indicating that input cannot be activated
                if (!BoolInputIsPressed(inputTrigger))
                {
                    return false;
                }
            }
            return true;
        }
        void SetBoolAction(XRInputTriggerBool inputTrigger, bool value)
        {
            MappedInputBool processedAction;
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedBoolActions = _InputMaps[j].map.GetBoolActions();
                    for (int i = 0; i < _ProcessedBoolActions.Count; i++)
                    {
                        processedAction = _ProcessedBoolActions[i];
                        //check if action button matches pressed button or if action butoon is set to any
                        if (processedAction.inputTrigger == inputTrigger)
                        {
                            processedAction.Set(value);
                        }
                    }
                }
            }
        }
        /* void InputTriggered<T>(XRInputTrigger inputTrigger, T value, InputActionPhase phase = InputActionPhase.Started)
         {
             XRInputMap _processedInputMap;
             MappedInput mappedInput;
             List<MappedInput> CurrentMappedInputs;
             Type inputType = typeof(T);
             for (int j = 0; j < _InputMaps.Count; j++)
             {
                 if (_InputMaps[j].enabled)
                 {
                     _processedInputMap = _InputMaps[j].map;
                     if (inputType == typeof(bool))
                     {
                         CurrentMappedInputs = _processedInputMap.GetBoolInputs();
                     }
                     else if (inputType == typeof(float))
                     {
                         CurrentMappedInputs = _processedInputMap.GetFloatInputs();
                     }
                     else if (inputType == typeof(Vector2))
                     {
                         CurrentMappedInputs = _processedInputMap.GetVector2Inputs();
                     }
                     else if (inputType == typeof(Vector3))
                     {
                         CurrentMappedInputs = _processedInputMap.GetVector3Inputs();
                     }
                     else if (inputType == typeof(Quaternion))
                     {
                         CurrentMappedInputs = _processedInputMap.GetQuaternionInputs();
                     }
                     else
                     {
                         Debug.LogError("Incorrect type");
                         return;

                     }

                     for (int i = 0; i < CurrentMappedInputs.Count; i++)
                     {
                         mappedInput = CurrentMappedInputs[i];
                         if (mappedInput.button == inputTrigger)
                         {
                             if (phase == InputActionPhase.Started)
                             {
                                 mappedInput.setBool(true);
                             }
                             else
                             {
                                 mappedInput.setBool(false);
                             }
                             return;
                         }
                     }
                 }
             }
         }*/
        /*bool CheckIfInputIsPressed(XRInputTrigger inputTrigger)
        {
            Type inputButtonValueType = GetInputTriggerType(inputTrigger);
            if (inputButtonValueType == typeof(bool))
            {
                bool value;
                if (BoolInputs.TryGetValue(inputTrigger, out value))
                {
                    return value;
                }
                else
                {
                    Debug.LogError("In " + this + " " + inputTrigger + " was not added to the BoolInputs dict");
                    return false;
                }

            }

            else if (inputButtonValueType == typeof(float))
            {
                float value;
                if (FloatInputs.TryGetValue(inputTrigger, out value))
                {
                    if (value > floatActivationThreashold)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Debug.LogError("In " + this + " " + inputTrigger + " was not added to the FloatInputs dict");
                    return false;
                }
            }

            else if (inputButtonValueType == typeof(UnityEngine.Vector2))
            {
                Vector2 value;
                for (int i = 0; i < Vector2Inputs.Count; i++)
                {
                    if (Vector2Inputs[i].Key == inputTrigger)
                    {
                        value = Vector2Inputs[i].Value;
                        if (value.magnitude >= floatActivationThreashold)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                Debug.LogError("In " + this + " " + inputTrigger + " was not added to the Vector2Inputs list");
                return false;
            }

            else if (inputButtonValueType == typeof(UnityEngine.Vector3))
            {
                Vector3 value;
                for (int i = 0; i < Vector3Inputs.Count; i++)
                {
                    if (Vector3Inputs[i].Key == inputTrigger)
                    {
                        value = Vector3Inputs[i].Value;
                        if (value.magnitude >= floatActivationThreashold)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                Debug.LogError("In " + this + " " + inputTrigger + " was not added to the Vector3Inputs list");
                return false;
            }

            else if (inputButtonValueType == typeof(UnityEngine.Quaternion))
            {
                Quaternion value;
                for (int i = 0; i < QuaternionInputs.Count; i++)
                {
                    if (QuaternionInputs[i].Key == inputTrigger)
                    {
                        value = QuaternionInputs[i].Value;
                        if (value.eulerAngles.magnitude >= floatActivationThreashold)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                Debug.LogError("In " + this + " " + inputTrigger + " was not added to the QuaternionInputs list");
                return false;
            }
            else
            {
                Debug.LogError("In " + this + " " + inputTrigger + " type is not regognized as any of predefined types, check and change"
                    + inputTrigger + " position in the XRInputButton enum file.");
                return false;
            }
        }*/
        bool BoolInputIsPressed(int xRInputTriggerBool)
        {
            bool value;
            if (BoolInputs.TryGetValue(xRInputTriggerBool, out value))
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
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ActivationGatesInputs.AddRange(_InputMaps[j].map.GetBoolActionGatesTriggers());
                }
            }
            _ActivationGatesInputs = _ActivationGatesInputs.Distinct().ToList();
        }
        //returns true if returned is only one action with activation gates
        bool PopulateMatchingBoolActions(int inputTrigger)
        {
            _MatchingBoolActions.Clear();
            bool isAnyActionWithGates = false;
            MappedInputBool processedAction;
            //check every enabled input map
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedBoolActions = _InputMaps[j].map.GetBoolActions();
                    for (int i = 0; i < _ProcessedBoolActions.Count; i++)
                    {
                        processedAction = _ProcessedBoolActions[i];
                        //check if action button matches pressed button or if action butoon is set to any
                        if ((int)processedAction.inputTrigger == inputTrigger || processedAction.inputTrigger == 0)
                        {
                            if (processedAction.activationGates.Count != 0 && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingBoolActions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingBoolActions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (processedAction.activationGates.Count == 0)
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
        bool PopulateMatchingFloatActions(XRInputTriggerFloat inputTrigger)
        {
            _MatchingFloatActions.Clear();
            bool isAnyActionWithGates = false;
            MappedInputFloat processedAction;
            //check every enabled input map
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedFloatActions = _InputMaps[j].map.GetFloatActions();
                    for (int i = 0; i < _ProcessedFloatActions.Count; i++)
                    {
                        processedAction = _ProcessedFloatActions[i];
                        //check if action button matches pressed button or if action butoon is set to any
                        if (processedAction.inputTrigger == inputTrigger || processedAction.inputTrigger == 0)
                        {
                            if (processedAction.activationGates.Count != 0 && ActivationGatesValid(processedAction))
                            {
                                if (!isAnyActionWithGates)
                                {
                                    _MatchingFloatActions.Clear();
                                    isAnyActionWithGates = true;
                                }
                                _MatchingFloatActions.Add(processedAction);
                            }
                            //if action has no activation gates - set as action to activate
                            else if (processedAction.activationGates.Count == 0)
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

        void PopulateMatchingVector2Actions(XRInputTriggerVector2 inputTrigger)
        {
            _MatchingVector2Actions.Clear();
            MappedInputVector2 processedAction;
            //check every enabled input map
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedVector2Actions = _InputMaps[j].map.GetVector2Actions();
                    for (int i = 0; i < _ProcessedVector2Actions.Count; i++)
                    {
                        processedAction = _ProcessedVector2Actions[i];
                        //check if action button matches pressed button
                        if (processedAction.inputTrigger == inputTrigger || processedAction.inputTrigger == 0)
                        {
                            if (processedAction.activationGates.Count != 0)
                            {
                                //if activation gates are valid - set as action to activate only 
                                //this action with activation gates.
                                //ex. jump = primaryButton, shoot = trigger + primaryButton. If trigger and primary button
                                //was pressed - activate only shoot action and ignore jump action
                                if (ActivationGatesValid(processedAction))
                                {
                                    _MatchingVector2Actions.Clear();
                                    _MatchingVector2Actions.Add(processedAction);
                                    return;
                                }
                            }
                            //if action has no activation gates - set as action to activate
                            else
                            {
                                _MatchingVector2Actions.Add(processedAction);
                            }
                        }
                    }
                }
            }
        }

        void PopulateMatchingVector3Actions(XRInputTriggerVector3 inputTrigger)
        {
            _MatchingVector3Actions.Clear();
            MappedInputVector3 processedAction;
            //check every enabled input map
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedVector3Actions = _InputMaps[j].map.GetVector3Actions();
                    for (int i = 0; i < _ProcessedVector3Actions.Count; i++)
                    {
                        processedAction = _ProcessedVector3Actions[i];
                        //check if action button matches pressed button
                        if (processedAction.inputTrigger == inputTrigger || processedAction.inputTrigger == 0)
                        {
                            if (processedAction.activationGates.Count != 0)
                            {
                                //if activation gates are valid - set as action to activate only 
                                //this action with activation gates.
                                //ex. jump = primaryButton, shoot = trigger + primaryButton. If trigger and primary button
                                //was pressed - activate only shoot action and ignore jump action
                                if (ActivationGatesValid(processedAction))
                                {
                                    _MatchingVector3Actions.Clear();
                                    _MatchingVector3Actions.Add(processedAction);
                                    return;
                                }
                            }
                            //if action has no activation gates - set as action to activate
                            else
                            {
                                _MatchingVector3Actions.Add(processedAction);
                            }
                        }
                    }
                }
            }
        }
        void PopulateMatchingQuaternionActions(XRInputTriggerQuaternion inputTrigger)
        {
            _MatchingQuaternionActions.Clear();
            MappedInputQuaternion processedAction;
            //check every enabled input map
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _ProcessedQuaternionActions = _InputMaps[j].map.GetQuaternionActions();
                    for (int i = 0; i < _ProcessedQuaternionActions.Count; i++)
                    {
                        processedAction = _ProcessedQuaternionActions[i];
                        //check if action button matches pressed button
                        if (processedAction.inputTrigger == inputTrigger || processedAction.inputTrigger == 0)
                        {
                            if (processedAction.activationGates.Count != 0)
                            {
                                //if activation gates are valid - set as action to activate only 
                                //this action with activation gates.
                                //ex. jump = primaryButton, shoot = trigger + primaryButton. If trigger and primary button
                                //was pressed - activate only shoot action and ignore jump action
                                if (ActivationGatesValid(processedAction))
                                {
                                    _MatchingQuaternionActions.Clear();
                                    _MatchingQuaternionActions.Add(processedAction);
                                    return;
                                }
                            }
                            //if action has no activation gates - set as action to activate
                            else
                            {
                                _MatchingQuaternionActions.Add(processedAction);
                            }
                        }
                    }
                }
            }
        }
        void DisableNotValidActionsWithGates()
        {
            MappedInput actionWithGates;
            List<MappedInput> ActiveActionsWithGatesCopy = new List<MappedInput>(_ActiveActionsWithGates);
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
        IEnumerable<T> ProcessActionsWithGates<T>(InputActionPhase phase) where T : MappedInput
        {
            T actionWithGates;
            List<T> _MatchingActions;
            if (typeof(T) == typeof(MappedInputBool))
            {
                _MatchingActions = _MatchingBoolActions as List<T>;
            }
            else if (typeof(T) == typeof(MappedInputFloat))
            {
                _MatchingActions = _MatchingFloatActions as List<T>;
            }
            else if(typeof(T) == typeof(MappedInputVector2))
            {
                _MatchingActions = _MatchingVector2Actions as List<T>;
            }
            else if (typeof(T) == typeof(MappedInputVector3))
            {
                _MatchingActions = _MatchingVector3Actions as List<T>;
            }
            else if (typeof(T) == typeof(MappedInputQuaternion))
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
                    for (int j = 0; j < actionWithGates.activationGates.Count; j++)
                    {
                        //disable actions binded to the same inputTriggers as activation gates
                        SetBoolAction(actionWithGates.activationGates[i], false);
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
                    for (int j = 0; j < actionWithGates.activationGates.Count; j++)
                    {
                        //enable actions binded to the inputs same as activation gates of current actionWithGates
                        BoolInputTriggered((int)actionWithGates.activationGates[i], InputActionPhase.Started);
                    }
                    _ActiveActionsWithGates.Remove(actionWithGates);
                    yield return actionWithGates as T;
                    //return value
                }
            }
        }
        void BoolInputTriggered(int inputTrigger, InputActionPhase phase = InputActionPhase.Started)
        {
            if (phase == InputActionPhase.Started)
            {
                BoolInputs[inputTrigger] = true;
            }
            else
            {
                BoolInputs[inputTrigger] = false;
            }
            bool returnedActionsWithGates = PopulateMatchingBoolActions(inputTrigger);
            //if realeased input was potentialy a part of the gates for other action
            if (phase != InputActionPhase.Started && _ActivationGatesInputs.Contains(inputTrigger))
            {
                DisableNotValidActionsWithGates();
            }
            if (returnedActionsWithGates)
            {
                foreach (var mappedInputBool in ProcessActionsWithGates<MappedInputBool>(phase))
                {
                    if(phase == InputActionPhase.Started) {
                        //activate triggered action with valid gates
                        mappedInputBool.Set(true);
                    }
                    else
                    {
                        mappedInputBool.SetValueDisabled();
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
        void FloatInputTriggered(XRInputTriggerFloat inputTrigger, float value, InputActionPhase phase = InputActionPhase.Started)
        {

            if (phase == InputActionPhase.Started)
            {
                FloatInputs[inputTrigger] = value;
            }
            else
            {
                FloatInputs[inputTrigger] = 0;
            }
            bool returnedActionsWithGates = PopulateMatchingFloatActions(inputTrigger);
            
            if (returnedActionsWithGates)
            {
                foreach (var mappedInputFloat in ProcessActionsWithGates<MappedInputFloat>(phase))
                {
                    if (phase == InputActionPhase.Started)
                    {
                        //activate triggered action with valid gates
                        mappedInputFloat.Set(value);
                    }
                    else
                    {
                        mappedInputFloat.SetValueDisabled();
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


            /*if (value > floatActivationThreashold)
            {
                FloatInputs[inputTrigger] = value;
            }
            else
            {
                FloatInputs[inputTrigger] = 0;
            }
            PopulateMatchingFloatActions(inputTrigger);
            
            for (int i = 0; i < _MatchingFloatActions.Count; i++)
            {
                _MatchingFloatActions[i].Set(value);
            }*/
        }
        void Vector2InputTriggered(XRInputTriggerVector2 inputTrigger, Vector2 value)
        {
            for (int i = 0; i < Vector2Inputs.Count; i++)
            {
                if (Vector2Inputs[i].Key == inputTrigger)
                {
                    Vector2Inputs[i] = new KeyValuePair<XRInputTriggerVector2, Vector2>(inputTrigger, value);
                    break;
                }
            }
            PopulateMatchingVector2Actions(inputTrigger);
            for (int i = 0; i < _MatchingVector2Actions.Count; i++)
            {
                _MatchingVector2Actions[i].Set(value);
            }
        }
        void Vector3InputTriggered(XRInputTriggerVector3 inputTrigger, Vector3 value)
        {
            for (int i = 0; i < Vector3Inputs.Count; i++)
            {
                if (Vector3Inputs[i].Key == inputTrigger)
                {
                    Vector3Inputs[i] = new KeyValuePair<XRInputTriggerVector3, Vector3>(inputTrigger, value);
                    break;
                }
            }
            PopulateMatchingVector3Actions(inputTrigger);
            for (int i = 0; i < _MatchingVector3Actions.Count; i++)
            {
                _MatchingVector3Actions[i].Set(value);
            }
        }
        void QuaternionInputTriggered(XRInputTriggerQuaternion inputTrigger, Quaternion value)
        {
            for (int i = 0; i < QuaternionInputs.Count; i++)
            {
                if (QuaternionInputs[i].Key == inputTrigger)
                {
                    QuaternionInputs[i] = new KeyValuePair<XRInputTriggerQuaternion, Quaternion>(inputTrigger, value);
                    break;
                }
            }
            PopulateMatchingQuaternionActions(inputTrigger);
            for (int i = 0; i < _MatchingQuaternionActions.Count; i++)
            {
                _MatchingQuaternionActions[i].Set(value);
            }
        }


        #region head
        void OnHeadPosition(Vector3 pos)
        {
            Vector3InputTriggered(XRInputTriggerVector3.headPos, pos);
        }
        void OnHeadRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.headRot, rot);
        }
        #endregion

        #region left
        void OnLeftPosition(Vector3 pos)
        {
            
            Vector3InputTriggered(XRInputTriggerVector3.leftHandPos, pos);
        }
        void OnLeftRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.leftHandRot, rot);
        }

        Vector2 prevLeftJoystickValue = new Vector2(0, 0);
        Vector2 vectorZero = new Vector2(0, 0);

        void SetLeftJoystickZeroValues()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
        }
        void OnLeftJoystick(Vector2 value)
        {
            if(value.magnitude > floatActivationThreashold)
            {
                Vector2InputTriggered(XRInputTriggerVector2.leftJoystick, value);
            }
            if (value == vectorZero && prevLeftJoystickValue != vectorZero)
            {
                if (prevLeftJoystickValue.x > -0.7f && prevLeftJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevLeftJoystickValue.y > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUpRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDownRelease);
                        SetLeftJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRightRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeftRelease);
                        SetLeftJoystickZeroValues();
                    }
                }


            }
            else
            {
                if (value.x > -0.7f && value.x < 0.7f)
                {
                    //if value == joystickUp
                    if (prevLeftJoystickValue.y > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUp);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDown);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRight);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.leftJoystickLeft);
                    }
                }
            }

            prevLeftJoystickValue = value;

        }
        void OnLeftGripButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftGripButton, phase);
        }
        void OnLeftGripButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftGripRelease);
        }
        void OnLeftTriggerButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftTriggerButton, phase);
        }
        void OnLeftTriggerButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftTriggerRelease);
        }
        void OnLeftJoystickClicked(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickClick,  phase);
        }
        void OnLeftJoystickReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftJoystickClickRelease);
        }
        void OnLeftPrimaryButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftPrimaryButton, phase);
        }
        void OnLeftPrimaryButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftPrimaryButtonRelease);
        }
        void OnLeftSecondaryButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftSecondaryButton, phase);
        }
        void OnLeftSecondaryButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.leftSecondaryButtonRelease);
        }
        void OnLeftGrip(float value)
        {
            if(value > floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.leftGrip, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.leftGrip, value, InputActionPhase.Canceled);
            }
        }
        void OnLeftTrigger(float value)
        {
            if (value > floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.leftTrigger, value);

            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.leftTrigger, value, InputActionPhase.Canceled);

            }
        }
        #endregion

        #region right
        void OnRightPosition(Vector3 pos)
        {
            Vector3InputTriggered(XRInputTriggerVector3.rightHandPos, pos);
        }
        void OnRightRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.rightHandRot, rot);
        }

        Vector2 prevRightJoystickValue = new Vector2(0, 0);


        void SetRightJoystickZeroValues()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
        }
        void OnRightJoystick(Vector2 value)
        {
            Vector2InputTriggered(XRInputTriggerVector2.rightJoystick, value);
            if (value == vectorZero && prevRightJoystickValue != vectorZero)
            {
                if (prevRightJoystickValue.x > -0.7f && prevRightJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevRightJoystickValue.y > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUpRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDownRelease);
                        SetRightJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRightRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeftRelease);
                        SetRightJoystickZeroValues();
                    }
                }


            }
            else
            {
                if (value.x > -0.7f && value.x < 0.7f)
                {
                    //if value == joystickUp
                    if (prevRightJoystickValue.y > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUp);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDown);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRight);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered((int)XRInputTriggerBool.rightJoystickLeft);
                    }
                }
            }

            prevRightJoystickValue = value;

        }
        void OnRightGripButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightGripButton, phase);
        }
        void OnRightGripButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightGripRelease);
        }
        void OnRightTriggerButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightTriggerButton, phase);
        }
        void OnRightTriggerButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightTriggerRelease);
        }
        void OnRightJoystickClicked(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickClick, phase);
        }
        void OnRightJoystickReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightJoystickClickRelease);
        }
        void OnRightPrimaryButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightPrimaryButton, phase);
        }
        void OnRightPrimaryButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightPrimaryButtonRelease);
        }
        void OnRightSecondaryButton(InputActionPhase phase)
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightSecondaryButton, phase);
        }
        void OnRightSecondaryButtonReleased()
        {
            BoolInputTriggered((int)XRInputTriggerBool.rightSecondaryButtonRelease);
        }
        void OnRightGrip(float value)
        {
            if (value > floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.rightGrip, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.rightGrip, value, InputActionPhase.Canceled);
            }
        }
        void OnRightTrigger(float value)
        {
            if (value > floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.rightTrigger, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.rightTrigger, value, InputActionPhase.Canceled);
            }
        }
        #endregion
    }
}
