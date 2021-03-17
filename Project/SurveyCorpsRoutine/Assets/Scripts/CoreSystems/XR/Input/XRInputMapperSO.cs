using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static CoreSystems.XR.Input.XRInputMap;


namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMapperSO", menuName = "XR/Input/Mapper")]
    public class XRInputMapperSO : ScriptableObject
    {
        [SerializeField] XRInputEventsSO _inputEventsSO;
        [SerializeField] List<InputMapEnabledStatus> _InputMaps = new List<InputMapEnabledStatus>();

        private XRMappedInput<bool>[] _BoolInputs;
        private XRMappedInput<float>[] _FloatInputs;
        private XRMappedInput<Vector2>[] _Vector2Inputs;


        [System.Serializable]
        public class InputMapEnabledStatus
        {
            public XRInputMap map;
            public bool enabled;
        }
       
        private void OnEnable()
        {
            BindActions();
            InputSystem.onAfterUpdate += OnAfterUpdate;
        }
        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= OnAfterUpdate;
            UnbindActions();

        }
        

        void OnAfterUpdate()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                ResetRealeaseButtons();
           
        }
        /// <summary>
        /// Resets all values for actions triggered by buttons release
        /// </summary>
        void ResetRealeaseButtons()
        {
            ButtonPressed(XRInputButton.leftPrimaryButtonRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftSecondaryButtonRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftGripRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftTriggerRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickClickRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickUpRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickDownRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickRightRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickLeftRelease, 0, InputActionPhase.Canceled);

            ButtonPressed(XRInputButton.rightPrimaryButtonRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightSecondaryButtonRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightGripRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightTriggerRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickClickRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickUpRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickDownRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickRightRelease, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickLeftRelease, 0, InputActionPhase.Canceled);
        }
        void BindActions()
        {
            _inputEventsSO.onHeadPosition += OnHeadPosition;
            _inputEventsSO.onHeadRotation += OnHeadRotation;

            _inputEventsSO.onLeftPosition += OnLeftPosition;
            _inputEventsSO.onLeftRotation += OnLeftRotation;
            _inputEventsSO.onLeftJoystick += OnLeftJoystick;
            _inputEventsSO.onLeftGripButton += OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased += OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton += OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased += OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftJoystickClicked += OnLeftJoystickClicked;
            _inputEventsSO.onLeftJoystickReleased += OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton += OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased += OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton += OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased += OnLeftSecondaryButtonReleased;
            _inputEventsSO.onLeftGrip += OnLeftGrip;
            _inputEventsSO.onLeftTrigger += OnLeftTrigger;


            _inputEventsSO.onRightPosition += OnRightPosition;
            _inputEventsSO.onRightRotation += OnRightRotation;
            _inputEventsSO.onRightJoystick += OnRightJoystick;
            _inputEventsSO.onRightGripButton += OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased += OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton += OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased += OnRightTriggerButtonReleased;
            _inputEventsSO.onRightJoystickClicked += OnRightJoystickClicked;
            _inputEventsSO.onRightJoystickReleased += OnRightJoystickReleased;
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
            _inputEventsSO.onLeftJoystick -= OnLeftJoystick;
            _inputEventsSO.onLeftGripButton -= OnLeftGripButton;
            _inputEventsSO.onLeftGripButtonReleased -= OnLeftGripButtonReleased;
            _inputEventsSO.onLeftTriggerButton -= OnLeftTriggerButton;
            _inputEventsSO.onLeftTriggerButtonReleased -= OnLeftTriggerButtonReleased;
            _inputEventsSO.onLeftJoystickClicked -= OnLeftJoystickClicked;
            _inputEventsSO.onLeftJoystickReleased -= OnLeftJoystickReleased;
            _inputEventsSO.onLeftPrimaryButton -= OnLeftPrimaryButton;
            _inputEventsSO.onLeftPrimaryButtonReleased -= OnLeftPrimaryButtonReleased;
            _inputEventsSO.onLeftSecondaryButton -= OnLeftSecondaryButton;
            _inputEventsSO.onLeftSecondaryButtonReleased -= OnLeftSecondaryButtonReleased;

            _inputEventsSO.onLeftPosition -= OnRightPosition;
            _inputEventsSO.onLeftRotation -= OnRightRotation;
            _inputEventsSO.onRightJoystick -= OnRightJoystick;
            _inputEventsSO.onRightGripButton -= OnRightGripButton;
            _inputEventsSO.onRightGripButtonReleased -= OnRightGripButtonReleased;
            _inputEventsSO.onRightTriggerButton -= OnRightTriggerButton;
            _inputEventsSO.onRightTriggerButtonReleased -= OnRightTriggerButtonReleased;
            _inputEventsSO.onRightJoystickClicked -= OnRightJoystickClicked;
            _inputEventsSO.onRightJoystickReleased -= OnRightJoystickReleased;
            _inputEventsSO.onRightPrimaryButton -= OnRightPrimaryButton;
            _inputEventsSO.onRightPrimaryButtonReleased -= OnRightPrimaryButtonReleased;
            _inputEventsSO.onRightSecondaryButton -= OnRightSecondaryButton;
            _inputEventsSO.onRightSecondaryButtonReleased -= OnRightSecondaryButtonReleased;
        }

        void ButtonPressed(XRInputButton button, float value = 1, InputActionPhase phase = InputActionPhase.Started)
        {
            XRInputMap _processedInputMap;
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _processedInputMap = _InputMaps[j].map;

                    XRMappedInput<bool> boolInput;
                    _BoolInputs = _processedInputMap.GetBoolInputs();

                    for (int i = 0; i < _BoolInputs.Length; i++)
                    {
                        boolInput = _BoolInputs[i];
                        if (boolInput.inputButton == button)
                        {
                            if (phase == InputActionPhase.Started)
                            {
                                boolInput.SetValue(true);
                            }
                            else
                            {
                                boolInput.SetValue(false);
                            }
                            return;
                        }
                    }
                    XRMappedInput<float> floatInput;
                    _FloatInputs = _processedInputMap.GetFloatInputs();
                    for (int i = 0; i < _FloatInputs.Length; i++)
                    {
                        floatInput = _FloatInputs[i];
                        if (floatInput.inputButton == button)
                        {
                            if (phase == InputActionPhase.Started)
                            {
                                floatInput.SetValue(value);
                            }
                            else
                            {
                                floatInput.SetValue(0);
                            }
                            return;

                        }

                    }
                }
            }


        }
        void Axis2dMoved(XRInputButton button, Vector2 value)
        {
            XRMappedInput<Vector2> vector2Input;
            XRInputMap _processedInputMap;
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _processedInputMap = _InputMaps[j].map;
                    _Vector2Inputs = _processedInputMap.GetVector2Inputs();
                    for (int i = 0; i < _Vector2Inputs.Length; i++)
                    {
                        vector2Input = _Vector2Inputs[i];
                        if (vector2Input.inputButton == button)
                        {
                            vector2Input.SetValue(value);
                            return;
                        }

                    }
                }
            }
            
        }

        #region head
        void OnHeadPosition(Vector3 pos)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetHeadPos(pos);
                }
            } 
        }
        void OnHeadRotation(Quaternion rot)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetHeadRot(rot);
                }
            }
        }
        #endregion

        #region left
        void OnLeftPosition(Vector3 pos)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetLeftHandPos(pos);
                }
            }
        }
        void OnLeftRotation(Quaternion rot)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetLeftHandRot(rot);
                }
            }
        }

        Vector2 prevLeftJoystickValue = new Vector2(0, 0);
        Vector2 vectorZero = new Vector2(0, 0);

        void SetLeftJoystickZeroValues()
        {
            ButtonPressed(XRInputButton.leftJoystickUp, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickDown, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickLeft, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.leftJoystickRight, 0, InputActionPhase.Canceled);
        }
        void OnLeftJoystick(Vector2 value)
        {
            Axis2dMoved(XRInputButton.leftJoystick, value);
            if (value == vectorZero && prevLeftJoystickValue != vectorZero)
            {
                if (prevLeftJoystickValue.x > -0.7f && prevLeftJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevLeftJoystickValue.y > 0)
                    {
                        ButtonPressed(XRInputButton.leftJoystickUpRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        ButtonPressed(XRInputButton.leftJoystickDownRelease);
                        SetLeftJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        ButtonPressed(XRInputButton.leftJoystickRightRelease);
                        SetLeftJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        ButtonPressed(XRInputButton.leftJoystickLeftRelease);
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
                        ButtonPressed(XRInputButton.leftJoystickUp);
                        ButtonPressed(XRInputButton.leftJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickLeft, 0, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        ButtonPressed(XRInputButton.leftJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickDown);
                        ButtonPressed(XRInputButton.leftJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickLeft, 0, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevLeftJoystickValue.x > 0)
                    {
                        ButtonPressed(XRInputButton.leftJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickRight);
                        ButtonPressed(XRInputButton.leftJoystickLeft, 0, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        ButtonPressed(XRInputButton.leftJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.leftJoystickLeft);
                    }
                }
            }

            prevLeftJoystickValue = value;

        }
        void OnLeftGripButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.leftGripButton, 1, phase);
        }
        void OnLeftGripButtonReleased()
        {
            ButtonPressed(XRInputButton.leftGripRelease, 1);
        }
        void OnLeftTriggerButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.leftTriggerButton, 1, phase);
        }
        void OnLeftTriggerButtonReleased()
        {
            ButtonPressed(XRInputButton.leftTriggerRelease, 1);
        }
        void OnLeftJoystickClicked(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.leftJoystickClick, 1, phase);
        }
        void OnLeftJoystickReleased()
        {
            ButtonPressed(XRInputButton.leftJoystickClickRelease, 1);
        }
        void OnLeftPrimaryButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.leftPrimaryButton, 1, phase);
        }
        void OnLeftPrimaryButtonReleased()
        {
            ButtonPressed(XRInputButton.leftPrimaryButtonRelease, 1);
        }
        void OnLeftSecondaryButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.leftSecondaryButton, 1, phase);
        }
        void OnLeftSecondaryButtonReleased()
        {
            ButtonPressed(XRInputButton.leftSecondaryButtonRelease, 1);
        }
        void OnLeftGrip(float value)
        {
            ButtonPressed(XRInputButton.leftGrip, value);
        }
        void OnLeftTrigger(float value)
        {
            ButtonPressed(XRInputButton.leftTrigger, value);
        }
        #endregion

        #region right
        void OnRightPosition(Vector3 pos)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetRightHandPos(pos);
                }
            }
        }
        void OnRightRotation(Quaternion rot)
        {
            for (int j = 0; j < _InputMaps.Count; j++)
            {
                if (_InputMaps[j].enabled)
                {
                    _InputMaps[j].map.SetRightHandRot(rot);
                }
            }
        }

        Vector2 prevRightJoystickValue = new Vector2(0, 0);


        void SetRightJoystickZeroValues()
        {
            ButtonPressed(XRInputButton.rightJoystickUp, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickDown, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickLeft, 0, InputActionPhase.Canceled);
            ButtonPressed(XRInputButton.rightJoystickRight, 0, InputActionPhase.Canceled);
        }
        void OnRightJoystick(Vector2 value)
        {
            Axis2dMoved(XRInputButton.rightJoystick, value);
            if (value == vectorZero && prevRightJoystickValue != vectorZero)
            {
                if (prevRightJoystickValue.x > -0.7f && prevRightJoystickValue.x < 0.7f)
                {
                    //if prev value == joystickUp
                    if (prevRightJoystickValue.y > 0)
                    {
                        ButtonPressed(XRInputButton.rightJoystickUpRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickDown
                    else
                    {
                        ButtonPressed(XRInputButton.rightJoystickDownRelease);
                        SetRightJoystickZeroValues();
                    }

                }
                else
                {
                    //if prev value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        ButtonPressed(XRInputButton.rightJoystickRightRelease);
                        SetRightJoystickZeroValues();
                    }
                    //if prev value == joystickLeft
                    else
                    {
                        ButtonPressed(XRInputButton.rightJoystickLeftRelease);
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
                        ButtonPressed(XRInputButton.rightJoystickUp);
                        ButtonPressed(XRInputButton.rightJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickLeft, 0, InputActionPhase.Canceled);
                    }
                    //if value == joystickDown
                    else
                    {
                        ButtonPressed(XRInputButton.rightJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickDown);
                        ButtonPressed(XRInputButton.rightJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickLeft, 0, InputActionPhase.Canceled);
                    }

                }
                else
                {
                    //if value == joystickRight
                    if (prevRightJoystickValue.x > 0)
                    {
                        ButtonPressed(XRInputButton.rightJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickRight);
                        ButtonPressed(XRInputButton.rightJoystickLeft, 0, InputActionPhase.Canceled);
                    }
                    //if value == joystickLeft
                    else
                    {
                        ButtonPressed(XRInputButton.rightJoystickUp, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickDown, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickRight, 0, InputActionPhase.Canceled);
                        ButtonPressed(XRInputButton.rightJoystickLeft);
                    }
                }
            }

            prevRightJoystickValue = value;

        }
        void OnRightGripButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.rightGripButton, 1, phase);
        }
        void OnRightGripButtonReleased()
        {
            ButtonPressed(XRInputButton.rightGripRelease, 1);
        }
        void OnRightTriggerButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.rightTriggerButton, 1, phase);
        }
        void OnRightTriggerButtonReleased()
        {
            ButtonPressed(XRInputButton.rightTriggerRelease, 1);
        }
        void OnRightJoystickClicked(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.rightJoystickClick, 1, phase);
        }
        void OnRightJoystickReleased()
        {
            ButtonPressed(XRInputButton.rightJoystickClickRelease, 1);
        }
        void OnRightPrimaryButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.rightPrimaryButton, 1, phase);
        }
        void OnRightPrimaryButtonReleased()
        {
            ButtonPressed(XRInputButton.rightPrimaryButtonRelease, 1);
        }
        void OnRightSecondaryButton(InputActionPhase phase)
        {
            ButtonPressed(XRInputButton.rightSecondaryButton, 1, phase);
        }
        void OnRightSecondaryButtonReleased()
        {
            ButtonPressed(XRInputButton.rightSecondaryButtonRelease, 1);
        }
        void OnRightGrip(float value)
        {
            ButtonPressed(XRInputButton.rightGrip, value);
        }
        void OnRightTrigger(float value)
        {
            ButtonPressed(XRInputButton.rightTrigger, value);
        }
        #endregion
    }
}
