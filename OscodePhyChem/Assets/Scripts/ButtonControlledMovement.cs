using UnityEngine;

public class ButtonControlledMovement : MonoBehaviour
{
    public Transform model; // Assign your model here
    public float moveSpeed = 1000f;

    public void MoveUp()
    {
        MoveModel(Vector3.up);
    }

    public void MoveDown()
    {
        MoveModel(Vector3.down);
    }

    public void MoveLeft()
    {
        MoveModel(Vector3.left);
    }

    public void MoveRight()
    {
        MoveModel(Vector3.right);
    }

    private void MoveModel(Vector3 direction)
    {
        Vector3 newPosition = model.position + direction * moveSpeed * Time.deltaTime;

        // Convert world position to viewport position
        Camera mainCamera = Camera.main;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(newPosition);

        // Clamp to keep the model within screen bounds
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0.1f, 0.9f);
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0.2f, 0.8f);

        // Convert back to world position
        newPosition = mainCamera.ViewportToWorldPoint(viewportPos);

        model.position = newPosition;
    }
}
