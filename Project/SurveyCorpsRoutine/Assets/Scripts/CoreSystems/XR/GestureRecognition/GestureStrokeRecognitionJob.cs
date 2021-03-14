using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public struct GestureStrokeRecognitionJob : IJobParallelFor
{
    [ReadOnly] public NativeArray<float3> CurrentGesture;
    [ReadOnly] public NativeArray<NativeArray<float3>> GesturesList;
    public int result;
    public void Execute(int index)
    {
        NativeArray<float3> MatchGesture = GesturesList[index];
       

        for (int i = 0; i < CurrentGesture.Length; i++)
        {
            
        }
    }

}
