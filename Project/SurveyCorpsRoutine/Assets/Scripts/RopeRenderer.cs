using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public float lenght;
    public float width;
    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
    void Update()
    {
        
    }
}
