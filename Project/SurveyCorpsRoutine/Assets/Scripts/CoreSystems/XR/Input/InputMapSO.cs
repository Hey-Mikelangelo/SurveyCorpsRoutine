using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CoreSystems.Input
{
    public abstract class InputMapSO<boolEnum, floatEnum, vector2Enum, vector3Enum, quaternionEnum> : ScriptableObject 
        where boolEnum : Enum
        where floatEnum : Enum
        where vector2Enum : Enum
        where vector3Enum : Enum
        where quaternionEnum : Enum
    {
        public Type GetBoolEnumType()
        {
            return typeof(boolEnum);
        }
        public Type GetFloatEnumType()
        {
            return typeof(floatEnum);
        }
        public Type GetVector2EnumType()
        {
            return typeof(vector2Enum);
        }
        public Type GetVector3EnumType()
        {
            return typeof(vector3Enum);
        }
        public Type GetQuaternionEnumType()
        {
            return typeof(quaternionEnum);
        }
        public abstract class Action
        {
            public Type type;
            [ShowOnly] public string valueType;
            protected int _passedGatesIndx;
            protected bool _hasActivationGates;

            protected void SetValueType()
            {
                valueType = type.ToString();
            }
            public abstract void SetValueDisabled();
            public abstract List<boolEnum> GetActivationGates(int bindingIndx);
            public abstract int GetBindingsCount();
            public abstract bool HasActivationGates();
            public abstract void SetPassedGatesIndx(int indx);
            public abstract int GetPassedGatesIndx();
        }
        [InitializeOnLoad]
        [System.Serializable]
        public class BoolAction : Action
        {
            [System.Serializable]
            public class Binding
            {
                public List<boolEnum> activationGates; //buttons which should be pressed to activate input
                public boolEnum inputTrigger;
            }
            public List<Binding> Bindings;
            private bool _value;
           
            public Type _valueType;
            public BoolAction()
            {
                type = typeof(bool);
                SetValueType();
            }
            public void Set(bool value)
            {
                _value = value;
            }
            public bool Get()
            {
                return _value;
            }
            
            public override void SetValueDisabled()
            {
                Set(false);
            }
            public bool IsBindedToInput(boolEnum inputTrigger)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].inputTrigger.Equals(inputTrigger))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override List<boolEnum> GetActivationGates(int bindingIndx)
            {
                return Bindings[bindingIndx].activationGates;
            }

            public override int GetBindingsCount()
            {
                return Bindings.Count;
            }

            public override bool HasActivationGates()
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].activationGates != null && Bindings[i].activationGates.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void SetPassedGatesIndx(int indx)
            {
                _passedGatesIndx = indx;
            }

            public override int GetPassedGatesIndx()
            {
                return _passedGatesIndx;
            }

            public static implicit operator bool(BoolAction action)
            {
                return action.Get();
            }
        }
        [System.Serializable]
        public class FloatAction : Action
        {
            [System.Serializable]
            public class Binding
            {
                public List<boolEnum> activationGates; //buttons which should be pressed to activate input
                public floatEnum inputTrigger;
            }
            public List<Binding> Bindings;
            private float _value;
            public FloatAction()
            {
                type = typeof(float);
                SetValueType();
            }
            public void Set(float value)
            {
                this._value = value;
            }
            public float Get()
            {
                return _value;
            }

            public override void SetValueDisabled()
            {
                Set(0);
            }
            public bool IsBindedToInput(floatEnum inputTrigger)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].inputTrigger.Equals(inputTrigger))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override List<boolEnum> GetActivationGates(int bindingIndx)
            {
                return Bindings[bindingIndx].activationGates;
            }

            public override int GetBindingsCount()
            {
                return Bindings.Count;
            }

            public override bool HasActivationGates()
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].activationGates != null && Bindings[i].activationGates.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void SetPassedGatesIndx(int indx)
            {
                _passedGatesIndx = indx;
            }

            public override int GetPassedGatesIndx()
            {
                return _passedGatesIndx;
            }

            public static implicit operator float(FloatAction action)
            {
                return action.Get();
            }
        }
        [System.Serializable]
        public class Vector2Action : Action
        {
            [System.Serializable]
            public class Binding
            {
                public List<boolEnum> activationGates; //buttons which should be pressed to activate input
                public vector2Enum inputTrigger;
            }
            public List<Binding> Bindings;
            private Vector2 _value;
            public Vector2Action()
            {
                type = typeof(Vector2);
                SetValueType();
            }
            public void Set(Vector2 value)
            {
                this._value = value;
            }
            public Vector2 Get()
            {
                return _value;
            }

            public override void SetValueDisabled()
            {
                Set(new Vector2(0, 0));
            }
            public bool IsBindedToInput(vector2Enum inputTrigger)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].inputTrigger.Equals(inputTrigger))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override List<boolEnum> GetActivationGates(int bindingIndx)
            {
                return Bindings[bindingIndx].activationGates;
            }

            public override int GetBindingsCount()
            {
                return Bindings.Count;
            }

            public override bool HasActivationGates()
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].activationGates != null && Bindings[i].activationGates.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void SetPassedGatesIndx(int indx)
            {
                _passedGatesIndx = indx;
            }

            public override int GetPassedGatesIndx()
            {
                return _passedGatesIndx;
            }

            public static implicit operator Vector2(Vector2Action action)
            {
                return action.Get();
            }
        }
        [System.Serializable]
        public class Vector3Action : Action
        {
            [System.Serializable]
            public class Binding
            {
                public List<boolEnum> activationGates; //buttons which should be pressed to activate input
                public vector3Enum inputTrigger;
            }
            public List<Binding> Bindings;
            private Vector3 _value;
            public Vector3Action()
            {
                type = typeof(Vector3);
                SetValueType();
            }
            public void Set(Vector3 value)
            {
                this._value = value;
            }
            public Vector3 Get()
            {
                return _value;
            }

            public override void SetValueDisabled()
            {
                Set(new Vector3(0,0,0));
            }
            public bool IsBindedToInput(vector3Enum inputTrigger)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].inputTrigger.Equals(inputTrigger))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override List<boolEnum> GetActivationGates(int bindingIndx)
            {
                return Bindings[bindingIndx].activationGates;
            }

            public override int GetBindingsCount()
            {
                return Bindings.Count;
            }

            public override bool HasActivationGates()
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].activationGates != null && Bindings[i].activationGates.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void SetPassedGatesIndx(int indx)
            {
                _passedGatesIndx = indx;
            }

            public override int GetPassedGatesIndx()
            {
                return _passedGatesIndx;
            }

            public static implicit operator Vector3(Vector3Action action)
            {
                return action.Get();
            }
        }
        [System.Serializable]
        public class QuaternionAction : Action
        {
            [System.Serializable]
            public class Binding
            {
                public List<boolEnum> activationGates; //buttons which should be pressed to activate input
                public quaternionEnum inputTrigger;
            }
            public List<Binding> Bindings;
            private Quaternion _value;
            public QuaternionAction()
            {
                type = typeof(Quaternion);
                SetValueType();
            }
            public void Set(Quaternion value)
            {
                this._value = value;
            }
            public Quaternion Get()
            {
                return _value;
            }

            public override void SetValueDisabled()
            {
                Set(Quaternion.identity);
            }
            public bool IsBindedToInput(quaternionEnum inputTrigger)
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].inputTrigger.Equals(inputTrigger))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override List<boolEnum> GetActivationGates(int bindingIndx)
            {
                return Bindings[bindingIndx].activationGates;
            }

            public override int GetBindingsCount()
            {
                return Bindings.Count;
            }

            public override bool HasActivationGates()
            {
                for (int i = 0; i < Bindings.Count; i++)
                {
                    if (Bindings[i].activationGates != null && Bindings[i].activationGates.Count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void SetPassedGatesIndx(int indx)
            {
                _passedGatesIndx = indx;
            }

            public override int GetPassedGatesIndx()
            {
                return _passedGatesIndx;
            }


            public static implicit operator Quaternion(QuaternionAction action)
            {
                return action.Get();
            }
        }

        protected List<boolEnum> ActionGatesTriggers = new List<boolEnum>(3);
        protected List<BoolAction> BoolActions = new List<BoolAction>();
        protected List<FloatAction> FloatActions = new List<FloatAction>();
        protected List<Vector2Action> Vector2Actions = new List<Vector2Action>();
        protected List<Vector3Action> Vector3Actions = new List<Vector3Action>();
        protected List<QuaternionAction> QuaternionActions = new List<QuaternionAction>();

             
        public List<BoolAction> GetBoolActions()
        {
            return BoolActions;
        }
        public List<FloatAction> GetFloatActions()
        {
            return FloatActions;
        }
        public List<Vector2Action> GetVector2Actions()
        {
            return Vector2Actions;
        }
        public List<Vector3Action> GetVector3Actions()
        {
            return Vector3Actions;
        }
        public List<QuaternionAction> GetQuaternionActions()
        {
            return QuaternionActions;
        }
        public List<boolEnum> GetBoolActionGatesTriggers()
        {
            return ActionGatesTriggers;
        }

        private void OnEnable()
        {
            BoolActions.Clear();
            FloatActions.Clear();
            Vector2Actions.Clear();
            Vector3Actions.Clear();
            QuaternionActions.Clear();
            ActionGatesTriggers.Clear();
            FillBoolActionList();
            FillFloatActionList();
            FillVector2ActionList();
            FillVector3ActionList();
            FillQuaternionActionList();
            FillBoolActionGatesTriggers();
        }
        private void OnDisable()
        {
           
        }
        void FillBoolActionGatesTriggers()
        {
            BoolAction boolAction;
            for (int i = 0; i < BoolActions.Count; i++)
            {
                boolAction = BoolActions[i];
                for (int j = 0; j < boolAction.Bindings.Count; j++)
                {
                    ActionGatesTriggers.AddRange(boolAction.GetActivationGates(j));
                }
                
            }
            FloatAction floatAction;
            for (int i = 0; i < FloatActions.Count; i++)
            {
                floatAction = FloatActions[i];
                for (int j = 0; j < floatAction.Bindings.Count; j++)
                {
                    ActionGatesTriggers.AddRange(floatAction.GetActivationGates(j));
                }
            }
            Vector2Action vector2Action;
            for (int i = 0; i < Vector2Actions.Count; i++)
            {
                vector2Action = Vector2Actions[i];
                for (int j = 0; j < vector2Action.Bindings.Count; j++)
                {
                    ActionGatesTriggers.AddRange(vector2Action.GetActivationGates(j));
                }
            }
            Vector3Action vector3Action;
            for (int i = 0; i < Vector3Actions.Count; i++)
            {
                vector3Action = Vector3Actions[i];
                for (int j = 0; j < vector3Action.Bindings.Count; j++)
                {
                    ActionGatesTriggers.AddRange(vector3Action.GetActivationGates(j));
                }
            }
            QuaternionAction quaternionAction;
            for (int i = 0; i < QuaternionActions.Count; i++)
            {
                quaternionAction = QuaternionActions[i];
                for (int j = 0; j < quaternionAction.Bindings.Count; j++)
                {
                    ActionGatesTriggers.AddRange(quaternionAction.GetActivationGates(j));
                }
            }
            ActionGatesTriggers = ActionGatesTriggers.Distinct().ToList();
        }
        protected abstract void FillBoolActionList();
        protected abstract void FillFloatActionList();
        protected abstract void FillVector2ActionList();
        protected abstract void FillVector3ActionList();
        protected abstract void FillQuaternionActionList();

    }

}
