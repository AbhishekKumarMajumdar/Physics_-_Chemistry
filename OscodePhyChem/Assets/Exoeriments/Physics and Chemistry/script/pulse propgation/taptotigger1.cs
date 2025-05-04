using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Make sure you include this if you're using a UI Button


public class TapToAnimate : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationTriggerName = "TapTrigger"; // Name of the trigger parameter in the Animator
    public GameObject targetObject; // Reference to the GameObject with the Collider
    public Button[] targetButton; // Reference to the Button you want to enable after animation

    private bool isAnimationPlaying = false;

    void Start()
    {
        // Initially disable the button
        foreach (Button button in targetButton)
        {

            button.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        // Check if the animation is currently playing
        if (isAnimationPlaying) return;

        // Check for tap input on both mouse and touch
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 tapPosition;

            // Check if it's a mouse click or touch input
            if (Input.GetMouseButtonDown(0))
            {
                // Mouse click
                tapPosition = Input.mousePosition;
            }
            else
            {
                // Touch input
                tapPosition = Input.GetTouch(0).position;
            }

            // Cast a ray from the screen where the user tapped
            Ray ray = Camera.main.ScreenPointToRay(tapPosition);
            RaycastHit hit;

            // Check if the ray hits the target object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    // Trigger the animation

                    animator.SetTrigger(animationTriggerName);
                    isAnimationPlaying = true;
                }
            }
        }
    }

    // This function will be called when the animation ends
    void OnAnimationComplete()
    {
        isAnimationPlaying = false;
        foreach (Button button in targetButton)
        {
            button.gameObject.SetActive(true);
        }
    }
}