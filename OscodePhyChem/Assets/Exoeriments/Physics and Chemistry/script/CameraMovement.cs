using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target; // Target object to rotate around

    private Vector3 previousPosition;
    private bool _isMoveable;

    private void Update()
    {
        if (!_isMoveable || target == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            // Rotate the camera around the target object
            cam.transform.RotateAround(target.position, Vector3.up, rotationAroundYAxis); // Horizontal rotation
            cam.transform.RotateAround(target.position, cam.transform.right, rotationAroundXAxis); // Vertical rotation

            previousPosition = newPosition;
        }
    }

    public void ResetCam()
    {
        cam.transform.rotation = Quaternion.Euler(20f, 90f, 0f);
        transform.position = new Vector3(-3.5f, 4.5f, 0f);

        _isMoveable = !_isMoveable;
    }
}