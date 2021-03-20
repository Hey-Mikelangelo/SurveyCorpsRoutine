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
        public MappedInputBool
            jump,
            rotateLeft,
            rotateRight,
            rotateBack,
            rightGesture,
            leftGesture,
            rightGestureChange,
            leftGestureChange,
            sprint;


        public MappedInputFloat
            leftHandGrab,
            rightHandGrab;

        public MappedInputVector2
            move;

        public MappedInputVector3
            headPosition,
            leftHandPosition,
            rightHandPosition;

        public MappedInputQuaternion
            headRotation,
            leftHandRotation,
            rightHandRotation;

        protected override void FillBoolActionList()
        {
            BoolActions = new List<MappedInputBool>()
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
            FloatActions = new List<MappedInputFloat>()
            {
                leftHandGrab,
                rightHandGrab
            };
        }

        protected override void FillVector2ActionList()
        {
            Vector2Actions = new List<MappedInputVector2>()
            {
                move
            };
        }

        protected override void FillVector3ActionList()
        {
            Vector3Actions = new List<MappedInputVector3>()
            {
                headPosition,
                leftHandPosition,
                rightHandPosition
            };
        }
        protected override void FillQuaternionActionList()
        {
            QuaternionActions = new List<MappedInputQuaternion>()
            {
                headRotation,
                leftHandRotation,
                rightHandRotation
            };
        }

    }
}
