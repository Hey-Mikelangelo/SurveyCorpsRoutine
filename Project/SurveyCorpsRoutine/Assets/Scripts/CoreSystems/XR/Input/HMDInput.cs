using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoreSystems.XR.Input
{
    internal class HMDInput :  XR_InputActions.IHMDActions, IXRActionReceiver
    {
        public event UnityAction<InputAction.CallbackContext> onPosition;
        public event UnityAction<InputAction.CallbackContext> onRotation;
        
        internal void EnableInputActions(XR_InputActions inputActions)
        {
            if (inputActions == null)
            {
                inputActions = new XR_InputActions();
                inputActions.HMD.SetCallbacks(this);
            }
            inputActions.LeftHand.Enable();
        }
        internal void DisableInputActions(XR_InputActions inputActions)
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

        public void SubsribeCallbacks(XR_InputActions inputActions)
        {
            inputActions.HMD.SetCallbacks(this);
        }
    }

}