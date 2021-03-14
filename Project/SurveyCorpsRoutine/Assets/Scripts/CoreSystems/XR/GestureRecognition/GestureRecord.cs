using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public struct GestureRecord
{
    /// <summary>
    /// Represents one part of the gesture
    /// </summary>
    public struct PointsStroke
    {
        public readonly List<float3> Points;
        public readonly int strokeType;
        public readonly Transform projectionTransform;
        public PointsStroke(List<float3> Points, int strokeType, Transform projectionTransform)
        {
            this.Points = Points;
            this.strokeType = strokeType;
            this.projectionTransform = projectionTransform;

        }
    }
    public List<PointsStroke> Strokes;
    public GestureRecord(int stepCount)
    {
        Strokes = new List<PointsStroke>(stepCount);
    }
    public void AddStroke(List<float3> newStepStrokes, int strokeType, Transform projectionTransform)
    {
        Strokes.Add(new PointsStroke(newStepStrokes, strokeType, projectionTransform));
    }
    public void AddStroke(PointsStroke stroke)
    {
        Strokes.Add(stroke);
    }

}
