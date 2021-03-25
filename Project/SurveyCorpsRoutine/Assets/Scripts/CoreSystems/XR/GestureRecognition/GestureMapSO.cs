using CoreSystems.XR;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GestureMapSO<gestureEnum> : ScriptableObject 
    where gestureEnum : Enum
{
    [Serializable]
    public class Action
    {
        [SerializeField] List<gestureEnum> ActivationGestures = new List<gestureEnum>();
        public XRHandTransform.Hand activatedWithHand { get; private set; }
        public bool isPartialyEnabled;
        private bool _enabled;
        
        public bool HasPartOfGesture(gestureEnum gesture)
        {
            if (ActivationGestures.Contains(gesture))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Get()
        {
            return _enabled;
        }
        public void Set(bool value)
        {
            _enabled = value;
        }
        public static implicit operator bool(Action action)
        {
            return action.Get();
        }
    }

    public List<Action> GetGestureAcions()
    {
        return GestureActions;
    }
    protected abstract void SetGestureActions();
    protected List<Action> GestureActions;
}
