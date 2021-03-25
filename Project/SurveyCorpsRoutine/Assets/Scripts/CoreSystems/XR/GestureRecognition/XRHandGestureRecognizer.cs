using CoreSystems.XR;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGestureRecognizer<gestureEnum> where gestureEnum : Enum 
{
    public event UnityAction<GestureLibrary.Gesture<gestureEnum>> onRecognizedGesture;
}
public class XRHandGestureRecognizer : MonoBehaviour, IGestureRecognizer<GestureLibrary.GestureName>
{
    [SerializeField] XRHandPointsBatcher _xrHandPointsBatcher;
    [SerializeField] GestureLibrary _gestureLibrary;
    [SerializeField] Transform _projectionTransform;
    private IPointsBatcher _pointsBatcher;
    public event UnityAction<GestureLibrary.Gesture<GestureLibrary.GestureName>> onRecognizedGesture;
    event UnityAction<GestureLibrary.Gesture<GestureLibrary.GestureName>> IGestureRecognizer<GestureLibrary.GestureName>.onRecognizedGesture
    {
        add
        {
            onRecognizedGesture += value;
        }

        remove
        {
            onRecognizedGesture -= value;
        }
    }

    private void Awake()
    {
        if(_xrHandPointsBatcher == null)
        {
            _xrHandPointsBatcher = GetComponent<XRHandPointsBatcher>();
        }
        _pointsBatcher = _xrHandPointsBatcher;
    }
    private void OnEnable()
    {
        _pointsBatcher.onPointsBatch += OnPointsBatch;
    }
    private void OnDisable()
    {
        _pointsBatcher.onPointsBatch -= OnPointsBatch;

    }
    void OnPointsBatch(List<Vector3> Points)
    {
        //Create list of fixed directions from list of points
        List<Fixed2dVectors.Direction> DirectionSequence = PointsToFixed2dDirections(Points, _projectionTransform);
        //points count will be used as gesture strength - the higher amlitude of gesture was the more points was generated
        int gestureLength = DirectionSequence.Count;
        //remove useless data. ((up, up, up, right, right, down) -> (up, right, down))
        List<Fixed2dVectors.Direction> MergedSequence = MergeDirectionSequence(DirectionSequence);
        //convert fixed directions into string pattern
        string stringGesturePattern = GestureLibrary.FixedDirectionsToString(MergedSequence);
        Debug.Log(stringGesturePattern);
        for (int i = 0; i < _gestureLibrary.GesturesList.Count; i++)
        {
            GestureLibrary.Gesture<GestureLibrary.GestureName> gesture = _gestureLibrary.GesturesList[i];
            int value = Algorithms.LevenshteinDistance.Calculate(gesture.pattern, stringGesturePattern);
            if (value <= gesture.maxRecognitionDistance)
            {
                Debug.Log("Recognized: " + gesture.name + " strenght:" + gestureLength);
                break;
            }
        }
    }
    List<Fixed2dVectors.Direction> MergeDirectionSequence(in List<Fixed2dVectors.Direction> List)
    {
        int minRepeat;
        if(_xrHandPointsBatcher.hand == XRHandTransform.Hand.left)
        {
            if (_xrHandPointsBatcher.input.leftGestureChange)
            {
                //for sharp moves
                minRepeat = 2;
            }
            else
            {
                //for soft, circle move
                minRepeat = 1;
            }
        }
        else
        {
            if (_xrHandPointsBatcher.input.rightGestureChange)
            {
                minRepeat = 2;
            }
            else
            {
                minRepeat = 1;
            }
        }
        return MergeSame(List, minRepeat);
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
        if (repeatCount >= minRepeat && lastAcceptedValue != List[List.Count - 1])
        {
            MergedList.Add(prevValue);
        }
        return MergedList;
    }

    //saved for future
    /*List<Tuple<Fixed2dVectors.Direction, int>> MergeSameSaveCount(in List<Fixed2dVectors.Direction> List)
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
    }*/
    List<Fixed2dVectors.Direction> PointsToFixed2dDirections(List<Vector3> Points, Transform projectionTransform)
    {
        List<Fixed2dVectors.Direction> FixedVectors = new List<Fixed2dVectors.Direction>(Points.Count - 1);
        Vector2 converted2dVector;
        Vector3 dir, projectedVector, convertedTo2DSpace;
        for (int i = 0; i < Points.Count - 1; i++)
        {
            dir = Points[i + 1] - Points[i];
            projectedVector = (Vector3.ProjectOnPlane(dir, projectionTransform.forward)).normalized;
            convertedTo2DSpace = projectionTransform.InverseTransformDirection(projectedVector);
            converted2dVector = new Vector2(convertedTo2DSpace.x, convertedTo2DSpace.y);
            FixedVectors.Add(Fixed2dVectors.GetVector(converted2dVector));
        }
        return FixedVectors;
    }
}
