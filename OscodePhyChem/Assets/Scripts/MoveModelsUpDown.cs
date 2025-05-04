using UnityEngine;

public class MoveModelsUpDown : MonoBehaviour
{
    public Transform model1; // Reference to the first model
    public Transform model2; // Reference to the second model
    public Transform model3; // Reference to the third model

    public float moveSpeed = 0.1f; // Speed of movement

    private Vector3 lastMousePosition;
    private bool isDragging = false;

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
//#elif UNITY_IOS || UNITY_ANDROID
//        HandleTouchInput();
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
            Vector3 move = new Vector3(0, deltaMousePosition.y * moveSpeed * Time.deltaTime, 0);

            model1.position += move;
            model2.position += move;
            model3.position += move;

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
                Vector3 move = new Vector3(0, deltaTouchPosition.y * moveSpeed * Time.deltaTime, 0);

                model1.position += move;
                model2.position += move;
                model3.position += move;

                lastMousePosition = touch.position;
            }
        }
    }
}
