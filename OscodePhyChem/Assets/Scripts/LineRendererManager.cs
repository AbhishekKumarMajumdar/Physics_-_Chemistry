using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private LineRenderer lineRenderer;

    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();


        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not found. Please attach a LineRenderer component.");
            return;
        }

        lineRenderer.positionCount = 2;

        // Set the positions of the points
        lineRenderer.SetPosition(0, pointA.transform.position);
        lineRenderer.SetPosition(1, pointB.transform.position);
    }

    void Update()
    {

        lineRenderer.SetPosition(0, pointA.transform.position);
        lineRenderer.SetPosition(1, pointB.transform.position);
    }
}
