using CoreSystems.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMapperSO", menuName = "XR/Input/Mapper SO")]
    public class XRInputMapperSO : InputMapperSO<
        CoreSystems.XR.Input.XRInputTriggerBool,
        CoreSystems.XR.Input.XRInputTriggerFloat,
        CoreSystems.XR.Input.XRInputTriggerVector2,
        CoreSystems.XR.Input.XRInputTriggerVector3,
        CoreSystems.XR.Input.XRInputTriggerQuaternion>
    {
        [SerializeField] XRInputEventsSO _inputEventsSO;

        private float _floatActivationThreashold = 0.01f;

        private new void OnEnable()
        {
            //IMPORTANT to call base.OnEnable !!!
            CallBaseOnEnable();
            BindActions();
            InputSystem.onAfterUpdate += OnAfterUpdate;

        }
        protected override void CallBaseOnEnable()
        {
            base.OnEnable();
        }
        private void OnDisable()
        {
            UnbindActions();
            InputSystem.onAfterUpdate -= OnAfterUpdate;

        }
        void OnAfterUpdate()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                ResetRealeaseButtons();

        }
        /// <summary>
        /// Resets all values for actions triggered by inputTriggers release
        /// </summary>
        void ResetRealeaseButtons()
        {
            BoolInputTriggered(XRInputTriggerBool.leftPrimaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftSecondaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftGripRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftTriggerRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickClickRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickUpRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickDownRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickRightRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickLeftRelease, InputActionPhase.Canceled);

            BoolInputTriggered(XRInputTriggerBool.rightPrimaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightSecondaryButtonRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightGripRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightTriggerRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickClickRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickUpRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickDownRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickRightRelease, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickLeftRelease, InputActionPhase.Canceled);
        }

        void BindActions()
        {
            _inputEventsSO.onHeadPosition += OnHeadPosition;
            _inputEventsSO.onHeadRotation += OnHeadRotation;

            _inputEventsSO.onLeftPosition += OnLeftPosition;
            _inputEventsSO.onLeftRotation += OnLeftRotation;
            _inputEventsSO.onLeftPrimaryAxis += OnLeftJoystick;
            _inputEventsSO.onLeftGripButton += OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased += OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton += OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased += OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftPrimaryAxisClick += OnLeftJoystickClicked;
            _inputEventsSO.onLeftPrimaryAxisClickReleased += OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton += OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased += OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton += OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased += OnLeftSecondaryButtonReleased;
            _inputEventsSO.onLeftGrip += OnLeftGrip;
            _inputEventsSO.onLeftTrigger += OnLeftTrigger;


            _inputEventsSO.onRightPosition += OnRightPosition;
            _inputEventsSO.onRightRotation += OnRightRotation;
            _inputEventsSO.onRightPrimaryAxis += OnRightJoystick;
            _inputEventsSO.onRightGripButton += OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased += OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton += OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased += OnRightTriggerButtonReleased;
            _inputEventsSO.onRightPrimaryAxisClick += OnRightJoystickClicked;
            _inputEventsSO.onRightPrimaryAxisClickReleased += OnRightJoystickReleased;
            _inputEventsSO.onRightPrimaryButton += OnRightPrimaryButton;
            _inputEventsSO.onRightPrimaryButtonReleased += OnRightPrimaryButtonReleased;
            _inputEventsSO.onRightSecondaryButton += OnRightSecondaryButton;
            _inputEventsSO.onRightSecondaryButtonReleased += OnRightSecondaryButtonReleased;
            _inputEventsSO.onRightGrip += OnRightGrip;
            _inputEventsSO.onRightTrigger += OnRightTrigger;
        }
        void UnbindActions()
        {
            _inputEventsSO.onHeadPosition -= OnHeadPosition;
            _inputEventsSO.onHeadRotation -= OnHeadRotation;

            _inputEventsSO.onLeftPosition -= OnLeftPosition;
            _inputEventsSO.onLeftRotation -= OnLeftRotation;
            _inputEventsSO.onLeftPrimaryAxis -= OnLeftJoystick;
            _inputEventsSO.onLeftGripButton -= OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased -= OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton -= OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased -= OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftPrimaryAxisClick -= OnLeftJoystickClicked;
            _inputEventsSO.onLeftPrimaryAxisClickReleased -= OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton -= OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased -= OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton -= OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased -= OnLeftSecondaryButtonReleased;

            _inputEventsSO.onLeftPosition -= OnRightPosition;
            _inputEventsSO.onLeftRotation -= OnRightRotation;
            _inputEventsSO.onRightPrimaryAxis -= OnRightJoystick;
            _inputEventsSO.onRightGripButton -= OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased -= OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton -= OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased -= OnRightTriggerButtonReleased;
            _inputEventsSO.onRightPrimaryAxisClick -= OnRightJoystickClicked;
            _inputEventsSO.onRightPrimaryAxisClickReleased -= OnRightJoystickReleased;
            _inputEventsSO.onRightPrimaryButton -= OnRightPrimaryButton;
            _inputEventsSO.onRightPrimaryButtonReleased -= OnRightPrimaryButtonReleased;
            _inputEventsSO.onRightSecondaryButton -= OnRightSecondaryButton;
            _inputEventsSO.onRightSecondaryButtonReleased -= OnRightSecondaryButtonReleased;
        }
        #region head
        void OnHeadPosition(Vector3 pos)
        {
            Vector3InputTriggered(XRInputTriggerVector3.headPos, pos);
        }
        void OnHeadRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.headRot, rot);
        }
        #endregion

        #region left
        void OnLeftPosition(Vector3 pos)
        {

            Vector3InputTriggered(XRInputTriggerVector3.leftHandPos, pos);
        }
        void OnLeftRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.leftHandRot, rot);
        }

        Vector2 prevLeftJoystickValue = new Vector2(0, 0);
        Vector2 vectorZero = new Vector2(0, 0);

        void SetLeftJoystickZeroValues()
        {
            BoolInputTriggered(XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
        }
        void OnLeftJoystick(Vector2 value)
        {
            if (value.magnitude > _floatActivationThreashold)
            {
                Vector2InputTriggered(XRInputTriggerVector2.leftJoystick, value);
            }
            else
            {
                Vector2InputTriggered(XRInputTriggerVector2.leftJoystick, value, InputActionPhase.Canceled);
            }
            if (value == vectorZero && prevLeftJoystickValue != vectorZero)
            {
                if (prevLeftJoystickValue.x > -0.7f && prevLeftJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevLeftJoystickValue.y > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickUpRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickDownRelease);
                        SetLeftJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickRightRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickLeftRelease);
                        SetLeftJoystickZeroValues();
                    }
                }


            }
            else
            {
                if (value.x > -0.7f && value.x < 0.7f)
                {
                    //if value == joystickUp
                    if (prevLeftJoystickValue.y > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickUp);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickDown);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickRight);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.leftJoystickLeft);
                    }
                }
            }

            prevLeftJoystickValue = value;

        }
        void OnLeftGripButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.leftGripButton, phase);
        }
        void OnLeftGripButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.leftGripRelease);
        }
        void OnLeftTriggerButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.leftTriggerButton, phase);
        }
        void OnLeftTriggerButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.leftTriggerRelease);
        }
        void OnLeftJoystickClicked(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.leftJoystickClick, phase);
        }
        void OnLeftJoystickReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.leftJoystickClickRelease);
        }
        void OnLeftPrimaryButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.leftPrimaryButton, phase);
        }
        void OnLeftPrimaryButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.leftPrimaryButtonRelease);
        }
        void OnLeftSecondaryButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.leftSecondaryButton, phase);
        }
        void OnLeftSecondaryButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.leftSecondaryButtonRelease);
        }
        void OnLeftGrip(float value)
        {
            if (value > _floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.leftGrip, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.leftGrip, value, InputActionPhase.Canceled);
            }
        }
        void OnLeftTrigger(float value)
        {
            if (value > _floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.leftTrigger, value);

            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.leftTrigger, value, InputActionPhase.Canceled);

            }
        }
        #endregion

        #region right
        void OnRightPosition(Vector3 pos)
        {
            Vector3InputTriggered(XRInputTriggerVector3.rightHandPos, pos);
        }
        void OnRightRotation(Quaternion rot)
        {
            QuaternionInputTriggered(XRInputTriggerQuaternion.rightHandRot, rot);
        }

        Vector2 prevRightJoystickValue = new Vector2(0, 0);


        void SetRightJoystickZeroValues()
        {
            BoolInputTriggered(XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
            BoolInputTriggered(XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
        }
        void OnRightJoystick(Vector2 value)
        {
            if (value.magnitude > _floatActivationThreashold)
            {
                Vector2InputTriggered(XRInputTriggerVector2.rightJoystick, value);
            }
            else
            {
                Vector2InputTriggered(XRInputTriggerVector2.rightJoystick, value, InputActionPhase.Canceled);
            }

            if (value == vectorZero && prevRightJoystickValue != vectorZero)
            {
                if (prevRightJoystickValue.x > -0.7f && prevRightJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevRightJoystickValue.y > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickUpRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickDownRelease);
                        SetRightJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickRightRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickLeftRelease);
                        SetRightJoystickZeroValues();
                    }
                }


            }
            else
            {
                if (value.x > -0.7f && value.x < 0.7f)
                {
                    //if value == joystickUp
                    if (prevRightJoystickValue.y > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickUp);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickDown);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickRight);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickLeft, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickUp, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickDown, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickRight, InputActionPhase.Canceled);
                        BoolInputTriggered(XRInputTriggerBool.rightJoystickLeft);
                    }
                }
            }

            prevRightJoystickValue = value;

        }
        void OnRightGripButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.rightGripButton, phase);
        }
        void OnRightGripButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.rightGripRelease);
        }
        void OnRightTriggerButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.rightTriggerButton, phase);
        }
        void OnRightTriggerButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.rightTriggerRelease);
        }
        void OnRightJoystickClicked(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.rightJoystickClick, phase);
        }
        void OnRightJoystickReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.rightJoystickClickRelease);
        }
        void OnRightPrimaryButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.rightPrimaryButton, phase);
        }
        void OnRightPrimaryButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.rightPrimaryButtonRelease);
        }
        void OnRightSecondaryButton(InputActionPhase phase)
        {
            BoolInputTriggered(XRInputTriggerBool.rightSecondaryButton, phase);
        }
        void OnRightSecondaryButtonReleased()
        {
            BoolInputTriggered(XRInputTriggerBool.rightSecondaryButtonRelease);
        }
        void OnRightGrip(float value)
        {
            if (value > _floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.rightGrip, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.rightGrip, value, InputActionPhase.Canceled);
            }
        }
        void OnRightTrigger(float value)
        {
            if (value > _floatActivationThreashold)
            {
                FloatInputTriggered(XRInputTriggerFloat.rightTrigger, value);
            }
            else
            {
                FloatInputTriggered(XRInputTriggerFloat.rightTrigger, value, InputActionPhase.Canceled);
            }
        }


        #endregion
    }
}

