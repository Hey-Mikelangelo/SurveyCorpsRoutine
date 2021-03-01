using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace XRFeedback
{
    [DisallowMultipleComponent]
    public class XRFeedbackManager : MonoBehaviour
    {
        public static XRFeedbackManager i;

        private void Awake()
        {
            if (i == null)
            {
                i = this;
            }
            else
            {
                Destroy(this);
                LogHelper.LogDeletedDuplicateSingletonComponent(
                    this, i.gameObject);
            }
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

