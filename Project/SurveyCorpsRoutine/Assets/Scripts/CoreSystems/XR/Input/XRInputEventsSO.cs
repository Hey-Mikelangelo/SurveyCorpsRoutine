using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoreSystems.XR.Input
{ 

    [CreateAssetMenu(fileName = "XRInputEventsSO", menuName = "XR/Input/Events SO")]
    public class XRInputEventsSO : ScriptableObject, XRInputActions.IOpenVRActions
    {
        [SerializeField] private XRInputActions inputActions;
        public event UnityAction<Vector3> onHeadPosition;
        public event UnityAction<Quaternion> onHeadRotation;

        public event UnityAction<Vector3> onLeftPosition;
        public event UnityAction<Quaternion> onLeftRotation;
        public event UnityAction<Vector2> onLeftPrimaryAxis;
        public event UnityAction<InputActionPhase> onLeftPrimaryAxisClick;
        public event UnityAction<InputActionPhase> onLeftGripButton;
        public event UnityAction<InputActionPhase> onLeftPrimaryButton;
        public event UnityAction<InputActionPhase> onLeftSecondaryButton;
        public event UnityAction<InputActionPhase> onLeftTriggerButton;
        public event UnityAction<InputActionPhase> onLeftPrimaryAxisTouch;
        public event UnityAction onLeftPrimaryAxisClickReleased;
        public event UnityAction onLeftGripButtonReleased;
        public event UnityAction onLeftTriggerButtonReleased;
        public event UnityAction onLeftPrimaryButtonReleased;
        public event UnityAction onLeftSecondaryButtonReleased;
        public event UnityAction onLeftPrimaryAxisTouchReleased;
        public event UnityAction<float> onLeftGrip;
        public event UnityAction<float> onLeftTrigger;


        public event UnityAction<Vector3> onRightPosition;
        public event UnityAction<Quaternion> onRightRotation;
        public event UnityAction<Vector2> onRightPrimaryAxis;
        public event UnityAction<InputActionPhase> onRightPrimaryAxisClick;
        public event UnityAction<InputActionPhase> onRightGripButton;
        public event UnityAction<InputActionPhase> onRightPrimaryButton;
        public event UnityAction<InputActionPhase> onRightSecondaryButton;
        public event UnityAction<InputActionPhase> onRightTriggerButton;
        public event UnityAction<InputActionPhase> onRightPrimaryAxisTouch;
        public event UnityAction onRightPrimaryAxisClickReleased;
        public event UnityAction onRightGripButtonReleased;
        public event UnityAction onRightTriggerButtonReleased;
        public event UnityAction onRightPrimaryButtonReleased;
        public event UnityAction onRightSecondaryButtonReleased;
        public event UnityAction onRightPrimaryAxisTouchReleased;
        public event UnityAction<float> onRightGrip;
        public event UnityAction<float> onRightTrigger;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new XRInputActions();
            }
            inputActions.OpenVR.SetCallbacks(this);
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();

        }

        #region HMD
        public void OnHeadPosition(InputAction.CallbackContext context)
        {
            onHeadPosition?.Invoke(context.ReadValue<Vector3>());
        }

        public void OnHeadRotation(InputAction.CallbackContext context)
        {
            onHeadRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        #endregion

        #region leftController
        public void OnLeftPosition(InputAction.CallbackContext context)
        {
            onLeftPosition?.Invoke(context.ReadValue<Vector3>());
        }
        public void OnLeftRotation(InputAction.CallbackContext context)
        {
            onLeftRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        public void OnLeftPrimaryAxis(InputAction.CallbackContext context)
        {
            onLeftPrimaryAxis?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnLeftPrimaryAxisClick(InputAction.CallbackContext context)
        {
            Debug.Log(context.phase);
            if (context.started)
            {
                onLeftPrimaryAxisClick?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryAxisClick?.Invoke(InputActionPhase.Canceled);
                onLeftPrimaryAxisClickReleased?.Invoke();
            }
        }
        public void OnLeftGripButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftGripButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftGripButton?.Invoke(InputActionPhase.Canceled);
                onLeftGripButtonReleased?.Invoke();
            }
        }

        public void OnLeftPrimaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryButton?.Invoke(InputActionPhase.Canceled);
                onLeftPrimaryButtonReleased?.Invoke();
            }
        }
        public void OnLeftSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftSecondaryButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftSecondaryButton?.Invoke(InputActionPhase.Canceled);
                onLeftSecondaryButtonReleased?.Invoke();
            }
        }

        public void OnLeftTriggerButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftTriggerButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftTriggerButton?.Invoke(InputActionPhase.Canceled);
                onLeftTriggerButtonReleased?.Invoke();
            }
        }
        public void OnLeftPrimaryAxisTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryAxisTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryAxisTouch?.Invoke(InputActionPhase.Canceled);
                onLeftPrimaryAxisTouchReleased?.Invoke();
            }
        }
        public void OnLeftGrip(InputAction.CallbackContext context)
        {
            onLeftGrip?.Invoke(context.ReadValue<float>());
        }
        public void OnLeftTrigger(InputAction.CallbackContext context)
        {
            onLeftTrigger?.Invoke(context.ReadValue<float>());
        }
        #endregion

        #region rightController
        public void OnRightPosition(InputAction.CallbackContext context)
        {
            onRightPosition?.Invoke(context.ReadValue<Vector3>());
        }
        public void OnRightRotation(InputAction.CallbackContext context)
        {
            onRightRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        public void OnRightPrimaryAxis(InputAction.CallbackContext context)
        {
            onRightPrimaryAxis?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnRightPrimaryAxisClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryAxisClick?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightPrimaryAxisClick?.Invoke(InputActionPhase.Canceled);
                onRightPrimaryAxisClickReleased?.Invoke();
            }
        }
        public void OnRightGripButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightGripButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightGripButton?.Invoke(InputActionPhase.Canceled);
                onRightGripButtonReleased?.Invoke();
            }
        }

        public void OnRightPrimaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightPrimaryButton?.Invoke(InputActionPhase.Canceled);
                onRightPrimaryButtonReleased?.Invoke();
            }
        }
        public void OnRightSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightSecondaryButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightSecondaryButton?.Invoke(InputActionPhase.Canceled);
                onRightSecondaryButtonReleased?.Invoke();
            }
        }

        public void OnRightTriggerButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightTriggerButton?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightTriggerButton?.Invoke(InputActionPhase.Canceled);
                onRightTriggerButtonReleased?.Invoke();
            }
        }
        public void OnRightPrimaryAxisTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryAxisTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightPrimaryAxisTouch?.Invoke(InputActionPhase.Canceled);
                onRightPrimaryAxisTouchReleased?.Invoke();
            }
        }
        public void OnRightGrip(InputAction.CallbackContext context)
        {
            onRightGrip?.Invoke(context.ReadValue<float>());
        }
        public void OnRightTrigger(InputAction.CallbackContext context)
        {
            onRightTrigger?.Invoke(context.ReadValue<float>());
        }
        #endregion
    }

}