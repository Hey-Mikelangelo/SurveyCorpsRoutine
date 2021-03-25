using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "GestureLibrary", menuName = "Game/Gestures/Library")]
public class GestureLibrary : ScriptableObject
{
    public enum GestureName
    {
        none,

        circleCounterClockwise,
        circleClockwise,

        Up,
        Down,
        Right,
        Left,

        UpRight,
        UpLeft,
        DownRight,
        DownLeft,

        UpAndRight,
        UpAndLeft,
        UpAndDown,
        UpAndDownRight,
        UpAndDownLeft,

        DownAndRight,
        DownAndLeft,
        DownAndUp,
        DownAndUpRight,
        DownAndUpLeft,
    }

    [Serializable]
    public struct Gesture<gestureEnum> where gestureEnum : Enum
    {
        [ShowOnly] public gestureEnum name;
        [ShowOnly] public string pattern;
        [ShowOnly] public int maxRecognitionDistance;

        public Gesture(gestureEnum name, string pattern, int maxRecognitionDistance)
        {
            this.name = name;
            this.pattern = pattern;
            this.maxRecognitionDistance = maxRecognitionDistance;
        }
    }
    [SerializeField]
    public List<Gesture<GestureName>> GesturesList = new List<Gesture<GestureName>>()
    {
        new Gesture<GestureName>(GestureName.circleCounterClockwise, "dhbgceafd", 2),
        new Gesture<GestureName>(GestureName.circleClockwise, "cgbhdfaec", 2),

        new Gesture<GestureName>(GestureName.Up, "a", 0),
        new Gesture<GestureName>(GestureName.Down, "b", 0),
        new Gesture<GestureName>(GestureName.Right, "c", 0),
        new Gesture<GestureName>(GestureName.Left, "d", 0),

        new Gesture<GestureName>(GestureName.UpRight, "e", 0),
        new Gesture<GestureName>(GestureName.UpLeft, "f", 0),
        new Gesture<GestureName>(GestureName.DownRight, "g", 0),
        new Gesture<GestureName>(GestureName.DownLeft, "h", 0),

        new Gesture<GestureName>(GestureName.UpAndRight, "ac", 0),
        new Gesture<GestureName>(GestureName.UpAndLeft, "ad", 0),
        new Gesture<GestureName>(GestureName.UpAndDown, "ab", 0),
        new Gesture<GestureName>(GestureName.UpAndDownRight, "ag", 0),
        new Gesture<GestureName>(GestureName.UpAndDownLeft, "ah", 0),

        new Gesture<GestureName>(GestureName.DownAndRight, "bc", 0),
        new Gesture<GestureName>(GestureName.DownAndLeft, "bd", 0),
        new Gesture<GestureName>(GestureName.DownAndUp, "ba", 0),
        new Gesture<GestureName>(GestureName.DownAndUpRight, "be", 0),
        new Gesture<GestureName>(GestureName.DownAndUpLeft, "bf", 0),


    };
    static StringBuilder stringBuilder = new StringBuilder(10);

    public static string FixedDirectionsToString(in List<Fixed2dVectors.Direction> DirectionsList)
    {
        stringBuilder.Clear();
        for (int i = 0; i < DirectionsList.Count; i++)
        {
            char c = FixedDirectionToChar(DirectionsList[i]);
            stringBuilder.Append(c);
        }
        return stringBuilder.ToString();
    }
    static char FixedDirectionToChar(Fixed2dVectors.Direction value)
    {
        switch (value)
        {
            case Fixed2dVectors.Direction.up:
                return 'a';
            case Fixed2dVectors.Direction.down:
                return 'b';
            case Fixed2dVectors.Direction.right:
                return 'c';
            case Fixed2dVectors.Direction.left:
                return 'd';
            case Fixed2dVectors.Direction.upRight:
                return 'e';
            case Fixed2dVectors.Direction.upLeft:
                return 'f';
            case Fixed2dVectors.Direction.downRight:
                return 'g';
            case Fixed2dVectors.Direction.downLeft:
                return 'h';
            default:
                return 'x';

        }
    }


}
