using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "RealWorldStatusSO", menuName = "XR/Real World Status")]
public class RealWorldStatusSO : ScriptableObject
{ 
    public bool isHeadClipping { get; private set; }
    public bool isLeftHandClipping { get; private set; }
    public bool isRightHandClipping { get; private set; }

    public void HeadClipping(bool status)
    {
        isHeadClipping = status;
    }
    public void LeftHandClipping(bool status)
    {
        isLeftHandClipping = status;
    }
    public void RightHandClipping(bool status)
    {
        isRightHandClipping = status;
    }
}
