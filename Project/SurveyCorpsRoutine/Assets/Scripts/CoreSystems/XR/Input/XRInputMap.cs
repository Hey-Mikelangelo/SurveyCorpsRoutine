using System.Collections.Generic;
using UnityEngine;

namespace CoreSystems.XR.Input
{
    public abstract class XRInputMap : ScriptableObject
    {
        [System.Serializable]
        public class XRMappedInput<T>
        {
            public XRInputButton inputButton;
            [ShowOnly] public string type;
            [ShowOnly] public T value;

            public void SetInputTrigger(XRInputButton inputButton)
            {
                this.inputButton = inputButton;
            }
            public void SetValue(T value)
            {
                this.value = value;
            }
            public XRMappedInput(XRInputButton inputTrigger)
            {
                this.inputButton = inputTrigger;
                this.value = default;
                this.type = typeof(T).ToString();
            }

            public static implicit operator T(XRMappedInput<T> xRInput)
            {
                return xRInput.value;
            }
        }
        protected XRMappedInput<bool>[] BoolInputs;
        //[HideInInspector] public List<XRMappedInput<bool>> BoolInputs = new List<XRMappedInput<bool>>();
        [HideInInspector] public XRMappedInput<float>[] FloatInputs;
        [HideInInspector] public XRMappedInput<Vector2>[] Vector2Inputs;

        #region headAndHandsPosRot
        public Vector3 headPosition { get; private set; }
        public Quaternion headRotation { get; private set; }
        public Vector3 leftHandPosition { get; private set; }
        public Quaternion leftHandRotation { get; private set; }
        public Vector3 rightHandPosition { get; private set; }
        public Quaternion rightHandRotation { get; private set; }
        #endregion
        public void SetHeadPos(Vector3 pos)
        {
            headPosition = pos;
        }
        public void SetHeadRot(Quaternion rot)
        {
            headRotation = rot;
        }
        public void SetRightHandPos(Vector3 pos)
        {
            rightHandPosition = pos;
        }
        public void SetLeftHandPos(Vector3 pos)
        {
            leftHandPosition = pos;
        }
        public void SetRightHandRot(Quaternion rot)
        {
            rightHandRotation = rot;
        }
        public void SetLeftHandRot(Quaternion rot)
        {
            leftHandRotation = rot;
        }
        private void OnEnable()
        {
            SetBoolInputs();
            SetFloatInputs();
            SetVector2Inputs();
        }
        public XRMappedInput<bool>[] GetBoolInputs()
        {
            return BoolInputs;
        }
        public XRMappedInput<float>[] GetFloatInputs()
        {
            return FloatInputs;
        }
        public XRMappedInput<Vector2>[] GetVector2Inputs()
        {
            return Vector2Inputs;
        }

        protected abstract void SetBoolInputs();
        protected abstract void SetFloatInputs();
        protected abstract void SetVector2Inputs();
    }
}
