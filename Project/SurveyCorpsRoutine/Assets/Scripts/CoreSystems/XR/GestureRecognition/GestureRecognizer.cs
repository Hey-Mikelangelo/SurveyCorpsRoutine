using System;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class GestureRecognizer : MonoBehaviour
{
    public GestureRecorder recorder;
    public GestureLibrary gestureLibrary;
    Vector3 startPos;
    List<Fixed2dVectors.Direction> DirectionSequence = new List<Fixed2dVectors.Direction>();
    private void OnEnable()
    {
        recorder.onGestureCompleted += OnGestureCompleted;
        recorder.onGestureStroke += OnGestureStroke;
    }
    private void OnDisable()
    {
        recorder.onGestureCompleted -= OnGestureCompleted;
        recorder.onGestureStroke -= OnGestureStroke;
    }
    private void Update()
    {
        if (DirectionSequence != null)
        {
            for (int i = 1; i < DirectionSequence.Count; i++)
            {
                Vector2 v = (Fixed2dVectors.DirectionsDict[DirectionSequence[i]]);
                Debug.DrawRay(startPos, v * 0.1f);
            }
        }
    }
    private void OnGestureStroke(GestureRecord.PointsStroke pointsStroke)
    {
        startPos = pointsStroke.Points[0];
        DirectionSequence = PointsToFixed2dDirections(pointsStroke.Points, pointsStroke.projectionTransform);
        List<Fixed2dVectors.Direction> MergedSequence;
        //if triger is pressed - set direction as valid only if direction appeared minimum twice
        if (pointsStroke.strokeType == 1)
        {
            MergedSequence = MergeSame(DirectionSequence, 2);
        }
        else
        {
            MergedSequence = MergeSame(DirectionSequence, 1);
        }
        int gestureStrength = DirectionSequence.Count;
        string currentPattern = GestureLibrary.FixedDirectionsToString(MergedSequence);
        Debug.Log(currentPattern);
        foreach (var gesture in gestureLibrary.GesturesList)
        {
            int value = Algorithms.LevenshteinDistance.Calculate(gesture.pattern, currentPattern);
            //Debug.Log(gesture.name + " " + value);

            if (value <= gesture.maxRecognitionDistance)
            {
                Debug.Log("Recognized: " + gesture.name + " strenght:" + gestureStrength);
                break;
            }
        }
        //Debug.Log(gestureStrength);

        /*GestureStrokeRecognitionJob strokeRecognitionJob = new GestureStrokeRecognitionJob
        {

        };
        strokeRecognitionJob.Run(pointsStroke.Points.Count);*/
    }

    private void OnGestureCompleted()
    {
        //Debug.Log("gesture completed");
    }
    List<Fixed2dVectors.Direction> MergeSame(in List<Fixed2dVectors.Direction> List, int minRepeat = 0)
    {
        var MergedList = new List<Fixed2dVectors.Direction>(List.Count / 2);
        Fixed2dVectors.Direction prevValue = List[0];
        Fixed2dVectors.Direction lastAcceptedValue = Fixed2dVectors.Direction.none;

        int repeatCount = 1;
        for (int i = 1; i < List.Count; i++)
        {
            if (prevValue == List[i])
            {
                repeatCount++;
            }
            else
            {
                if (repeatCount >= minRepeat && lastAcceptedValue != List[i])
                {
                    MergedList.Add(prevValue);
                    lastAcceptedValue = prevValue;
                }
                repeatCount = 1;
            }
            prevValue = List[i];
        }
        if (repeatCount >= minRepeat && lastAcceptedValue != List[List.Count-1])
        {
            MergedList.Add(prevValue);
        }
        return MergedList;
    }
    
    List<Tuple<Fixed2dVectors.Direction, int>> MergeSameSaveCount(in List<Fixed2dVectors.Direction> List)
    {
        var MergedListWithCount = new List<Tuple<Fixed2dVectors.Direction, int>>(List.Count / 2);
        Fixed2dVectors.Direction prevValue = List[0];

        int sameValuesCounter = 1;
        for (int i = 1; i < List.Count; i++)
        {
            if (prevValue == List[i])
            {
                sameValuesCounter++;
            }
            else
            {
                MergedListWithCount.Add(new Tuple<Fixed2dVectors.Direction, int>(prevValue, sameValuesCounter));
                sameValuesCounter = 1;
            }
            prevValue = List[i];
        }
        MergedListWithCount.Add(new Tuple<Fixed2dVectors.Direction, int>(prevValue, sameValuesCounter));

        return MergedListWithCount;
    }
    List<Fixed2dVectors.Direction> PointsToFixed2dDirections(List<float3> Points, Transform projectionTransform)
    {
        List<Fixed2dVectors.Direction> FixedVectors = new List<Fixed2dVectors.Direction>(Points.Count - 1);
        float2 converted2dVector;
        float3 dir, projectedVector, convertedTo2DSpace;
        for (int i = 0; i < Points.Count - 1; i++)
        {
            dir = Points[i + 1] - Points[i];
            projectedVector = math.normalize(Vector3.ProjectOnPlane(dir, projectionTransform.forward));
            convertedTo2DSpace = projectionTransform.InverseTransformDirection(projectedVector);
            converted2dVector = new float2(convertedTo2DSpace.x, convertedTo2DSpace.y);
            FixedVectors.Add(Fixed2dVectors.GetVector(converted2dVector));
        }
        for (int i = 0; i < FixedVectors.Count; i++)
        {
            // Debug.Log(FixedVectors[i]);
        }
        return FixedVectors;
    }
}
