using CoreSystems.XR;
using CoreSystems.XR.Input;
using System.Collections.Generic;
using Unity.Mathematics;
using Algorithms;
using UnityEngine;
using UnityEngine.Events;
using Helpers;

public interface IButtonInput
{
    bool IsInput();
}
public class XRGestureRecordInput : MonoBehaviour, IButtonInput
{
    public XRInputSO input;
    
    public bool IsInput()
    {
        return input.rightTrigger;
    }
}
public class GestureRecorder : MonoBehaviour
{
    public enum StrokeState
    {
        moving, ended, completed
    }
    public StrokeState strokeState;
    public XRInputSO input;
    public AudioClip clip;
    public XRHandTransform.Hand hand;
    public Transform projectionTransform;
    public Transform gestureAimTransform;
    public GameObject debugCube;
    public event UnityAction<GestureRecord.PointsStroke> onGestureStroke;
    public event UnityAction onGestureCompleted;
    public float pointsDistanceThreashold;
    public float minVelocity;
    public float _velocity;
    private List<float3> _PointsList;
    private Vector3 _prevPos, _currentPos;
    private int _currentStrokeType;
    private GameObject _projectionGO;
    private void Awake()
    {
        _PointsList = new List<float3>(10);
        strokeState = StrokeState.completed;

        Debug.Log(LevenshteinDistance.Calculate("abcd", "abd"));
        Debug.Log(LevenshteinDistance.Calculate("abcd", "abc"));

    }
    private void Update()
    {
        if (input.rightGesture)
        {
            //if not set up - set up
            if (strokeState == StrokeState.completed)
            {
                ResetStroke();
                strokeState = StrokeState.ended;
            }
            ProcessStrokes();
        }
        else if (!input.rightGesture && strokeState != StrokeState.completed)
        {
            if(strokeState == StrokeState.moving)
            {
                EndStroke();
            }
            EndGesture();
        }

    }
    /// <summary>
    /// Clears PointsList, sets current position as gestureAimTransform.postion,
    /// adds current Position as first element of List, sets prevPos to currentPos
    /// </summary>
    void ResetStroke()
    {
        _PointsList.Clear();
        _currentPos = gestureAimTransform.position;
        _PointsList.Add(_currentPos);
        _prevPos = _currentPos;
    }

    void ProcessStrokes()
    {
        _currentPos = gestureAimTransform.position;
        
        //calculate Velocity
        _velocity = MathHelper.GetVelocity(_prevPos, _currentPos, Time.deltaTime);

        //if new position is far enought from previous point position - make point from new position
        if (Vector3.Distance(_PointsList[_PointsList.Count - 1], _currentPos) > pointsDistanceThreashold)
        {
            if(strokeState != StrokeState.moving)
            {
                if(_projectionGO == null)
                {
                    _projectionGO = Instantiate(new GameObject("projectionGO"));
                }
                _projectionGO.transform.position = projectionTransform.position;
                _projectionGO.transform.rotation = projectionTransform.rotation;
                _currentStrokeType = GetCurrentStrokeType();
                strokeState = StrokeState.moving;
            }
            _PointsList.Add(_currentPos);
            Instantiate(debugCube, _currentPos, Quaternion.identity);
        }
        //if velocity is low - notify about stroke end and reset stroke
        if (_velocity <= minVelocity && strokeState == StrokeState.moving)
        {
            EndStroke();
        }

        _prevPos = _currentPos;
    }
    void EndStroke()
    {
        onGestureStroke?.Invoke(
                new GestureRecord.PointsStroke(_PointsList, _currentStrokeType, _projectionGO.transform));
        ResetStroke();
        AudioSource.PlayClipAtPoint(clip, input.headPosition);
        strokeState = StrokeState.ended;
    }
    void EndGesture()
    {
        onGestureCompleted?.Invoke();
        AudioSource.PlayClipAtPoint(clip, input.headPosition);
        strokeState = StrokeState.completed;

    }
    int GetCurrentStrokeType()
    {
        if (input.rightTrigger)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

}
