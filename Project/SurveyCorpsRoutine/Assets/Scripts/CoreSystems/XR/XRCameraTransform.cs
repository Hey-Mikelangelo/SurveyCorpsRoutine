using CoreSystems.XR.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

namespace CoreSystems.XR
{
    [AddComponentMenu("XR/XR Camera")]
    [DisallowMultipleComponent]
    public class XRCameraTransform : MonoBehaviour
    {
        public XRInputMap1 input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }

        [SerializeField] XRInputMap1 _input;
        private void OnEnable()
        {
            InputSystem.onAfterUpdate += UpdateCallback;
        }
        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= UpdateCallback;
        }
        void UpdateCallback()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                OnBeforeRender();
        }
        void OnBeforeRender()
        {
            transform.position = _input.headPosition;
            transform.rotation = _input.headRotation;
        }
        private void FixedUpdate()
        {
            transform.position = _input.headPosition;
            transform.rotation = _input.headRotation;
        }

    }
}
