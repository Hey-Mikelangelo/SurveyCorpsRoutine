using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class GestureMapperSO<gestureEnum> : ScriptableObject
     where gestureEnum : Enum
{
    public IGestureRecognizer<gestureEnum> gestureRecognizer;
    public List<GestureMapSO<gestureEnum>> GestureMaps = new List<GestureMapSO<gestureEnum>>();
    private List<GestureMapSO<gestureEnum>.Action> _EnabledGestureActions = new List<GestureMapSO<gestureEnum>.Action>();
    private void OnEnable()
    {
        gestureRecognizer.onRecognizedGesture += OnRecognizedGesture;
        InputSystem.onAfterUpdate += OnAfterUpdate;
    }
   
    private void OnDisable()
    {
        gestureRecognizer.onRecognizedGesture -= OnRecognizedGesture;
    }
    void OnAfterUpdate()
    {
        if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
            ResetEnabledActions();

    }
    void ResetEnabledActions()
    {
        for (int i = 0; i < _EnabledGestureActions.Count; i++)
        {
            _EnabledGestureActions[i].Set(false);
        }
        _EnabledGestureActions.Clear();
    }
    private void OnRecognizedGesture(GestureLibrary.Gesture<gestureEnum> gesture)
    {
        for (int i = 0; i < GestureMaps.Count; i++)
        {
            GestureMapSO<gestureEnum> gestureMap = GestureMaps[i];
            for (int j = 0; j < gestureMap.GetGestureAcions().Count; j++)
            {
                GestureMapSO<gestureEnum>.Action gestureAction = gestureMap.GetGestureAcions()[j];
                if (gestureAction.HasPartOfGesture(gesture.name))
                {
                    gestureAction.Set(true);
                    _EnabledGestureActions.Add(gestureAction);
                }
            }
        }   
    }
}
