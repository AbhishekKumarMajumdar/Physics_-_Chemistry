using UnityEngine;

public class Rotate3dModel : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    private Vector3 lastMousePosition;
    private bool isDragging = false;

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
            HandleMouseInput();
#elif UNITY_IOS || UNITY_ANDROID
            HandleTouchInput();
#endif
    }
    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            float rotationY = -deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationY, Space.World);

            lastMousePosition = Input.mousePosition;
        }
    }
    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                lastMousePosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }

            if (isDragging && touch.phase == TouchPhase.Moved)
            {
                Vector3 deltaTouchPosition = (Vector3)touch.position - lastMousePosition;
                float rotationY = -deltaTouchPosition.x * rotationSpeed * Time.deltaTime;

                transform.Rotate(Vector3.up, rotationY, Space.World);

                lastMousePosition = touch.position;
            }
        }
    }
}
