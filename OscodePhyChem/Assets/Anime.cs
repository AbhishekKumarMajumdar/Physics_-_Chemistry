using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AnimateObject : MonoBehaviour
{
    public Transform targetPosition;  // Target position (center of screen)
    public Vector3 targetScale = new Vector3(2, 2, 2); // Target scale when object enlarges
    public float animationDuration = 1f;  // Duration for the animation
    public Button toggleButton; // UI Button to toggle the animation

    private Vector3 initialPosition;  // Store the initial position
    private Vector3 initialScale;     // Store the initial scale
    private bool isAnimating = false; // Toggle state for animation
    private bool isAtTarget = false;  // Check if object is at the target position/scale

    void Start()
    {
        // Store the initial position and scale of the object
        initialPosition = transform.position;
        initialScale = transform.localScale;

        // Add listener for the button click event
        toggleButton.onClick.AddListener(ToggleAnimation);
    }

    // Function to start the animation
    public void ToggleAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateObjectToTarget(isAtTarget ? initialPosition : targetPosition.position, isAtTarget ? initialScale : targetScale));
        }
    }

    // Coroutine to handle the animation
    private IEnumerator AnimateObjectToTarget(Vector3 targetPos, Vector3 targetScl)
    {
        isAnimating = true;
        float timeElapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 startScale = transform.localScale;

        // Lerp from current position/scale to target position/scale over time
        while (timeElapsed < animationDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, timeElapsed / animationDuration);
            transform.localScale = Vector3.Lerp(startScale, targetScl, timeElapsed / animationDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure object reaches the target position and scale
        transform.position = targetPos;
        transform.localScale = targetScl;

        isAtTarget = !isAtTarget;
        isAnimating = false;
    }
}
