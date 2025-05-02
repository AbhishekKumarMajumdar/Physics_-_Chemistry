using UnityEngine;
using UnityEngine.UI; // For UI elements

public class ModelZoom : MonoBehaviour
{
    public Camera mainCamera; // The camera to control zoom
    public Transform modelToZoom; // The specific model to zoom
    //public Button toggleZoomButton; // Button to enable/disable zoom
    public float zoomSpeed = 10f; // Speed of zooming
    public float minZoomDistance = 2f; // Minimum zoom distance from the model
    public float maxZoomDistance = 20f; // Maximum zoom distance from the model

    //private bool isZoomEnabled = false; // Toggle for enabling/disabling zoom
    private float currentZoomDistance; // Current distance of the camera from the model

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Default to main camera if not set
        }

        // Initialize current zoom distance
        currentZoomDistance = Vector3.Distance(mainCamera.transform.position, modelToZoom.position);

        // Assign the button click event to toggle zoom
        //if (toggleZoomButton != null)
        //{
        //    toggleZoomButton.onClick.AddListener(ToggleZoom);
        //}
    }

    void Update()
    {
        
      
            HandleMouseZoom(); // Handle mouse scroll for zooming
            HandleTouchZoom(); // Handle touch pinch for zooming
       
    }

    // Toggle the zoom state on button click
    //public void ToggleZoom()
    //{
    //    isZoomEnabled = !isZoomEnabled; // Toggle zoom
    //    Debug.Log("Zoom is " + (isZoomEnabled ? "Enabled" : "Disabled"));
    //}

    void HandleMouseZoom()
    {
        // Check for mouse scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            // Calculate new zoom distance
            currentZoomDistance -= scrollInput * zoomSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

            // Set camera position
            UpdateCameraPosition();
        }
    }

    void HandleTouchZoom()
    {
        if (Input.touchCount == 2) // Check for two-finger touch
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Get the previous and current positions of the touches
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            // Calculate the previous and current distance between the two touches
            float prevTouchDistance = Vector2.Distance(touch0PrevPos, touch1PrevPos);
            float currentTouchDistance = Vector2.Distance(touch0.position, touch1.position);

            // Determine zoom direction
            float zoomDifference = currentTouchDistance - prevTouchDistance;

            // Calculate new zoom distance
            currentZoomDistance -= zoomDifference * zoomSpeed * 0.01f; // Adjust sensitivity
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

            // Set camera position
            UpdateCameraPosition();
        }
    }

    void UpdateCameraPosition()
    {
        // Update camera position based on the current zoom distance
        Vector3 direction = (mainCamera.transform.position - modelToZoom.position).normalized;
        mainCamera.transform.position = modelToZoom.position + direction * currentZoomDistance;

        // Optionally, keep the camera looking at the model
        mainCamera.transform.LookAt(modelToZoom);
    }
}
