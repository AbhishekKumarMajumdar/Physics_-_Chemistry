using UnityEngine;

public class MoveModelsUpDown : MonoBehaviour
{
    public Transform model1;
    public Transform model2;
    public Transform model3;
    public float moveSpeed = 1000f;  

    private Vector3 lastMousePosition;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
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

            // Only move on Y axis
            Vector3 move = new Vector3(
                0, // Remove X movement
                deltaMousePosition.y * moveSpeed * Time.deltaTime * 10f, // Boost Y speed
                0
            );

            MoveWithinCameraBounds(move);
            lastMousePosition = Input.mousePosition;
        }
    }


    void MoveWithinCameraBounds(Vector3 move)
    {
        Transform[] models = { model1, model2, model3 };

        foreach (Transform model in models)
        {
            Vector3 newPosition = model.position + move;

            // Get camera bounds in world space
            Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0.1f, 0.2f, mainCamera.WorldToScreenPoint(model.position).z));
            Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(.9f, .8f, mainCamera.WorldToScreenPoint(model.position).z));

            // Clamp the model's position directly in world space
            newPosition.y = Mathf.Clamp(newPosition.y, bottomLeft.y, topRight.y);

            // Apply final position
            model.position = newPosition;
        }
    }
}
