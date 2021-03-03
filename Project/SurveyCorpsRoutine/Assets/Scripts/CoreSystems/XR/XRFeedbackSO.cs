using UnityEngine;
using UnityEngine.XR;

namespace CoreSystems.XR
{
    [CreateAssetMenu(fileName = "XRFeedbackSO", menuName = "XR/XR Feedback")]
    public class XRFeedbackSO : ScriptableObject
    { 
        private void Awake()
        {
            
        }
        private void OnEnable()
        {

        }
        private void OnDisable()
        {

        }
        private void SendImpulse(XRNode xrNode, float amplitude, float duration)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(xrNode);
            HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
                if (capabilities.supportsImpulse)
                    device.SendHapticImpulse(0, amplitude, duration);

        }
        public void SendImpulseRightH(float amplitude, float duration)
        {
            SendImpulse(XRNode.RightHand, amplitude, duration);
        }
        public void SendImpulseLeftH(float amplitude, float duration)
        {
            SendImpulse(XRNode.LeftHand, amplitude, duration);
        }
    }
}

