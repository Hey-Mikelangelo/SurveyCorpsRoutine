using UnityEngine;
using XRInput;

[AddComponentMenu("XR/XR Hand Transform")]
[DisallowMultipleComponent]
public class XRHandTransform : MonoBehaviour
{
    public XRInputEventsSO XRInputEvents;
    public enum Hand
    {
        left, right
    }
    public Hand hand
    {
        get
        {
            return _hand;
        }
        set
        {
            UnbindActions();
            _hand = value;
            BindActions();
        }
    }
    [SerializeField] Hand _hand;

    private void OnEnable()
    {
        BindActions();
    }

    private void OnDisable()
    {
        UnbindActions();
    }
    void BindActions()
    {
        if (_hand == Hand.left)
        {
            XRInputEvents.onLeftPosition += OnPosition;
            XRInputEvents.onLeftRotation += OnRotation;
        }
        else
        {
            XRInputEvents.onRightPosition += OnPosition;
            XRInputEvents.onRightRotation += OnRotation;
        }
    }
    void UnbindActions()
    {
        if (_hand == Hand.left)
        {
            XRInputEvents.onLeftPosition -= OnPosition;
            XRInputEvents.onLeftRotation -= OnRotation;

        }
        else
        {
            XRInputEvents.onRightPosition -= OnPosition;
            XRInputEvents.onRightRotation -= OnRotation;
        }

    }
    private void OnRotation(Quaternion rot)
    {
        transform.localRotation = rot;
    }

    private void OnPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }


}
