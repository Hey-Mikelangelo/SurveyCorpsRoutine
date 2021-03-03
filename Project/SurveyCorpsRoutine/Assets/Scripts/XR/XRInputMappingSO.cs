using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using XRInput;

[CreateAssetMenu(fileName = "XRInputMappingSO", menuName = "XR/Input/XR Input Mapping")]
public class XRInputMappingSO : ScriptableObject
{
    [SerializeField] XRInputMapSO _inputMap;
    [SerializeField] XRInputEventsSO _inputEvents;
    public XRInputEventsSO inputEvents
    {
        get
        {
            return _inputEvents;
        }
        set
        {
            UnbindActions();
            _inputEvents = value;
            BindActions();
        }
    }
    public XRInputMapSO inputMap
    {
        get
        {
            return _inputMap;
        }
        set
        {
            _inputMap = value;
        }
    }

    public Vector2 joystickMoveValue;
    public bool jump;
    public float sprint;
    public bool rotateBack;
    public float rotateRight;
    public float rotateLeft;

    public event UnityAction onRotateBack;

    private void OnEnable()
    {
        BindActions();
    }
    private void OnDisable()
    {
        UnbindActions();
    }
    private void Update()
    {
        
    }
    void BindActions()
    {
        _inputEvents.onLeftJoystick += OnLeftJoystick;
        _inputEvents.onLeftGripButton += OnLeftGripButton;
        _inputEvents.onLeftGripButtonReleased += OnLeftGripButtonReleased;
        _inputEvents.onLeftTriggerButton += OnLeftTriggerButton;
        _inputEvents.onLeftTriggerButtonReleased += OnLeftTriggerButtonReleased;
        _inputEvents.onLeftJoystickClicked += OnLeftJoystickClicked;
        _inputEvents.onLeftJoystickReleased += OnLeftJoystickReleased;
        _inputEvents.onLeftPrimaryButton += OnLeftPrimaryButton;
        _inputEvents.onLeftPrimaryButtonReleased += OnLeftPrimaryButtonReleased;
        _inputEvents.onLeftSecondaryButton += OnLeftSecondaryButton;
        _inputEvents.onLeftSecondaryButtonReleased += OnLeftSecondaryButtonReleased;

        _inputEvents.onRightJoystick += OnRightJoystick;
        _inputEvents.onRightGripButton += OnRightGripButton;
        _inputEvents.onRightGripButtonReleased += OnRightGripButtonReleased;
        _inputEvents.onRightTriggerButton += OnRightTriggerButton;
        _inputEvents.onRightTriggerButtonReleased += OnRightTriggerButtonReleased;
        _inputEvents.onRightJoystickClicked += OnRightJoystickClicked;
        _inputEvents.onRightJoystickReleased += OnRightJoystickReleased;
        _inputEvents.onRightPrimaryButton += OnRightPrimaryButton;
        _inputEvents.onRightPrimaryButtonReleased += OnRightPrimaryButtonReleased;
        _inputEvents.onRightSecondaryButton += OnRightSecondaryButton;
        _inputEvents.onRightSecondaryButtonReleased += OnRightSecondaryButtonReleased;
    }
    void UnbindActions()
    {
        _inputEvents.onLeftJoystick -= OnLeftJoystick;
        _inputEvents.onLeftGripButton -= OnLeftGripButton;
        _inputEvents.onLeftGripButtonReleased -= OnLeftGripButtonReleased;
        _inputEvents.onLeftTriggerButton -= OnLeftTriggerButton;
        _inputEvents.onLeftTriggerButtonReleased -= OnLeftTriggerButtonReleased;
        _inputEvents.onLeftJoystickClicked -= OnLeftJoystickClicked;
        _inputEvents.onLeftJoystickReleased -= OnLeftJoystickReleased;
        _inputEvents.onLeftPrimaryButton -= OnLeftPrimaryButton;
        _inputEvents.onLeftPrimaryButtonReleased -= OnLeftPrimaryButtonReleased;
        _inputEvents.onLeftSecondaryButton -= OnLeftSecondaryButton;
        _inputEvents.onLeftSecondaryButtonReleased -= OnLeftSecondaryButtonReleased;

        _inputEvents.onRightJoystick -= OnRightJoystick;
        _inputEvents.onRightGripButton -= OnRightGripButton;
        _inputEvents.onRightGripButtonReleased -= OnRightGripButtonReleased;
        _inputEvents.onRightTriggerButton -= OnRightTriggerButton;
        _inputEvents.onRightTriggerButtonReleased -= OnRightTriggerButtonReleased;
        _inputEvents.onRightJoystickClicked -= OnRightJoystickClicked;
        _inputEvents.onRightJoystickReleased -= OnRightJoystickReleased;
        _inputEvents.onRightPrimaryButton -= OnRightPrimaryButton;
        _inputEvents.onRightPrimaryButtonReleased -= OnRightPrimaryButtonReleased;
        _inputEvents.onRightSecondaryButton -= OnRightSecondaryButton;
        _inputEvents.onRightSecondaryButtonReleased -= OnRightSecondaryButtonReleased;
    }

    void ButtonPressed(XRInputButton button, float value = 1, InputActionPhase phase = InputActionPhase.Started)
    {
        if (button == _inputMap.jumpButton)
        {
            if(phase == InputActionPhase.Started)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }
        }
        else if (button == _inputMap.rotateLeftButton)
        {
            if (phase == InputActionPhase.Started)
            {
                rotateLeft = value;
            }
            else
            {
                rotateLeft = 0;
            }
        }
        else if (button == _inputMap.rotateRightButton)
        {
            if (phase == InputActionPhase.Started)
            {
                rotateRight = value;
            }
            else if(phase == InputActionPhase.Canceled)
            {
                rotateRight = 0;
            }
        }
        else if (button == _inputMap.rotateBackButton)
        {
            if (phase == InputActionPhase.Started)
            {
                rotateBack = true;
                onRotateBack?.Invoke();
            }
            else
            {
                rotateBack = false;
            }
        }
        else if (button == _inputMap.sprintButton)
        {
            if (phase == InputActionPhase.Started)
            {
                sprint = value;
            }
            else
            {
                sprint = 0;
            }
        }
    }
    bool JoystickMoved(XRInputMapSO.Hand joystickSide, Vector2 value)
    {
        if (joystickSide == _inputMap.movementJoystick)
        {
            joystickMoveValue = value;
            return true;
        }
        return false;
    }

    #region left
    Vector2 prevLeftJoystickValue;
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
        bool isMovementJoystick = JoystickMoved(XRInputMapSO.Hand.left, value);
        if (isMovementJoystick)
        {
            return;
        }
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
        ButtonPressed(XRInputButton.leftGrip, 1, phase);
    }
    void OnLeftGripButtonReleased()
    {
        ButtonPressed(XRInputButton.leftGripRelease, 1);
    }
    void OnLeftTriggerButton(InputActionPhase phase)
    {
        ButtonPressed(XRInputButton.leftTrigger, 1, phase);
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
    #endregion


    #region right
    Vector2 prevRightJoystickValue;

    void SetRightJoystickZeroValues()
    {
        ButtonPressed(XRInputButton.rightJoystickUp, 0, InputActionPhase.Canceled);
        ButtonPressed(XRInputButton.rightJoystickDown, 0, InputActionPhase.Canceled);
        ButtonPressed(XRInputButton.rightJoystickLeft, 0, InputActionPhase.Canceled);
        ButtonPressed(XRInputButton.rightJoystickRight, 0, InputActionPhase.Canceled);
    }
    void OnRightJoystick(Vector2 value)
    {
        bool isMovementJoystick = JoystickMoved(XRInputMapSO.Hand.right, value);
        if (isMovementJoystick)
        {
            return;
        }
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
        ButtonPressed(XRInputButton.rightGrip, 1, phase);
    }
    void OnRightGripButtonReleased()
    {
        ButtonPressed(XRInputButton.rightGripRelease, 1);
    }
    void OnRightTriggerButton(InputActionPhase phase)
    {
        ButtonPressed(XRInputButton.rightTrigger, 1, phase);
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
    #endregion
}
