using UnityEngine;
using UnityEngine.UI; // For UI elements

public class ModelMovement : MonoBehaviour
{
    public Camera mainCamera; // The camera to get screen boundaries
    public Transform modelToMove; // The specific model to move
    public float sensitivity = 1f; // Sensitivity for touch/mouse movement
   
    private Vector3 initialMouseWorldPosition;
    private Vector3 modelInitialPosition;
    private bool isDragging = false; // To track mouse dragging state
    private float fixedObjectDistance; // Fixed distance for the model from the camera
   
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Default to main camera if not set
        }

        // Calculate and store the initial distance between the camera and the model
        fixedObjectDistance = Vector3.Distance(mainCamera.transform.position, modelToMove.position);

     
    }

    void Update()
    {
       
       

        if (modelToMove != null) // Ensure a model is assigned
        {
            HandleTouchInput(); // For mobile devices
            HandleMouseInput(); // For desktop devices
        }
    }

 

    void HandleTouchInput()
    {
        if (Input.touchCount > 0) // Touch Input for mobile
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialMouseWorldPosition = GetWorldPositionAtFixedDistance(touch.position);
                modelInitialPosition = modelToMove.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 currentTouchWorldPosition = GetWorldPositionAtFixedDistance(touch.position);
                MoveObject(currentTouchWorldPosition - initialMouseWorldPosition);
            }
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse button pressed
        {
            isDragging = true;
            initialMouseWorldPosition = GetWorldPositionAtFixedDistance(Input.mousePosition);
            modelInitialPosition = modelToMove.position;
        }

        if (Input.GetMouseButton(0) && isDragging) // Mouse movement
        {
            Vector3 currentMouseWorldPosition = GetWorldPositionAtFixedDistance(Input.mousePosition);
            MoveObject(currentMouseWorldPosition - initialMouseWorldPosition);
        }

        if (Input.GetMouseButtonUp(0)) // Mouse button released
        {
            isDragging = false;
        }
    }

    Vector3 GetWorldPositionAtFixedDistance(Vector3 screenPosition)
    {
        // Maintain a fixed z distance from the camera while converting from screen to world
        return mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, fixedObjectDistance));
    }

    void MoveObject(Vector3 deltaPosition)
    {
        Vector3 newPosition = modelInitialPosition + deltaPosition * sensitivity;

        // Clamp the new position within the camera view boundaries
        Vector3 clampedPosition = ClampToCameraView(newPosition);

        // Apply the clamped position to the object
        modelToMove.position = clampedPosition;
    }

    Vector3 ClampToCameraView(Vector3 position)
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(position);

        // Clamp the view position to the screen boundaries
        viewPos.x = Mathf.Clamp(viewPos.x, 0.0f, 1.0f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.0f, 1.0f);

        // Convert back from viewport to world position
        return mainCamera.ViewportToWorldPoint(viewPos);
    }
}
