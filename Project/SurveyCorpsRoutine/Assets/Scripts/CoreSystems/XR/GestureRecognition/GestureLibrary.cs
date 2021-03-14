using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GestureLibrary", menuName = "Game/Gestures/Library")]
public class GestureLibrary : ScriptableObject
{
    public enum GestureName
    {
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

    public struct Gesture
    {
        [ShowOnly] public GestureName name;
        [ShowOnly] public string pattern;
        [ShowOnly] public int maxRecognitionDistance;

        public Gesture(GestureName name, string pattern, int maxRecognitionDistance)
        {
            this.name = name;
            this.pattern = pattern;
            this.maxRecognitionDistance = maxRecognitionDistance;
        }
    }
    [SerializeField] public List<Gesture> Gestures = new List<Gesture>();
    [SerializeField]
    public List<Gesture> GesturesList = new List<Gesture>()
    {
        new Gesture(GestureName.circleCounterClockwise, "dhbgceafd", 2),
        new Gesture(GestureName.circleClockwise, "cgbhdfaec", 2),

        new Gesture(GestureName.Up, "a", 0),
        new Gesture(GestureName.Down, "b", 0),
        new Gesture(GestureName.Right, "c", 0),
        new Gesture(GestureName.Left, "d", 0),

        new Gesture(GestureName.UpRight, "e", 0),
        new Gesture(GestureName.UpLeft, "f", 0),
        new Gesture(GestureName.DownRight, "g", 0),
        new Gesture(GestureName.DownLeft, "h", 0),

        new Gesture(GestureName.UpAndRight, "ac", 0),
        new Gesture(GestureName.UpAndLeft, "ad", 0),
        new Gesture(GestureName.UpAndDown, "ab", 0),
        new Gesture(GestureName.UpAndDownRight, "ag", 0),
        new Gesture(GestureName.UpAndDownLeft, "ah", 0),

        new Gesture(GestureName.DownAndRight, "bc", 0),
        new Gesture(GestureName.DownAndLeft, "bd", 0),
        new Gesture(GestureName.DownAndUp, "ba", 0),
        new Gesture(GestureName.DownAndUpRight, "be", 0),
        new Gesture(GestureName.DownAndUpLeft, "bf", 0),


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
