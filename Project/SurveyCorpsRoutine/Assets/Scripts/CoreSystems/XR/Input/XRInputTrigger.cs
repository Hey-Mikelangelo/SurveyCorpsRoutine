
namespace CoreSystems.XR.Input
{
    public enum XRInputTriggerBool
    {
        any,
        leftPrimaryButton,
        leftSecondaryButton,
        leftGripButton,
        leftTriggerButton,
        leftJoystickClick,
        leftJoystickUp,
        leftJoystickDown,
        leftJoystickRight,
        leftJoystickLeft,
        leftPrimaryButtonRelease,
        leftSecondaryButtonRelease,
        leftGripRelease,
        leftTriggerRelease,
        leftJoystickClickRelease,
        leftJoystickUpRelease,
        leftJoystickDownRelease,
        leftJoystickRightRelease,
        leftJoystickLeftRelease,

        rightPrimaryButton,
        rightSecondaryButton,
        rightGripButton,
        rightTriggerButton,
        rightJoystickClick,
        rightJoystickUp,
        rightJoystickDown,
        rightJoystickRight,
        rightJoystickLeft,
        rightPrimaryButtonRelease,
        rightSecondaryButtonRelease,
        rightGripRelease,
        rightTriggerRelease,
        rightJoystickClickRelease,
        rightJoystickUpRelease,
        rightJoystickDownRelease,
        rightJoystickRightRelease,
        rightJoystickLeftRelease,
    }

    public enum XRInputTriggerFloat
    {
        any,
        leftGrip,       
        leftTrigger,    
        rightGrip,     
        rightTrigger, 
    }
    public enum XRInputTriggerVector2
    {
        any,
        leftJoystick,   
        rightJoystick,
    }
    public enum XRInputTriggerVector3
    {
        any,
        headPos,       
        leftHandPos,  
        rightHandPos,
    }
    public enum XRInputTriggerQuaternion
    {
        any,
        headRot,        
        leftHandRot, 
        rightHandRot,
    }
  /*  public enum XRInputTrigger
    {        
        any, 
        leftPrimaryButton,
        leftSecondaryButton,
        leftGripButton,
        leftTriggerButton,
        leftJoystickClick,
        leftJoystickUp,
        leftJoystickDown,
        leftJoystickRight,
        leftJoystickLeft,
        leftPrimaryButtonRelease,
        leftSecondaryButtonRelease,
        leftGripRelease,
        leftTriggerRelease,
        leftJoystickClickRelease,
        leftJoystickUpRelease,
        leftJoystickDownRelease,
        leftJoystickRightRelease,
        leftJoystickLeftRelease, 
       
        rightPrimaryButton,
        rightSecondaryButton,
        rightGripButton,
        rightTriggerButton,
        rightJoystickClick,
        rightJoystickUp,
        rightJoystickDown,
        rightJoystickRight,
        rightJoystickLeft,
        rightPrimaryButtonRelease,
        rightSecondaryButtonRelease,
        rightGripRelease,
        rightTriggerRelease,
        rightJoystickClickRelease,
        rightJoystickUpRelease,
        rightJoystickDownRelease,
        rightJoystickRightRelease,
        rightJoystickLeftRelease,

        leftGrip,       //float     //add float inputs after leftGrip and before rightTrigger
        leftTrigger,    //float
        rightGrip,      //float
        rightTrigger,   //float

        leftJoystick,   //vector2   //add vector2 inputs after leftJoystick and before rightJoystick
        rightJoystick,  //vector2

        headPos,        //vector3   //add vector3 inputs after headPos and before rightHandPos
        leftHandPos,    //vector3
        rightHandPos,   //vector3

        headRot,        //quaternion    //add quaternion inputs after headRot and before leftHandRot
        leftHandRot,    //quaternion
        rightHandRot,   //quaternion
    }*/
}
