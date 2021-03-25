using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicGesturesMapSO", menuName ="XR/Input/Gestures/Map")]
public class MagicGesturesMapSO : GestureMapSO<GestureLibrary.GestureName>
{
    public Action
        fireball,
        earthWall;

    protected override void SetGestureActions()
    {
        GestureActions = new List<GestureMapSO<GestureLibrary.GestureName>.Action> { 
            fireball,
            earthWall
        };
    }
}
