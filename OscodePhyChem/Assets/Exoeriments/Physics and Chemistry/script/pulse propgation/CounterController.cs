using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CounterController : MonoBehaviour
{
    public TMP_Text counterText; // Reference to the TMP_Text component
    public Button startButton;
    public string unit = "  units"; // Default unit
    public float speed = 1f; // Speed of counter, in seconds per increment

    private int maxValue = 60; // Maximum value to count to
    private bool isCounting = false;
    private void Start()
    {
        // Ensure the button calls the StartCounter method when clicked
        startButton.onClick.AddListener(StartCounter);

    }

    private void StartCounter()
    {
        if (!isCounting)
        {
            // Start the coroutine to check for the active state of counterText and then start the counter
            StartCoroutine(WaitForTextActiveAndStartCounter());
            isCounting = true;
        }
    }


    private IEnumerator WaitForTextActiveAndStartCounter()
    {
        // Wait until the counterText GameObject is active in the hierarchy
        while (!counterText.gameObject.activeInHierarchy)
        {
            yield return null;
        }

        // Start the actual counting process
        yield return StartCoroutine(UpdateCounter());
    }

    private IEnumerator UpdateCounter()
    {
        for (int counter = 0; counter <= maxValue; counter++)
        {
            if (counterText.gameObject.activeInHierarchy)
            {
                counterText.text = counter.ToString() + unit;
                yield return new WaitForSeconds(speed);
            }
            else
            {
                break;
            }
        }
        isCounting = false;
    }
}
