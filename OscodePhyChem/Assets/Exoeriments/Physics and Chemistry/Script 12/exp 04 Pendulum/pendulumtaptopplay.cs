using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cakeslice;

public class PendulumTapTapPlay : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string[] animationTriggerNames; // Array of trigger names for animations
    public GameObject targetObject; // Reference to the GameObject with the Collider
    public Button[] targetButtons; // Reference to the Buttons you want to enable after animations
    public Animator otheranimtor;
    public string otherAnimationName = "startclip";
    public string otherAnimationNameend = "endclip";

    private int currentAnimationIndex = 0;
    private bool isAnimationPlaying = false;

    void Start()
    {
        // Initially disable the buttons
        foreach (Button button in targetButtons)
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
                    // Trigger the current animation
                    animator.SetTrigger(animationTriggerNames[currentAnimationIndex]);
                    isAnimationPlaying = true;


                    // Move to the next animation in the sequence
                    currentAnimationIndex++;

                    // If all animations are played, activate the buttons
                    if (currentAnimationIndex >= animationTriggerNames.Length)
                    {
                        currentAnimationIndex = 0; // Reset the index if you want to loop animations
                        ActivateButtons();
                    }
                }
            }
        }
    }

    // This function will be called when the animation ends
    public void OnAnimationComplete()
    {
        isAnimationPlaying = false;
    }

    public void ActivateButtons()
    {
        foreach (Button button in targetButtons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void OtherAnimtionStart()
    {
        otheranimtor.SetTrigger(otherAnimationName);
    }

    public void OtherAnimationEnd()
    {
        otheranimtor.SetTrigger(otherAnimationNameend);
    }
}
