using Unity.Mathematics;
using UnityEngine;

namespace Helpers
{
    public static class MathHelper
    { 
        public static float3 GetPositionOffset(float3 currentPos, float3 prevPos)
        {
            return currentPos - prevPos;
        }
        public static float GetVelocity(Vector3 prevPos, Vector3 currPos, float time)
        {
            return Vector3.Distance(prevPos, currPos) / time;
        }
    }
}
