using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform model1; //Reference to the model
    public float moveSpeed = 0.3f;

    private Vector3 lastMousePosition;
    private bool isDragging = false;

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
            Vector3 moveY = new Vector3(0, deltaMousePosition.y * moveSpeed * Time.deltaTime, 0);
            Vector3 moveX = new Vector3(deltaMousePosition.x * moveSpeed * Time.deltaTime, 0, 0);
            Vector3 stopY = new Vector3(0, 0, 0);
            Vector3 stopX = new Vector3(0,0,0);
            model1.position += moveY;
            model1.position += moveX;
            lastMousePosition = Input.mousePosition;
            if (deltaMousePosition.x * moveSpeed * Time.deltaTime == 6.5 || deltaMousePosition.x * moveSpeed * Time.deltaTime == -6.5)
            {
                model1.position += stopX;
            }
            //else if (deltaMousePosition.y < 100)
            //{
            //    model1.position -= move;
            //}
        }
    }
}









//    void OnMouseDown()
//    {
//        lastMousePos = Input.mousePosition;

//    }
//    void OnMouseDrag()
//    {
//        Vector3 delta = Input.mousePosition - lastMousePos;
//        Vector3 pos = transform.position;
//        pos.y += delta.y * dragSpeed;
//        pos.x += delta.x * dragSpeed;
//        //model1.position += pos;
//        transform.position = pos;
//        lastMousePos = Input.mousePosition;

//    }
//}
