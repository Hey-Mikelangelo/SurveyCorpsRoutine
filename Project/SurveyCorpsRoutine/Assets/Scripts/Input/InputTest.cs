using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XRInput;

public class InputTest : MonoBehaviour
{
    public XRInputChannelSO inputChannel;

    private void OnEnable()
    {
        inputChannel.onLeftTriggerButtonReleased += OnButton;
    }
    private void OnDisable()
    {
        inputChannel.onLeftGripButton -= OnButton;

    }
    void OnButton()
    {
        Debug.Log("Ok");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
