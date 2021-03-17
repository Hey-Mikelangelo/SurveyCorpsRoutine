using System.Collections.Generic;
using UnityEngine;

namespace CoreSystems.XR.Input
{
    public interface IXRInputMapLayer
    {
        void SetHeadPos(Vector3 pos);
        void SetHeadRot(Quaternion rot);
        void SetRightHandPos(Vector3 pos);
        void SetLeftHandPos(Vector3 pos);
        void SetRightHandRot(Quaternion rot);
        void SetLeftHandRot(Quaternion rot);

        List<XRInputMap.XRMappedInput<bool>> GetBoolInputs();
        List<XRInputMap.XRMappedInput<float>> GetFloatInputs();
        List<XRInputMap.XRMappedInput<Vector2>> GetVector2Inputs();
    }
}
