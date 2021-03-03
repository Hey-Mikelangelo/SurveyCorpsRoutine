using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using XRFeedback;
using XRInput;

public class InputTest : MonoBehaviour
{
    public XRInputMappingSO inputMapping;
    public XRFeedbackSO XRFeedback;
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }
    public void Update()
    {
        if (inputMapping.jump)
        {
            XRFeedback.SendImpulseRightH(0.01f, 0.5f);
        }
    }
    void OnButton()
    {
        XRFeedback.SendImpulseLeftH(1, 0.5f);
    }
    // Update is called once per frame
   
}
