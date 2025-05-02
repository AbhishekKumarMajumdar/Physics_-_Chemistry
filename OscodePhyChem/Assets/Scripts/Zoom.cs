using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomModel : MonoBehaviour
{
    public float zoomSpeed = 0.1f; // Speed of zooming
    private Vector3 originalScale;  // Store the original scale

    private float currentScale = 1f; // Current scale factor

    void Start()
    {
        // Store the original scale of the model
        originalScale = transform.localScale;
        currentScale = originalScale.x; // Assuming uniform scaling, you can also use originalScale.y or originalScale.z
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseZoom();
#elif UNITY_IOS || UNITY_ANDROID
        HandleTouchZoom();
#endif
    }

    void HandleMouseZoom()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        currentScale -= scrollData * zoomSpeed;
        currentScale = Mathf.Max(currentScale, originalScale.x); // Use original scale as the minimum

        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    void HandleTouchZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Get the previous position of each touch
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            // Calculate the previous and current distance between the touches
            float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            // Find the difference in distance between frames
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            currentScale += deltaMagnitudeDiff * zoomSpeed * 0.01f; // Adjust zoom sensitivity
            currentScale = Mathf.Max(currentScale, originalScale.x); // Use original scale as the minimum

            transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }
}
