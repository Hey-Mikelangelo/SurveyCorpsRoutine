using System.Collections.Generic;
using UnityEngine;
using XRInput;
using UnityEngine.XR;
public class XRHand : MonoBehaviour
{
    public XRInputChannelSO XRInputChannel;
    public enum Hand
    {
        left, right
    }
    public Hand hand;
    private void OnEnable()
    {
        if (hand == Hand.left)
        {
            XRInputChannel.onLeftPosition += OnPosition;
            XRInputChannel.onLeftRotation += OnRotation;
        }
        else
        {
            XRInputChannel.onRightPosition += OnPosition;
            XRInputChannel.onRightRotation += OnRotation;
        }
    }
 
    private void OnDisable()
    {
        if (hand == Hand.left)
        {
            XRInputChannel.onLeftPosition -= OnPosition;
            XRInputChannel.onLeftRotation -= OnRotation;
        }
        else
        {
            XRInputChannel.onRightPosition -= OnPosition;
            XRInputChannel.onRightRotation -= OnRotation;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
