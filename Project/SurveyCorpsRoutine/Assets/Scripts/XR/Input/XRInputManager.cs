using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.XR;

namespace XRInput
{
    internal interface IXRActionReceiver
    {
        void SubsribeCallbacks(XRInputActions inputActions);
    }

    [DisallowMultipleComponent]
    public class XRInputManager : MonoBehaviour
    {
        public static XRInputManager i;
        
        [SerializeField] private XRInputActions inputActions;
        private HMDInput HMDInput;
        private LeftControllerInput leftControllerInput;
        private RightControllerInput rightControllerInput;

        public event UnityAction<Vector3> onHeadPosition;
        public event UnityAction<Quaternion> onHeadRotation;

        public event UnityAction<Vector3> onLeftPosition;
        public event UnityAction<Quaternion> onLeftRotation;
        public event UnityAction<Vector2> onLeftPrimaryAxis;
        public event UnityAction onLeftPrimaryAxisClicked;
        public event UnityAction onLeftPrimaryAxisReleased;
        public event UnityAction onLeftGripButton;
        public event UnityAction onLeftGripButtonReleased;
        public event UnityAction onLeftPrimaryButton;
        public event UnityAction onLeftPrimaryButtonReleased;
        public event UnityAction onLeftSecondaryButton;
        public event UnityAction onLeftSecondaryButtonReleased;
        public event UnityAction onLeftTriggerButton;
        public event UnityAction onLeftTriggerButtonReleased;
        public event UnityAction onLeftTriggerTouch;
        public event UnityAction onLeftTriggerTouchReleased;
        public event UnityAction onLeftPrimaryButtonTouch;
        public event UnityAction onLeftPrimaryButtonTouchReleased;
        public event UnityAction onLeftThumbstickTouch;
        public event UnityAction onLeftThumbstickTouchReleased;

        public event UnityAction<Vector3> onRightPosition;
        public event UnityAction<Quaternion> onRightRotation;
        public event UnityAction<Vector2> onRightPrimaryAxis;
        public event UnityAction onRightPrimaryAxisClicked;
        public event UnityAction onRightPrimaryAxisReleased;
        public event UnityAction onRightGripButton;
        public event UnityAction onRightGripButtonReleased;
        public event UnityAction onRightPrimaryButton;
        public event UnityAction onRightPrimaryButtonReleased;
        public event UnityAction onRightSecondaryButton;
        public event UnityAction onRightSecondaryButtonReleased;
        public event UnityAction onRightTriggerButton;
        public event UnityAction onRightTriggerButtonReleased;
        public event UnityAction onRightTriggerTouch;
        public event UnityAction onRightTriggerTouchReleased;
        public event UnityAction onRightPrimaryButtonTouch;
        public event UnityAction onRightPrimaryButtonTouchReleased;
        public event UnityAction onRightThumbstickTouch;
        public event UnityAction onRightThumbstickTouchReleased;

        private void Awake()
        {
            if (i == null)
            {
                i = this;
            }
            else
            {
                Destroy(this);
                LogHelper.LogDeletedDuplicateSingletonComponent(
                    this, i.gameObject);
            }
        }
        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new XRInputActions();
            }
            if (HMDInput == null)
            {
                HMDInput = new HMDInput();
                leftControllerInput = new LeftControllerInput();
                rightControllerInput = new RightControllerInput();
            }

            HMDInput.SubsribeCallbacks(inputActions);
            leftControllerInput.SubsribeCallbacks(inputActions);
            rightControllerInput.SubsribeCallbacks(inputActions);
            inputActions.Enable();


            HMDInput.onPosition += OnHeadPosition;
            HMDInput.onRotation += OnHeadRotation;

            leftControllerInput.onPosition += OnLeftPosition;
            leftControllerInput.onRotation += OnLeftRotation;
            leftControllerInput.onPrimaryAxis += OnLeftPrimaryAxis;
            leftControllerInput.onPrimaryAxisClicked += OnLeftPrimaryAxisClicked;
            leftControllerInput.onGripButton += OnLeftGripButton;
            leftControllerInput.onPrimaryButton += OnLeftPrimaryButton;
            leftControllerInput.onSecondaryButton += OnLeftSecondaryButton;
            leftControllerInput.onTriggerButton += OnLeftTriggerButton;
            leftControllerInput.onTriggerTouch += OnLeftTriggerTouch;
            leftControllerInput.onPrimaryButtonTouch += OnLeftPrimaryButtonTouch;
            leftControllerInput.onThumbstickTouch += OnLeftThumbstickTouch;

            rightControllerInput.onPosition += OnRightPosition;
            rightControllerInput.onRotation += OnRightRotation;
            rightControllerInput.onPrimaryAxis += OnRightPrimaryAxis;
            rightControllerInput.onPrimaryAxisClicked += OnRightPrimaryAxisClicked;
            rightControllerInput.onGripButton += OnRightGripButton;
            rightControllerInput.onPrimaryButton += OnRightPrimaryButton;
            rightControllerInput.onSecondaryButton += OnRightSecondaryButton;
            rightControllerInput.onTriggerButton += OnRightTriggerButton;
            rightControllerInput.onTriggerTouch += OnRightTriggerTouch;
            rightControllerInput.onPrimaryButtonTouch += OnRightPrimaryButtonTouch;
            rightControllerInput.onThumbstickTouch += OnRightThumbstickTouch;
        }
        private void OnDisable()
        {
            if (HMDInput == null)
            {
                return;
            }

            HMDInput.onPosition -= OnHeadPosition;
            HMDInput.onRotation -= OnHeadRotation;

            leftControllerInput.onPosition -= OnLeftPosition;
            leftControllerInput.onRotation -= OnLeftRotation;
            leftControllerInput.onPrimaryAxis -= OnLeftPrimaryAxis;
            leftControllerInput.onPrimaryAxisClicked -= OnLeftPrimaryAxisClicked;
            leftControllerInput.onGripButton -= OnLeftGripButton;
            leftControllerInput.onPrimaryButton -= OnLeftPrimaryButton;
            leftControllerInput.onSecondaryButton -= OnLeftSecondaryButton;
            leftControllerInput.onTriggerButton -= OnLeftTriggerButton;
            leftControllerInput.onTriggerTouch -= OnLeftTriggerTouch;
            leftControllerInput.onPrimaryButtonTouch -= OnLeftPrimaryButtonTouch;
            leftControllerInput.onThumbstickTouch -= OnLeftThumbstickTouch;

            rightControllerInput.onPosition -= OnRightPosition;
            rightControllerInput.onRotation -= OnRightRotation;
            rightControllerInput.onPrimaryAxis -= OnRightPrimaryAxis;
            rightControllerInput.onPrimaryAxisClicked -= OnRightPrimaryAxisClicked;
            rightControllerInput.onGripButton -= OnRightGripButton;
            rightControllerInput.onPrimaryButton -= OnRightPrimaryButton;
            rightControllerInput.onSecondaryButton -= OnRightSecondaryButton;
            rightControllerInput.onTriggerButton -= OnRightTriggerButton;
            rightControllerInput.onTriggerTouch -= OnRightTriggerTouch;
            rightControllerInput.onPrimaryButtonTouch -= OnRightPrimaryButtonTouch;
            rightControllerInput.onThumbstickTouch -= OnRightThumbstickTouch;

            inputActions.Disable();

        }

        #region HMD
        void OnHeadPosition(InputAction.CallbackContext context)
        {
            onHeadPosition?.Invoke(context.ReadValue<Vector3>());
        }

        void OnHeadRotation(InputAction.CallbackContext context)
        {
            onHeadRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        #endregion

        #region leftController
        void OnLeftPosition(InputAction.CallbackContext context)
        {
            onLeftPosition?.Invoke(context.ReadValue<Vector3>());
        }
        void OnLeftRotation(InputAction.CallbackContext context)
        {
            onLeftRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        void OnLeftPrimaryAxis(InputAction.CallbackContext context)
        {
            onLeftPrimaryAxis?.Invoke(context.ReadValue<Vector2>());
        }
        void OnLeftPrimaryAxisClicked(InputAction.CallbackContext context)
        {
            Debug.Log(context.phase);
            if (context.started)
            {
                onLeftPrimaryAxisClicked?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftPrimaryAxisReleased?.Invoke();
            }
        }
        void OnLeftGripButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftGripButton?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftGripButtonReleased?.Invoke();
            }
        }

        void OnLeftPrimaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftPrimaryButtonReleased?.Invoke();
            }
        }
        void OnLeftSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftSecondaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftSecondaryButtonReleased?.Invoke();
            }
        }

        void OnLeftTriggerButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftTriggerButton?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftTriggerButtonReleased?.Invoke();
            }
        }
        void OnLeftTriggerTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftTriggerTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftTriggerTouchReleased?.Invoke();
            }
        }
        void OnLeftPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryButtonTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftPrimaryButtonTouchReleased?.Invoke();
            }
        }
        void OnLeftThumbstickTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftThumbstickTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onLeftThumbstickTouchReleased?.Invoke();
            }
        }
        #endregion

        #region rightController
        void OnRightPosition(InputAction.CallbackContext context)
        {
            onRightPosition?.Invoke(context.ReadValue<Vector3>());
        }
        void OnRightRotation(InputAction.CallbackContext context)
        {
            onRightRotation?.Invoke(context.ReadValue<Quaternion>());
        }
        void OnRightPrimaryAxis(InputAction.CallbackContext context)
        {
            onRightPrimaryAxis?.Invoke(context.ReadValue<Vector2>());
        }
        void OnRightPrimaryAxisClicked(InputAction.CallbackContext context)
        {
            Debug.Log(context.phase);
            if (context.started)
            {
                onRightPrimaryAxisClicked?.Invoke();
            }
            else if (context.canceled)
            {
                onRightPrimaryAxisReleased?.Invoke();
            }
        }
        void OnRightGripButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightGripButton?.Invoke();
            }
            else if (context.canceled)
            {
                onRightGripButtonReleased?.Invoke();
            }
        }

        void OnRightPrimaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                onRightPrimaryButtonReleased?.Invoke();
            }
        }
        void OnRightSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightSecondaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                onRightSecondaryButtonReleased?.Invoke();
            }
        }

        void OnRightTriggerButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightTriggerButton?.Invoke();
            }
            else if (context.canceled)
            {
                onRightTriggerButtonReleased?.Invoke();
            }
        }
        void OnRightTriggerTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightTriggerTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onRightTriggerTouchReleased?.Invoke();
            }
        }
        void OnRightPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryButtonTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onRightPrimaryButtonTouchReleased?.Invoke();
            }
        }
        void OnRightThumbstickTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightThumbstickTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onRightThumbstickTouchReleased?.Invoke();
            }
        }
        #endregion
    }

}