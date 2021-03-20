using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoreSystems.XR.Input
{
    internal interface IXRActionReceiver
    {
        void SubsribeCallbacks(XR_InputActions inputActions);
    }

    [CreateAssetMenu(fileName = "XRInputEventsSO", menuName = "XR/Input/XR Input Events")]
    public class XRInputEventsSO_Old : ScriptableObject
    {
        [SerializeField] private XR_InputActions inputActions;
        private HMDInput HMDInput;
        private LeftControllerInput leftControllerInput;
        private RightControllerInput rightControllerInput;

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
        public event UnityAction<InputActionPhase> onLeftTriggerTouch;
        public event UnityAction<InputActionPhase> onLeftPrimaryButtonTouch;
        public event UnityAction<InputActionPhase> onLeftPrimaryAxisTouch;
        public event UnityAction onLeftPrimaryAxisReleased;
        public event UnityAction onLeftGripButtonReleased;
        public event UnityAction onLeftPrimaryButtonReleased;
        public event UnityAction onLeftSecondaryButtonReleased;
        public event UnityAction onLeftTriggerButtonReleased;
        public event UnityAction onLeftTriggerTouchReleased;
        public event UnityAction onLeftPrimaryButtonTouchReleased;
        public event UnityAction onLeftPrimatyAxisTouchReleased;
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
        public event UnityAction<InputActionPhase> onRightTriggerTouch;
        public event UnityAction<InputActionPhase> onRightPrimaryButtonTouch;
        public event UnityAction<InputActionPhase> onRightPrimaryAxisTouch;
        public event UnityAction onRightPrimaryAxisReleased;
        public event UnityAction onRightGripButtonReleased;
        public event UnityAction onRightPrimaryButtonReleased;
        public event UnityAction onRightSecondaryButtonReleased;
        public event UnityAction onRightTriggerButtonReleased;
        public event UnityAction onRightTriggerTouchReleased;
        public event UnityAction onRightPrimaryButtonTouchReleased;
        public event UnityAction onRightPrimaryAxisTouchReleased;
        public event UnityAction<float> onRightGrip;
        public event UnityAction<float> onRightTrigger;

        private void Awake()
        {

        }
        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new XR_InputActions();
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
            leftControllerInput.onPrimaryAxisClick += OnLeftPrimaryAxisClick;
            leftControllerInput.onGripButton += OnLeftGripButton;
            leftControllerInput.onPrimaryButton += OnLeftPrimaryButton;
            leftControllerInput.onSecondaryButton += OnLeftSecondaryButton;
            leftControllerInput.onTriggerButton += OnLeftTriggerButton;
            leftControllerInput.onTriggerTouch += OnLeftTriggerTouch;
            leftControllerInput.onPrimaryButtonTouch += OnLeftPrimaryButtonTouch;
            leftControllerInput.onPrimaryAxisTouch += OnLeftPrimaryAxisTouch;
            leftControllerInput.onGrip += OnLeftGrip;
            leftControllerInput.onTrigger += OnLeftTrigger;

            rightControllerInput.onPosition += OnRightPosition;
            rightControllerInput.onRotation += OnRightRotation;
            rightControllerInput.onPrimaryAxis += OnRightPrimaryAxis;
            rightControllerInput.onPrimaryAxisClick += OnRightPrimaryAxisClick;
            rightControllerInput.onGripButton += OnRightGripButton;
            rightControllerInput.onPrimaryButton += OnRightPrimaryButton;
            rightControllerInput.onSecondaryButton += OnRightSecondaryButton;
            rightControllerInput.onTriggerButton += OnRightTriggerButton;
            rightControllerInput.onTriggerTouch += OnRightTriggerTouch;
            rightControllerInput.onPrimaryButtonTouch += OnRightPrimaryButtonTouch;
            rightControllerInput.onThumbstickTouch += OnRightPrimaryAxisTouch;
            rightControllerInput.onGrip += OnRightGrip;
            rightControllerInput.onTrigger += OnRightTrigger;
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
            leftControllerInput.onPrimaryAxisClick -= OnLeftPrimaryAxisClick;
            leftControllerInput.onGripButton -= OnLeftGripButton;
            leftControllerInput.onPrimaryButton -= OnLeftPrimaryButton;
            leftControllerInput.onSecondaryButton -= OnLeftSecondaryButton;
            leftControllerInput.onTriggerButton -= OnLeftTriggerButton;
            leftControllerInput.onTriggerTouch -= OnLeftTriggerTouch;
            leftControllerInput.onPrimaryButtonTouch -= OnLeftPrimaryButtonTouch;
            leftControllerInput.onPrimaryAxisTouch -= OnLeftPrimaryAxisTouch;
            leftControllerInput.onGrip -= OnLeftGrip;
            leftControllerInput.onTrigger -= OnLeftTrigger;

            rightControllerInput.onPosition -= OnRightPosition;
            rightControllerInput.onRotation -= OnRightRotation;
            rightControllerInput.onPrimaryAxis -= OnRightPrimaryAxis;
            rightControllerInput.onPrimaryAxisClick -= OnRightPrimaryAxisClick;
            rightControllerInput.onGripButton -= OnRightGripButton;
            rightControllerInput.onPrimaryButton -= OnRightPrimaryButton;
            rightControllerInput.onSecondaryButton -= OnRightSecondaryButton;
            rightControllerInput.onTriggerButton -= OnRightTriggerButton;
            rightControllerInput.onTriggerTouch -= OnRightTriggerTouch;
            rightControllerInput.onPrimaryButtonTouch -= OnRightPrimaryButtonTouch;
            rightControllerInput.onThumbstickTouch -= OnRightPrimaryAxisTouch;
            rightControllerInput.onGrip -= OnRightGrip;
            rightControllerInput.onTrigger -= OnRightTrigger;

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
        void OnLeftPrimaryAxisClick(InputAction.CallbackContext context)
        {
            Debug.Log(context.phase);
            if (context.started)
            {
                onLeftPrimaryAxisClick?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryAxisClick?.Invoke(InputActionPhase.Canceled);
                onLeftPrimaryAxisReleased?.Invoke();
            }
        }
        void OnLeftGripButton(InputAction.CallbackContext context)
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

        void OnLeftPrimaryButton(InputAction.CallbackContext context)
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
        void OnLeftSecondaryButton(InputAction.CallbackContext context)
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

        void OnLeftTriggerButton(InputAction.CallbackContext context)
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
        void OnLeftTriggerTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftTriggerTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftTriggerTouch?.Invoke(InputActionPhase.Canceled);
                onLeftTriggerTouchReleased?.Invoke();
            }
        }
        void OnLeftPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryButtonTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryButtonTouch?.Invoke(InputActionPhase.Canceled);
                onLeftPrimaryButtonTouchReleased?.Invoke();
            }
        }
        void OnLeftPrimaryAxisTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onLeftPrimaryAxisTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onLeftPrimaryAxisTouch?.Invoke(InputActionPhase.Canceled);
                onLeftPrimatyAxisTouchReleased?.Invoke();
            }
        }
        void OnLeftGrip(InputAction.CallbackContext context)
        {
            onLeftGrip?.Invoke(context.ReadValue<float>());
        }
        void OnLeftTrigger(InputAction.CallbackContext context)
        {
            onLeftTrigger?.Invoke(context.ReadValue<float>());
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
        void OnRightPrimaryAxisClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryAxisClick?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightPrimaryAxisClick?.Invoke(InputActionPhase.Canceled);
                onRightPrimaryAxisReleased?.Invoke();
            }
        }
        void OnRightGripButton(InputAction.CallbackContext context)
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

        void OnRightPrimaryButton(InputAction.CallbackContext context)
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
        void OnRightSecondaryButton(InputAction.CallbackContext context)
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

        void OnRightTriggerButton(InputAction.CallbackContext context)
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
        void OnRightTriggerTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightTriggerTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightTriggerTouch?.Invoke(InputActionPhase.Canceled);
                onRightTriggerTouchReleased?.Invoke();
            }
        }
        void OnRightPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onRightPrimaryButtonTouch?.Invoke(InputActionPhase.Started);
            }
            else if (context.canceled)
            {
                onRightPrimaryButtonTouch?.Invoke(InputActionPhase.Canceled);
                onRightPrimaryButtonTouchReleased?.Invoke();
            }
        }
        void OnRightPrimaryAxisTouch(InputAction.CallbackContext context)
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
        void OnRightGrip(InputAction.CallbackContext context)
        {
            onRightGrip?.Invoke(context.ReadValue<float>());
        }
        void OnRightTrigger(InputAction.CallbackContext context)
        {
            onRightTrigger?.Invoke(context.ReadValue<float>());
        }
        #endregion
    }

}