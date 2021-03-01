using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using XRInput;

public class InputTest : MonoBehaviour
{
    public XRInputChannelSO inputChannel;

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
