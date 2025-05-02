using UnityEngine;

public class SmoothZoom : MonoBehaviour
{
    public Camera mainCamera;         // The main camera in the scene
    public float zoomSpeed = 5f;      // Speed of the zoom
    public float minZoom = 20f;       // Minimum zoom level
    public float maxZoom = 60f;       // Maximum zoom level

    private float targetZoom;         // Target zoom level
    private float zoomLerpSpeed = 10f;// Speed of smoothing

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // If no camera is assigned, use the main camera
        }

        targetZoom = mainCamera.fieldOfView; // Initialize target zoom to current camera field of view
    }

    void Update()
    {
        float scrollData = 0;

        // Get scroll input from mouse wheel
        if (Input.mouseScrollDelta.y != 0)
        {
            scrollData = Input.mouseScrollDelta.y;
        }

        // Get touch input for pinch zoom
        if (Input.touchCount == 2)
        {
            scrollData = PinchZoom();
        }

        // Calculate target zoom level
        targetZoom -= scrollData * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom); // Clamp target zoom level within min and max bounds
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetZoom, Time.deltaTime * zoomLerpSpeed); // Smoothly interpolate camera field of view to target zoom level
    }

    private float PinchZoom()
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;
        return deltaMagnitudeDiff;
    }
}
