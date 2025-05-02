using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;           // Array to store all buttons
    public Image[] buttonImages;       // Array to store external Image components
    public Sprite defaultSprite;       // Default sprite for resetting other buttons
    public Sprite clickedSprite;       // Sprite for the clicked button
    public GameObject[] models;        // Array to store the 3D models
    public Transform targetPosition;   // Target position (e.g., center of the screen)
    public Vector3[] targetScales;     // Array to store the target scales for each model
    public float animationDuration = 1f;  // Duration for the animation

    private Vector3[] initialPositions;    // Store the initial positions of the models
    private Vector3[] initialScales;       // Store the initial scales of the models
    private bool[] isAnimating;            // Track animation states for each model
    private bool[] isAtTarget;             // Track if models are at the target position/scale
    private int currentModelIndex = -1;    // Store index of the currently active model

    void Start()
    {
        // Initialize arrays
        initialPositions = new Vector3[models.Length];
        initialScales = new Vector3[models.Length];
        isAnimating = new bool[models.Length];
        isAtTarget = new bool[models.Length];

        // Store the initial positions and scales of the models
        for (int i = 0; i < models.Length; i++)
        {
            initialPositions[i] = models[i].transform.position;
            initialScales[i] = models[i].transform.localScale;
            isAnimating[i] = false;
            isAtTarget[i] = false;
        }

        // Add listeners to handle button clicks
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture index locally to avoid closure issue
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    // Function to handle button clicks
    void OnButtonClick(int clickedIndex)
    {
        // Reset all button images
        for (int i = 0; i < buttonImages.Length; i++)
        {
            if (i != clickedIndex)
            {
                ResetButtonImage(i);
            }
        }

        // Change the image of the clicked button
        SetClickedButtonImage(clickedIndex);

        // If there is a currently active model, animate it back to its initial state
        if (currentModelIndex != -1 && currentModelIndex != clickedIndex && !isAnimating[currentModelIndex])
        {
            StartCoroutine(AnimateModel(currentModelIndex, initialPositions[currentModelIndex], initialScales[currentModelIndex]));
        }

        // Start the animation for the clicked 3D model
        if (!isAnimating[clickedIndex])
        {
            StartCoroutine(AnimateModel(clickedIndex, targetPosition.position, targetScales[clickedIndex]));
            currentModelIndex = clickedIndex;  // Update the current active model
        }
    }

    // Coroutine to handle the animation of a model
    private IEnumerator AnimateModel(int index, Vector3 targetPos, Vector3 targetScl)
    {
        isAnimating[index] = true;
        float timeElapsed = 0f;
        Vector3 startPos = models[index].transform.position;
        Vector3 startScale = models[index].transform.localScale;

        // Lerp from current position/scale to target position/scale over time
        while (timeElapsed < animationDuration)
        {
            models[index].transform.position = Vector3.Lerp(startPos, targetPos, timeElapsed / animationDuration);
            models[index].transform.localScale = Vector3.Lerp(startScale, targetScl, timeElapsed / animationDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the model reaches the target position and scale
        models[index].transform.position = targetPos;
        models[index].transform.localScale = targetScl;

        // Update the model's state
        isAtTarget[index] = (targetPos == targetPosition.position); // If the targetPos is the target position, the model is at the target
        isAnimating[index] = false;
    }

    // Function to reset the image of a button to the default sprite
    void ResetButtonImage(int index)
    {
        if (buttonImages[index] != null)
        {
            buttonImages[index].sprite = defaultSprite;
        }
    }

    // Function to change the image of the clicked button
    void SetClickedButtonImage(int index)
    {
        if (buttonImages[index] != null)
        {
            buttonImages[index].sprite = clickedSprite;
        }
    }
}
