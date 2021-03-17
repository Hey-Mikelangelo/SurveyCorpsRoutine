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

public class GestureRecorder : MonoBehaviour
{
    public enum StrokeState
    {
        moving, ended, completed
    }
    public Transform gestureAimTransform; //if null will be set to this.gameobject
    public Transform projectionTransform;
    public IButtonInput startRecordButton;
    public IButtonInput changeStrokeTypeButton;
    public float pointsDistanceThreashold = 0.1f;
    public float minVelocity = 0.1f;
    public event UnityAction<GestureRecord.PointsStroke> onGestureStroke;
    public event UnityAction onGestureCompleted;
    public GameObject debugCube;


    private StrokeState _strokeState;
    private float _velocity;
    private List<float3> _PointsList;
    private Vector3 _prevPos, _currentPos;
    private int _currentStrokeType;
    private GameObject _projectionGO;
    private void Awake()
    {
        _PointsList = new List<float3>(10);
        _strokeState = StrokeState.completed;


    }
    private void Update()
    {
        if (startRecordButton.IsInput())
        {
            //if not set up - set up
            if (_strokeState == StrokeState.completed)
            {
                ResetStroke();
                _strokeState = StrokeState.ended;
            }
            ProcessStrokes();
        }
        else if (!startRecordButton.IsInput() && _strokeState != StrokeState.completed)
        {
            if(_strokeState == StrokeState.moving)
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
            if(_strokeState != StrokeState.moving)
            {
                if(_projectionGO == null)
                {
                    _projectionGO = Instantiate(new GameObject("projectionGO"));
                }
                _projectionGO.transform.position = projectionTransform.position;
                _projectionGO.transform.rotation = projectionTransform.rotation;
                _currentStrokeType = GetCurrentStrokeType();
                _strokeState = StrokeState.moving;
            }
            _PointsList.Add(_currentPos);
            Instantiate(debugCube, _currentPos, Quaternion.identity);
        }
        //if velocity is low - notify about stroke end and reset stroke
        if (_velocity <= minVelocity && _strokeState == StrokeState.moving)
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
        //AudioSource.PlayClipAtPoint(clip, input.headPosition);
        _strokeState = StrokeState.ended;
    }
    void EndGesture()
    {
        onGestureCompleted?.Invoke();
        //AudioSource.PlayClipAtPoint(clip, input.headPosition);
        _strokeState = StrokeState.completed;

    }
    int GetCurrentStrokeType()
    {
        if (changeStrokeTypeButton.IsInput())
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

}
