using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToLoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Collider targetCollider;

    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }

        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleInput(touch.position);
            }
        }
    }

    void HandleInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (targetCollider == null || hit.collider == targetCollider)
            {
                LoadScene();
            }
        }
    }

    // Public function to load the scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
