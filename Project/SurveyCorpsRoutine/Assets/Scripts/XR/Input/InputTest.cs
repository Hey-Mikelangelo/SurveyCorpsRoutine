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

    class EventSubscribtionManager
    {
        Dictionary<UnityAction, UnityAction> EventsDictionary;
        public EventSubscribtionManager(int eventCount = 1)
        {
            EventsDictionary = new Dictionary<UnityAction, UnityAction>(eventCount);
        }
        public void Subscribe(UnityAction action, UnityAction function)
        {
            EventsDictionary.Add(action, function);
            action += function;
        }
        public void UnsubscribeAll()
        {
            for (int i = 0; i < EventsDictionary.Count; i++)
            {
                KeyValuePair<UnityAction, UnityAction> pair = EventsDictionary.ElementAt(i);
                UnityAction action = pair.Key;
                action -= pair.Value;
            }
        }
    }
    private void OnEnable()
    {
        EventSubscribtionManager subscribtionManager = new EventSubscribtionManager(1);
        //subscribtionManager.Subscribe(inputChannel.onLeftTriggerButtonReleased, OnButton);

        XRInputManager.i.onLeftTriggerButtonReleased += OnButton;
    }
    private void OnDisable()
    {
        XRInputManager.i.onLeftGripButton -= OnButton;

    }
    void OnButton()
    {
        XRFeedbackManager.i.SendImpulseRightH(1, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
