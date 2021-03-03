using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace XRInput
{
    [CreateAssetMenu(fileName = "XRInputSO", menuName = "XR/XR Input")]
    public class XRInputSO : ScriptableObject
    {
        [SerializeField] private XRInputEventsSO inputEvents;
        #region fields;
        public Vector3 headPosition { get; private set; }
        public Quaternion headRotation { get; private set; }
        public Vector3 leftPosition { get; private set; }
        public Quaternion leftRotation { get; private set; }
        public Vector2 leftJoystick { get; private set; }
        public bool leftJoystickClicked { get; private set; }
        public bool leftJoystickReleased { get; private set; }
        public bool leftGripButton { get; private set; }
        public bool leftGripButtonReleased { get; private set; }
        public bool leftPrimaryButton { get; private set; }
        public bool leftPrimaryButtonReleased { get; private set; }
        public bool leftSecondaryButton { get; private set; }
        public bool leftSecondaryButtonReleased { get; private set; }
        public bool leftTriggerButton { get; private set; }
        public bool leftTriggerButtonReleased { get; private set; }
        public bool leftTriggerTouch { get; private set; }
        public bool leftTriggerTouchReleased { get; private set; }
        public bool leftPrimaryButtonTouch { get; private set; }
        public bool leftPrimaryButtonTouchReleased { get; private set; }
        public bool leftJoystickTouch { get; private set; }
        public bool leftJoystickTouchReleased { get; private set; }

        public Vector3 rightPosition { get; private set; }
        public Quaternion rightRotation { get; private set; }
        public Vector2 rightJoystick { get; private set; }
        public bool rightJoystickClicked { get; private set; }
        public bool rightJoystickReleased { get; private set; }
        public bool rightGripButton { get; private set; }
        public bool rightGripButtonReleased { get; private set; }
        public bool rightPrimaryButton { get; private set; }
        public bool rightPrimaryButtonReleased { get; private set; }
        public bool rightSecondaryButton { get; private set; }
        public bool rightSecondaryButtonReleased { get; private set; }
        public bool rightTriggerButton { get; private set; }
        public bool rightTriggerButtonReleased { get; private set; }
        public bool rightTriggerTouch { get; private set; }
        public bool rightTriggerTouchReleased { get; private set; }
        public bool rightPrimaryButtonTouch { get; private set; }
        public bool rightPrimaryButtonTouchReleased { get; private set; }
        public bool rightJoystickTouch { get; private set; }
        public bool rightJoystickTouchReleased { get; private set; }
        #endregion

        private void OnEnable()
        {
           /* inputEvents.onHeadPosition += OnHeadPosition;
            inputEvents.onHeadRotation += OnHeadRotation;

            inputEvents.onLeftPosition += 
            inputEvents.onLeftRotation += 
            inputEvents.onLeftJoystick += 
            inputEvents.onLeftJoystickClicked += 
            inputEvents.onLeftJoystickReleased += 
            inputEvents.onLeftGripButton += 
            inputEvents.onLeftGripButtonReleased += 
            inputEvents.onLeftPrimaryButton += 
            inputEvents.onLeftPrimaryButtonReleased += 
            inputEvents.onLeftSecondaryButton += 
            inputEvents.onLeftSecondaryButtonReleased += 
            inputEvents.onLeftTriggerButton += 
            inputEvents.onLeftTriggerButtonReleased += 
            inputEvents.onLeftTriggerTouch += 
            inputEvents.onLeftTriggerTouchReleased += 
            inputEvents.onLeftPrimaryButtonTouch += 
            inputEvents.onLeftPrimaryButtonTouchReleased += 
            inputEvents.onLeftJoystickTouch += 
            inputEvents.onLeftJoystickTouchReleased += 

            inputEvents.onRightPosition += 
            inputEvents.onRightRotation += 
            inputEvents.onRightJoystick += 
            inputEvents.onRightJoystickClicked += 
            inputEvents.onRightJoystickReleased += 
            inputEvents.onRightGripButton += 
            inputEvents.onRightGripButtonReleased += 
            inputEvents.onRightPrimaryButton += 
            inputEvents.onRightPrimaryButtonReleased += 
            inputEvents.onRightSecondaryButton += 
            inputEvents.onRightSecondaryButtonReleased += 
            inputEvents.onRightTriggerButton += 
            inputEvents.onRightTriggerButtonReleased += 
            inputEvents.onRightTriggerTouch += 
            inputEvents.onRightTriggerTouchReleased += 
            inputEvents.onRightPrimaryButtonTouch += 
            inputEvents.onRightPrimaryButtonTouchReleased += 
            inputEvents.onRightJoystickTouch += 
            inputEvents.onRightJoystickTouchReleased += */
        }
        private void OnDisable()
        {
           
        }
       /* #region HMD
        void OnHeadPosition(Vector3 pos)
        {
            headPosition = pos;
        }

        void OnHeadRotation(Quaternion rot)
        {
            headRotation = rot;
        }
        #endregion

        #region leftController
        void OnLeftPosition(Vector3 pos)
        {
            leftPosition = pos;
        }
        void OnLeftRotation(Quaternion rot)
        {
            leftRotation = rot;
        }
        void OnLeftPrimaryAxis(Vector2 value)
        {
            leftJoystick = value;
        }
        bool prevLeftPrimaryAxisClicked;
        void OnLeftPrimaryAxisClicked()
        {
            if (!prevLeftPrimaryAxisClicked)
            {
                leftJoystickClicked = true;
            }
            prevLeftPrimaryAxisClicked = true;
        }
        void OnLeftJoystickReleased()
        {
            leftJoystickReleased = true;
        }
        void OnLeftGripButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftGripButton?.Invoke();
            }
            else if (context.canceled)
            {
                leftGripButtonReleased?.Invoke();
            }
        }

        void OnLeftPrimaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftPrimaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                leftPrimaryButtonReleased?.Invoke();
            }
        }
        void OnLeftSecondaryButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftSecondaryButton?.Invoke();
            }
            else if (context.canceled)
            {
                leftSecondaryButtonReleased?.Invoke();
            }
        }

        void OnLeftTriggerButton(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftTriggerButton?.Invoke();
            }
            else if (context.canceled)
            {
                leftTriggerButtonReleased?.Invoke();
            }
        }
        void OnLeftTriggerTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftTriggerTouch?.Invoke();
            }
            else if (context.canceled)
            {
                leftTriggerTouchReleased?.Invoke();
            }
        }
        void OnLeftPrimaryButtonTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftPrimaryButtonTouch?.Invoke();
            }
            else if (context.canceled)
            {
                leftPrimaryButtonTouchReleased?.Invoke();
            }
        }
        void OnLeftThumbstickTouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                leftJoystickTouch?.Invoke();
            }
            else if (context.canceled)
            {
                leftJoystickTouchReleased?.Invoke();
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
            onRightJoystick?.Invoke(context.ReadValue<Vector2>());
            Debug.Log("Input update");
        }
        void OnRightPrimaryAxisClicked(InputAction.CallbackContext context)
        {
            Debug.Log(context.phase);
            if (context.started)
            {
                onRightJoystickClicked?.Invoke();
            }
            else if (context.canceled)
            {
                onRightJoystickReleased?.Invoke();
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
                Debug.Log("RightPrimaryButton start");

            }
            else if (context.canceled)
            {
                Debug.Log("RightPrimaryButton end");

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
                onRightJoystickTouch?.Invoke();
            }
            else if (context.canceled)
            {
                onRightJoystickTouchReleased?.Invoke();
            }
        }
        #endregion*/
    }

}
