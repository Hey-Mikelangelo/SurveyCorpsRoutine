using UnityEngine;
using System.Collections.Generic;
using CoreSystems.Input;

namespace CoreSystems.XR.Input
{
    [CreateAssetMenu(fileName = "XRInputMap1", menuName = "XR/Input/Maps/Map1")]
    public class XRInputMap1 : InputMapSO<
        CoreSystems.XR.Input.XRInputTriggerBool,
        CoreSystems.XR.Input.XRInputTriggerFloat,
        CoreSystems.XR.Input.XRInputTriggerVector2,
        CoreSystems.XR.Input.XRInputTriggerVector3,
        CoreSystems.XR.Input.XRInputTriggerQuaternion>
    {
        public BoolAction
            jump,
            rotateLeft,
            rotateRight,
            rotateBack,
            rightGesture,
            leftGesture,
            rightGestureChange,
            leftGestureChange,
            sprint;


        public FloatAction
            leftHandGrab,
            rightHandGrab;

        public Vector2Action
            move;

        public Vector3Action
            headPosition,
            leftHandPosition,
            rightHandPosition;

        public QuaternionAction
            headRotation,
            leftHandRotation,
            rightHandRotation;

        protected override void FillBoolActionList()
        {
            BoolActions = new List<BoolAction>()
            {
                jump,
                rotateLeft,
                rotateRight,
                rotateBack,
                rightGesture,
                leftGesture,
                rightGestureChange,
                leftGestureChange,
                sprint,

            };

        }

        protected override void FillFloatActionList()
        {
            FloatActions = new List<FloatAction>()
            {
                leftHandGrab,
                rightHandGrab
            };
        }

        protected override void FillVector2ActionList()
        {
            Vector2Actions = new List<Vector2Action>()
            {
                move
            };
        }

        protected override void FillVector3ActionList()
        {
            Vector3Actions = new List<Vector3Action>()
            {
                headPosition,
                leftHandPosition,
                rightHandPosition
            };
        }
        protected override void FillQuaternionActionList()
        {
            QuaternionActions = new List<QuaternionAction>()
            {
                headRotation,
                leftHandRotation,
                rightHandRotation
            };
        }

    }
}
