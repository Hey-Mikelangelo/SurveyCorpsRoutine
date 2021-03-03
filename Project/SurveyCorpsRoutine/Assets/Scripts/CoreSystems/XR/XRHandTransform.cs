using CoreSystems.XR.Input;
using UnityEngine;

namespace CoreSystems.XR
{
    [AddComponentMenu("XR/XR Hand Transform")]
    [DisallowMultipleComponent]
    public class XRHandTransform : MonoBehaviour
    {
        public XRInputEventsSO xrInputEvents;
        public enum Hand
        {
            left, right
        }
        public Hand hand
        {
            get
            {
                return _hand;
            }
            set
            {
                UnbindActions();
                _hand = value;
                BindActions();
            }
        }
        [SerializeField] Hand _hand;

        private void OnEnable()
        {
            BindActions();
        }

        private void OnDisable()
        {
            UnbindActions();
        }
        void BindActions()
        {
            if (_hand == Hand.left)
            {
                xrInputEvents.onLeftPosition += OnPosition;
                xrInputEvents.onLeftRotation += OnRotation;
            }
            else
            {
                xrInputEvents.onRightPosition += OnPosition;
                xrInputEvents.onRightRotation += OnRotation;
            }
        }
        void UnbindActions()
        {
            if (_hand == Hand.left)
            {
                xrInputEvents.onLeftPosition -= OnPosition;
                xrInputEvents.onLeftRotation -= OnRotation;

            }
            else
            {
                xrInputEvents.onRightPosition -= OnPosition;
                xrInputEvents.onRightRotation -= OnRotation;
            }

        }
        private void OnRotation(Quaternion rot)
        {
            transform.localRotation = rot;
        }

        private void OnPosition(Vector3 pos)
        {
            transform.localPosition = pos;
        }


    }
}
