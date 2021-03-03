using Unity.Mathematics;

namespace Helpers
{
    public static class MathHelper
    { 
        public static float3 GetPerpendicular(float3 vector1, float3 vector2)
        {
            return math.dot(vector1, vector2);
        }
    }
}
