using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoreSystems.XR.Input
{
    internal class HMDInput :  XRInputActions.IHMDActions, IXRActionReceiver
    {
        public event UnityAction<InputAction.CallbackContext> onPosition;
        public event UnityAction<InputAction.CallbackContext> onRotation;
        
        internal void EnableInputActions(XRInputActions inputActions)
        {
            if (inputActions == null)
            {
                inputActions = new XRInputActions();
                inputActions.HMD.SetCallbacks(this);
            }
            inputActions.LeftHand.Enable();
        }
        internal void DisableInputActions(XRInputActions inputActions)
        {
            if (inputActions == null)
            {
                return;
            }
            inputActions.HMD.Disable();
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
            onPosition?.Invoke(context);
        }

        public void OnRotation(InputAction.CallbackContext context)
        {
            onRotation?.Invoke(context);
        }

        public void SubsribeCallbacks(XRInputActions inputActions)
        {
            inputActions.HMD.SetCallbacks(this);
        }
    }

}