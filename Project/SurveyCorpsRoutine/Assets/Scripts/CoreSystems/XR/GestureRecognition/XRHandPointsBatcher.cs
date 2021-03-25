using CoreSystems.XR;
using CoreSystems.XR.Input;
using Helpers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPointsBatcher
{
    event UnityAction<List<Vector3>> onPointsBatch;
}
public class XRHandPointsBatcher : MonoBehaviour, IPointsBatcher
{
    [SerializeField] XRHandPointsCapturer _xrHandPointsCapturer;
    [SerializeField] Transform handTransform;
    [SerializeField] float _minVelocity = 0.1f;
    [HideInInspector] public XRHandTransform.Hand hand;
    [HideInInspector] public XRInputMap1 input;
    private IPointsCapturer _pointsCapturer;

    public event UnityAction<List<Vector3>> onPointsBatch;


    private List<Vector3> _Points = new List<Vector3>();
    private Vector3 _prevPos, _currentPos;
    private bool _batchedAll = true;
    private bool _leftGestureCanceled, _rightGestureCanceled;
    private void Awake()
    {
        _batchedAll = true;
        hand = _xrHandPointsCapturer.hand;
        input = _xrHandPointsCapturer.input;
    }
    private void OnEnable()
    {
        if (handTransform == null)
        {
            handTransform = transform;
        }
        if (_xrHandPointsCapturer == null)
        {
            _xrHandPointsCapturer = GetComponent<XRHandPointsCapturer>();
        }
        _pointsCapturer = _xrHandPointsCapturer;

        _pointsCapturer.onPoint += OnPoint;
        if(hand == XRHandTransform.Hand.left)
        {
            input.leftGesture.canceled += OnLeftGestureCanceled;
        }
        else
        {
            input.rightGesture.canceled += OnRightGestureCanceled;
        }


    }
    private void OnDisable()
    {
        _pointsCapturer.onPoint -= OnPoint;
        input.leftGesture.canceled -= OnLeftGestureCanceled;
        input.rightGesture.canceled -= OnRightGestureCanceled;

    }
    private void Update()
    {
        _currentPos = transform.position;

        float velocity = MathHelper.GetVelocity(_prevPos, _currentPos, Time.deltaTime);
        if ((velocity < _minVelocity || GestureCanceled()) && !_batchedAll)
        {
            BatchPoints();
        }

        _prevPos = _currentPos;
        _leftGestureCanceled = false;
        _rightGestureCanceled = false;
    }
    private void BatchPoints()
    {
        //Debug.Log("BatchPoints");
        onPointsBatch?.Invoke(_Points);
        _Points.Clear();
        _batchedAll = true;
    }
    private void OnPoint(Vector3 point)
    {
        _Points.Add(point);
        _batchedAll = false;
    }
    void OnLeftGestureCanceled()
    {
        _leftGestureCanceled = true;
    }
    void OnRightGestureCanceled()
    {
        _rightGestureCanceled = true;
    }
    bool GestureCanceled()
    {
        if (hand == XRHandTransform.Hand.left)
        {
            if (_leftGestureCanceled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (_rightGestureCanceled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
