using UnityEngine;

namespace CoreSystems.XR.Input
{
    public class InputTest : MonoBehaviour
    {
        public XRInputSO inputMapping;
        public XRFeedbackSO xrFeedback;
        private void OnEnable()
        {
            //input
        }
        private void OnDisable()
        {

        }
        public void Update()
        {
            if (inputMapping.jump)
            {
                xrFeedback.SendImpulseRightH(0.01f, 0.5f);
            }
        }
        void OnButton()
        {
            xrFeedback.SendImpulseLeftH(1, 0.5f);
        }
        // Update is called once per frame
   
    }
}
