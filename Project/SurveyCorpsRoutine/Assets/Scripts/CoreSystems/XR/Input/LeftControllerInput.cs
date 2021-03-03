using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoreSystems.XR.Input
{
    internal class LeftControllerInput : XRInputActions.ILeftHandActions, IXRActionReceiver
    {
        public event UnityAction<InputAction.CallbackContext> onPosition;
        public event UnityAction<InputAction.CallbackContext> onRotation;
        public event UnityAction<InputAction.CallbackContext> onPrimaryAxis;
        public event UnityAction<InputAction.CallbackContext> onGripButton;
        public event UnityAction<InputAction.CallbackContext> onPrimaryAxisClicked;
        public event UnityAction<InputAction.CallbackContext> onPrimaryButton;
        public event UnityAction<InputAction.CallbackContext> onSecondaryButton;
        public event UnityAction<InputAction.CallbackContext> onTriggerButton;
        public event UnityAction<InputAction.CallbackContext> onTriggerTouch;
        public event UnityAction<InputAction.CallbackContext> onPrimaryButtonTouch;
        public event UnityAction<InputAction.CallbackContext> onThumbstickTouch;


        XRInputActions inputActions;
        public void SubsribeCallbacks(XRInputActions inputActions)
        {
            inputActions.LeftHand.SetCallbacks(this);
        }
        public void OnPosition(InputAction.CallbackContext context)
        {
            onPosition?.Invoke(context);
        }
        public void OnRotation(InputAction.CallbackContext context)
        {
            onRotation?.Invoke(context);
        }
        public void OnPrimaryAxis(InputAction.CallbackContext context)
        {
            onPrimaryAxis?.Invoke(context);
        }
        public void OnGripButton(InputAction.CallbackContext context)
        {
            onGripButton?.Invoke(context);
        }

        public void OnPrimaryAxisClicked(InputAction.CallbackContext context)
        {
            onPrimaryAxisClicked?.Invoke(context);
        }

        public void OnPrimaryButton(InputAction.CallbackContext context)
        {
            onPrimaryButton?.Invoke(context);
        }
        public void OnSecondaryButton(InputAction.CallbackContext context)
        {
            onSecondaryButton?.Invoke(context);
        }
        public void OnTriggerButton(InputAction.CallbackContext context)
        {
            onTriggerButton?.Invoke(context);
        }

        public void OnTriggerTouch(InputAction.CallbackContext context)
        {
            onTriggerTouch?.Invoke(context);
        }

        public void OnPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            onPrimaryButtonTouch?.Invoke(context);
        }

        public void OnThumbstickTouch(InputAction.CallbackContext context)
        {
            onThumbstickTouch?.Invoke(context);
        }
    }

}