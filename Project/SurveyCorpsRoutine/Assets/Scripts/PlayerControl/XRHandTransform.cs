using System.Collections.Generic;
using UnityEngine;
using XRInput;
using UnityEngine.XR;
public class XRHandTransform : MonoBehaviour
{
    public enum Hand
    {
        left, right
    }
    public Hand hand;
    private void OnEnable()
    {
        if (hand == Hand.left)
        {
            XRInputManager.i.onLeftPosition += OnPosition;
            XRInputManager.i.onLeftRotation += OnRotation;
        }
        else
        {
            XRInputManager.i.onRightPosition += OnPosition;
            XRInputManager.i.onRightRotation += OnRotation;
        }
    }
 
    private void OnDisable()
    {
        if (hand == Hand.left)
        {
            XRInputManager.i.onLeftPosition -= OnPosition;
            XRInputManager.i.onLeftRotation -= OnRotation;
        }
        else
        {
            XRInputManager.i.onRightPosition -= OnPosition;
            XRInputManager.i.onRightRotation -= OnRotation;
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
