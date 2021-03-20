using CoreSystems.XR.Input;
using UnityEngine;

namespace CoreSystems.XR
{
    [AddComponentMenu("XR/XR Hand Transform")]
    [DisallowMultipleComponent]
    public class XRHandTransform : MonoBehaviour
    {
        [SerializeField] XRInputMap1 _input;

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
                _hand = value;
            }
        }
        [SerializeField] Hand _hand;
        private void FixedUpdate()
        {
            if(_hand == Hand.left)
            {
                transform.position = _input.leftHandPosition;
                transform.rotation = _input.leftHandRotation;
            }
            else
            {
                transform.position = _input.rightHandPosition;
                transform.rotation = _input.rightHandRotation;
            }
        }

    }
}
