using Unity.Profiling;
using UnityEngine;

namespace CoreSystems.XR.Input
{
    public class InputTest : MonoBehaviour
    {
        public XRInputMap1 inputMapLayer;
        public XRFeedbackSO xrFeedback;
        public XRInputMapperSO mapper;
        private void OnEnable()
        {
            //input
        }
        private void OnDisable()
        {

        }
        static readonly ProfilerMarker testMarker = new ProfilerMarker("InputTest.Test");
        public void Update()
        {
            // Debug.Log(inputMapLayer.jump.value);
            /*if (inputMapLayer.jump.value)
            {
                Debug.Log("jump" + inputMapLayer.jump.value);
            }
            if (inputMapLayer.move.value != Vector2.zero)
            {
                Debug.Log("move" + inputMapLayer.move);
            }
            if (inputMapLayer.rightGesture)
            {
                Debug.Log("rightGesture" + inputMapLayer.rightGesture);
            }
            if(inputMapLayer.rightHandGrab.value > 0)
            {
                Debug.Log("rightHandGrab" + inputMapLayer.rightHandGrab);
            }*/

        }
        void OnButton()
        {
            xrFeedback.SendImpulseLeftH(1, 0.5f);
        }
        // Update is called once per frame
   
    }
}
