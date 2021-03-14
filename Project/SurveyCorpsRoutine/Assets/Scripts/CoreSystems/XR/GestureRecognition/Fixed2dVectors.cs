using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.Mathematics;

public static class Fixed2dVectors
{
    public enum Direction
    {
        none, up, down, right, left, upRight, upLeft, downRight, downLeft
    }

    public static float2 up = new float2(0, 1);
    public static float2 down = -up;
    public static float2 right = new float2(1, 0);
    public static float2 left = -right;
    public static float2 upRight = math.normalize(up + right);
    public static float2 upLeft = math.normalize(up + left);
    public static float2 downRight = math.normalize(down + right);
    public static float2 downLeft = math.normalize(down + left);

    public static Dictionary<Direction, float2> DirectionsDict;
    public static List<float2> Directions;
    public static List<Direction> DirectionNames;

    static Fixed2dVectors()
    {
        DirectionsDict = new Dictionary<Direction, float2>(8);
        DirectionsDict.Add(Direction.up, up);
        DirectionsDict.Add(Direction.down, down);
        DirectionsDict.Add(Direction.right, right);
        DirectionsDict.Add(Direction.left, left);
        DirectionsDict.Add(Direction.upRight, upRight);
        DirectionsDict.Add(Direction.upLeft, upLeft);
        DirectionsDict.Add(Direction.downRight, downRight);
        DirectionsDict.Add(Direction.downLeft, downLeft);

        /*
                Directions = new List<float2>(8);
                Directions[0] = up;
                Directions[1] = down;
                Directions[2] = right;
                Directions[3] = left;
                Directions[4] = upRight;
                Directions[5] = upLeft;
                Directions[6] = downRight;
                Directions[7] = downLeft;

                DirectionNames = new List<Direction>(8);
                DirectionNames[0] = Direction.up;
                DirectionNames[1] = Direction.down;
                DirectionNames[2] = Direction.right;
                DirectionNames[3] = Direction.left;
                DirectionNames[4] = Direction.upRight;
                DirectionNames[5] = Direction.upLeft;
                DirectionNames[6] = Direction.downRight;
                DirectionNames[7] = Direction.downLeft;*/

    }
    public static Direction GetVector(float2 vector)
    {
        vector = math.normalize(vector);
        //UnityEngine.Debug.Log(vector);
        Direction bestMatchDirection = 0;
        float bestMatch = -1;
        foreach (KeyValuePair<Direction, float2> keyValue in DirectionsDict)
        {
            float match = math.dot(keyValue.Value, vector);
            //UnityEngine.Debug.Log(keyValue.Key + " " + keyValue.Value + " " + match);
            if (match > bestMatch)
            {
                bestMatch = match;
                bestMatchDirection = keyValue.Key;
            }
        }
        return bestMatchDirection;
    }
}
