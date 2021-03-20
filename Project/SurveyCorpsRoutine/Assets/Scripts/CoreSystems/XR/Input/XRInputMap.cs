using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreSystems.XR.Input
{
    public abstract class XRInputMap<T1, T2, T3, T4, T5> : ScriptableObject where T1 : Enum
    {
        public abstract class MappedInput
        {
            public Type type;
            public List<XRInputTriggerBool> activationGates; //buttons which should be pressed to activate input
            [ShowOnly] public string valueType;

            protected void SetValueType()
            {
                valueType = type.ToString();
            }
            public abstract void SetValueDisabled();
        }

        [System.Serializable]
        public class MappedInputBool : MappedInput
        {
            [SerializeField]private bool _value;
            public T1 inputTrigger;
            public Type _valueType;
            public MappedInputBool()
            {
                type = typeof(bool);
                SetValueType();
            }
            public void Set(bool value)
            {
                this._value = value;
            }
            public bool Get()
            {
                return _value;
            }

            public override void SetValueDisabled()
            {
                Set(false);
            }

            public static implicit operator bool(MappedInputBool mappedInput)
            {
                return mappedInput.Get();
            }
        }
        [System.Serializable]
        public class MappedInputFloat : MappedInput
        {
            [SerializeField] private float _value;
            public XRInputTriggerFloat inputTrigger;
            public MappedInputFloat()
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

            public static implicit operator float(MappedInputFloat mappedInput)
            {
                return mappedInput.Get();
            }
        }
        [System.Serializable]
        public class MappedInputVector2 : MappedInput
        {
            private Vector2 _value;
            public XRInputTriggerVector2 inputTrigger;
            public MappedInputVector2()
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

            public static implicit operator Vector2(MappedInputVector2 mappedInput)
            {
                return mappedInput.Get();
            }
        }
        [System.Serializable]
        public class MappedInputVector3 : MappedInput
        {
            private Vector3 _value;
            public XRInputTriggerVector3 inputTrigger;
            public MappedInputVector3()
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

            public static implicit operator Vector3(MappedInputVector3 mappedInput)
            {
                return mappedInput.Get();
            }
        }
        [System.Serializable]
        public class MappedInputQuaternion : MappedInput
        {
            private Quaternion _value;
            public XRInputTriggerQuaternion inputTrigger;
            public MappedInputQuaternion()
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

            public static implicit operator Quaternion(MappedInputQuaternion mappedInput)
            {
                return mappedInput.Get();
            }
        }

        protected List<int> ActionGatesTriggers = new List<int>(3);
        protected List<MappedInputBool> BoolActions;
        protected List<MappedInputFloat> FloatActions;
        protected List<MappedInputVector2> Vector2Actions;
        protected List<MappedInputVector3> Vector3Actions;
        protected List<MappedInputQuaternion> QuaternionActions;

             
        public List<MappedInputBool> GetBoolActions()
        {
            return BoolActions;
        }
        public List<MappedInputFloat> GetFloatActions()
        {
            return FloatActions;
        }
        public List<MappedInputVector2> GetVector2Actions()
        {
            return Vector2Actions;
        }
        public List<MappedInputVector3> GetVector3Actions()
        {
            return Vector3Actions;
        }
        public List<MappedInputQuaternion> GetQuaternionActions()
        {
            return QuaternionActions;
        }
        public List<int> GetBoolActionGatesTriggers()
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
            FillBoolActionList();
            FillFloatActionList();
            FillVector2ActionList();
            FillVector3ActionList();
            FillQuaternionActionList();
            FillBoolActionGatesTriggers();
            foreach (XRInputTriggerBool item in ActionGatesTriggers)
            {
                Debug.Log("activation gate: " + item.ToString());
            }
        }
        private void OnDisable()
        {
           
        }
        void FillBoolActionGatesTriggers()
        {
            MappedInputBool mappedInputBool;
            for (int i = 0; i < BoolActions.Count; i++)
            {
                mappedInputBool = BoolActions[i];
                if (mappedInputBool.activationGates.Count != 0)
                {
                    ActionGatesTriggers.AddRange(mappedInputBool.activationGates.Cast<int>());
                }
            }
            MappedInputFloat mappedInputFloat;
            for (int i = 0; i < FloatActions.Count; i++)
            {
                mappedInputFloat = FloatActions[i];
                if (mappedInputFloat.activationGates.Count != 0)
                {
                    ActionGatesTriggers.AddRange(mappedInputFloat.activationGates.Cast<int>());
                }
            }
            MappedInputVector2 mappedInputVector2;
            for (int i = 0; i < Vector2Actions.Count; i++)
            {
                mappedInputVector2 = Vector2Actions[i];
                if (mappedInputVector2.activationGates.Count != 0)
                {
                    ActionGatesTriggers.AddRange(mappedInputVector2.activationGates.Cast<int>());
                }
            }
            MappedInputVector3 mappedInputVector3;
            for (int i = 0; i < Vector3Actions.Count; i++)
            {
                mappedInputVector3 = Vector3Actions[i];
                if (mappedInputVector3.activationGates.Count != 0)
                {
                    ActionGatesTriggers.AddRange(mappedInputVector3.activationGates.Cast<int>());
                }
            }
            MappedInputQuaternion mappedInputQuaternion;
            for (int i = 0; i < QuaternionActions.Count; i++)
            {
                mappedInputQuaternion = QuaternionActions[i];
                if (mappedInputQuaternion.activationGates.Count != 0)
                {
                    ActionGatesTriggers.AddRange(mappedInputQuaternion.activationGates.Cast<int>());
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
