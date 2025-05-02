using UnityEngine;
using UnityEngine.UI;

public class ScaleModels : MonoBehaviour
{
    [SerializeField] private Transform[] modelTransforms; // Array of 3D model transforms
    [SerializeField] private Button[] modelButtons; // Array of buttons for each model
    [SerializeField] private Button masterButton; // Master button to reset all models
    [SerializeField] private float scaleFactor = 1.5f; // Factor by which models will be scaled

    private Vector3[] originalScales; // Array to store the original scales of models

    private void Awake()
    {
        // Initialize the array to store original scales
        originalScales = new Vector3[modelTransforms.Length];

        // Store the original scales of the models
        for (int i = 0; i < modelTransforms.Length; i++)
        {
            originalScales[i] = modelTransforms[i].localScale;
        }

        // Assign button listeners
        for (int i = 0; i < modelButtons.Length; i++)
        {
            int index = i; // Capture index for the listener
            modelButtons[i].onClick.AddListener(() => ScaleModel(index));
        }

        masterButton.onClick.AddListener(ResetAllModels);
    }

    private void ScaleModel(int index)
    {
        modelTransforms[index].localScale = originalScales[index] * scaleFactor;
    }

    private void ResetAllModels()
    {
        for (int i = 0; i < modelTransforms.Length; i++)
        {
            modelTransforms[i].localScale = originalScales[i];
        }
    }
}
