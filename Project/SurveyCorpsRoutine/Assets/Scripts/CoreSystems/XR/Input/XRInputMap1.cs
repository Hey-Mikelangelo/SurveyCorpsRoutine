using UnityEngine;

namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMap1", menuName = "XR/Input/Maps/Map1")]
    public class XRInputMap1 : XRInputMap
    {
        public XRMappedInput<bool>
            jump,
            rotateLeft,
            rotateRight,
            rotateBack,
            rightGesture,
            leftGesture,
            rightGestureChange,
            leftGestureChange;

        public XRMappedInput<float>
            sprint,
            leftHandGrab,
            rightHandGrab;

        public XRMappedInput<Vector2> 
            move;

        protected override void SetBoolInputs()
        {
            BoolInputs = new XRMappedInput<bool>[]
            {
                jump,
                rotateLeft,
                rotateRight,
                rotateBack,
                rightGesture,
                leftGesture,
                rightGestureChange,
                leftGestureChange
            };
        }

        protected override void SetFloatInputs()
        {
            FloatInputs = new XRMappedInput<float>[]
            {
                sprint,
                leftHandGrab,
                rightHandGrab
            };
        }

        protected override void SetVector2Inputs()
        {
            Vector2Inputs = new XRMappedInput<Vector2>[]
            {
                move
            };
        }
    }
}
