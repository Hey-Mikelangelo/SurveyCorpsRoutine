using UnityEngine;

namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMapSO", menuName = "XR/Input/XR Input Map")]

    public class XRInputMapSO : ScriptableObject
    {
        public enum Hand
        {
            left, right
        }
        public Hand movementJoystick;

        public XRInputButton
            jumpButton = XRInputButton.rightJoystickClick,
            rotateLeftButton = XRInputButton.rightJoystickLeft,
            rotateRightButton = XRInputButton.rightJoystickRight,
            rotateBackButton = XRInputButton.rightJoystickDown,
            sprintButton = XRInputButton.rightJoystickUp,
            rightGestureButton = XRInputButton.rightSecondaryButton,
            leftGestureButton = XRInputButton.leftSecondaryButton,
            rightTrigger = XRInputButton.rightTriggerButton;

    
    }
}
