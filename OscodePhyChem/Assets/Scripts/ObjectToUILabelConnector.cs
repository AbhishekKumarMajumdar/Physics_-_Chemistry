using System.Collections.Generic;
using UnityEngine;

public class ObjectToUILabelConnector : MonoBehaviour
{
    [System.Serializable]
    public class ObjectLabelPair
    {
        public Transform objectTransform; // Reference to the 3D object
        public RectTransform uiLabelTransform; // Reference to the UI label (RectTransform)
        public LineRenderer lineRenderer; // LineRenderer component for drawing the line
    }

    public Camera mainCamera;  // Reference to the main camera
    public List<ObjectLabelPair> objectLabelPairs = new List<ObjectLabelPair>(); // List of object-label pairs

    void Start()
    {
        // Initialize LineRenderer components for each object-label pair
        foreach (ObjectLabelPair pair in objectLabelPairs)
        {
            if (pair.objectTransform != null && pair.uiLabelTransform != null)
            {
                // Create a LineRenderer component
                pair.lineRenderer = pair.objectTransform.gameObject.AddComponent<LineRenderer>();

                // Set LineRenderer properties
                pair.lineRenderer.startWidth = 0.01f;
                pair.lineRenderer.endWidth = 0.01f;
                pair.lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                pair.lineRenderer.startColor = Color.white;
                pair.lineRenderer.endColor = Color.white;
                pair.lineRenderer.positionCount = 2;
            }
        }
    }

    void Update()
    {
        // Update the positions of LineRenderers for each object-label pair
        foreach (ObjectLabelPair pair in objectLabelPairs)
        {
            if (pair.objectTransform != null && pair.uiLabelTransform != null)
            {
                // Convert the 3D object's world position to screen space
                Vector3 objectScreenPosition = mainCamera.WorldToScreenPoint(pair.objectTransform.position);

                // Convert the UI label's position from screen space to world space
                Vector3 labelScreenPosition = pair.uiLabelTransform.position;

                // Convert screen positions to world positions using Camera's ScreenToWorldPoint
                Vector3 worldPoint1 = mainCamera.ScreenToWorldPoint(new Vector3(objectScreenPosition.x, objectScreenPosition.y, mainCamera.nearClipPlane));

                // Adjust the line endpoint to be outside the label's bounds
                Vector3 direction = (labelScreenPosition - objectScreenPosition).normalized;
                float distanceFromLabel = 10f; // Distance to stop before reaching the label
                Vector3 adjustedLabelScreenPosition = labelScreenPosition - direction * distanceFromLabel;

                // Convert adjusted screen position to world position
                Vector3 worldPoint2 = mainCamera.ScreenToWorldPoint(new Vector3(adjustedLabelScreenPosition.x, adjustedLabelScreenPosition.y, mainCamera.nearClipPlane));

                // Update the LineRenderer's positions
                pair.lineRenderer.SetPosition(0, worldPoint1);  // Start point (3D object)
                pair.lineRenderer.SetPosition(1, worldPoint2);  // End point adjusted near the UI Label
            }
        }
    }
}
