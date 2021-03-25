using CoreSystems.XR;
using CoreSystems.XR.Input;
using UnityEngine;
using UnityEngine.Events;

public interface IPointsCapturer
{
    event UnityAction<Vector3> onPoint;
}
public class XRHandPointsCapturer : MonoBehaviour, IPointsCapturer
{
    public event UnityAction<Vector3> onPoint;

    public XRHandTransform.Hand hand;
    public XRInputMap1 input;
    [SerializeField] Transform _xrHand;
    [SerializeField] float _pointsDistanceThreashold = 0.1f;
    private Vector3 _prevValidPoint, _currentPoint;
    private void Awake()
    {
        _prevValidPoint = Vector3.zero;
        if (_xrHand == null)
        {
            _xrHand = transform;
        }
    }
    private void Update()
    {
        if (DoCapturePoints(hand))
        {
            _currentPoint = _xrHand.position;
            if (PointExceedsDistanceToPoint(_currentPoint, _prevValidPoint, _pointsDistanceThreashold))
            {
                _prevValidPoint = _currentPoint;
                NewPoint(_currentPoint);
            }
        }
    }
    bool PointExceedsDistanceToPoint(Vector3 currentPoint, Vector3 prevValidPoint, float distanceThreshold)
    {
        if(Vector3.Distance(currentPoint, prevValidPoint) > distanceThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void NewPoint(Vector3 point)
    {
        onPoint?.Invoke(point);

    }
    bool DoCapturePoints(XRHandTransform.Hand hand)
    {
        if (hand == XRHandTransform.Hand.left)
        {
            if (input.leftGesture)
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
            if (input.rightGesture)
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
