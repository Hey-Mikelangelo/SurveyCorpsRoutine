using CoreSystems.Input;
using Unity.Profiling;
using UnityEngine;

namespace CoreSystems.XR.Input
{
    public class InputTest : MonoBehaviour
    {
        public XRInputMap1 inputMapLayer;
        public XRFeedbackSO xrFeedback;
        private void OnEnable()
        {
      
        }
        private void OnDisable()
        {

        }
        static readonly ProfilerMarker testMarker = new ProfilerMarker("InputTest.Test");
        public void Update()
        {
            // Debug.Log(inputMapLayer.jump.value);
            if (inputMapLayer.jump)
            {
                Debug.Log("jump" + inputMapLayer.jump.Get());
            }
            if (inputMapLayer.rotateLeft)
            {
                Debug.Log("rotateLeft" + inputMapLayer.rotateLeft.Get());
            }
           /* if (inputMapLayer.move != Vector2.zero)
            {
                Debug.Log("move" + inputMapLayer.move.Get());
            }*/
            if (inputMapLayer.sprint)
            {
                Debug.Log("sprint" + inputMapLayer.sprint.Get());
            }
           /* if (inputMapLayer.rightGestureChange)
            {
                Debug.Log("rightGestureChange" + inputMapLayer.rightGestureChange.Get());
            }
            if (inputMapLayer.rightHandGrab > 0)
            {
                Debug.Log("rightHandGrab" + inputMapLayer.rightHandGrab.Get());
            }*/

        }
        void OnButton()
        {
            xrFeedback.SendImpulseLeftH(1, 0.5f);
        }
        // Update is called once per frame
   
    }
}
