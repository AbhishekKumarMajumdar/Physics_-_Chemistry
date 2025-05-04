using System.Collections;
using cakeslice;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NewtonsCooling : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string firstAnimationTriggerName = "Tap to Trigger";
    [SerializeField] private string secondAnimationTriggerName = "Second Trigger";
    [SerializeField] private GameObject targetObject;
    [SerializeField] private TextMeshProUGUI tempText;
    [SerializeField] private ParticleSystem Smokefx;
    [SerializeField] private GameObject flames;
    [SerializeField] private BoxCollider watchCollider;
    // [SerializeField] private OutlineEffectActivator outlineEffectActivator;

    [Header("Second Box Text")]
    [SerializeField] private TextMeshProUGUI innerboxTemp;
    [SerializeField] private TextMeshProUGUI outterboxTemp;
    [SerializeField] private GameObject[] arrows;

    private bool isTemperatureRising = true;
    private bool isAnimationPlaying;
    private bool hastempReasied = false;
    private bool isFirstAnimationCompleted = false;
    private float temperature;
    private float targetTemperature = 50f;
    private float temperatureIncreaseDuration = 5f;

    // Secondary temperature variables
    private float innerboxTempValue = 50f;
    private float targetinnerboxTempValue = 46f;
    private float outterboxTempValue = 20.2f;
    private float targetoutterboxTempValue = 20.3f;
    private float temperatureDecreaseDuration = 30f; // 30 seconds for the decrease

    private void Start()
    {

        // Smokefx.Play(false);
        // outlineEffectActivator.EnableOutlineEffect();
        temperature = 0f;
        UpdateTemperatureText();
        UpdateSecondaryTempText();
        UpdateOutterboxTempText();
        flames.SetActive(false);
        watchCollider.enabled = false;
        innerboxTemp.enabled = false;
        outterboxTemp.enabled = false;
        foreach (GameObject objects in arrows)
        {
            objects.SetActive(false);
        }
    }

    private void Update()
    {
        if (isAnimationPlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 tapPosition = Input.GetMouseButtonDown(0) ? Input.mousePosition : Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(tapPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (!isFirstAnimationCompleted)
                {
                    if (hit.collider.gameObject == targetObject)
                    {
                        if (isTemperatureRising)
                        {
                            StartCoroutine(IncreaseTemperature());
                            Smokefx.Play(true);
                            flames.SetActive(true);


                        }
                        else if (hastempReasied)
                        {

                            animator.SetTrigger(firstAnimationTriggerName);
                            isAnimationPlaying = true;
                            Destroy(Smokefx);
                            flames.SetActive(false);
                        }
                    }
                }
                else if (hit.collider == watchCollider)
                {
                    animator.SetTrigger(secondAnimationTriggerName);
                    isAnimationPlaying = true;

                    // Start decreasing the secondary temperatures when the second animation starts
                    StartCoroutine(DecreaseTemperatures());
                }
            }
        }
    }

    private IEnumerator IncreaseTemperature()
    {
        isTemperatureRising = false;
        float elapsedTime = 0f;

        while (elapsedTime < temperatureIncreaseDuration)
        {
            temperature = Mathf.Lerp(0f, targetTemperature, elapsedTime / temperatureIncreaseDuration);
            UpdateTemperatureText();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        temperature = targetTemperature;
        hastempReasied = true;
        UpdateTemperatureText();
    }

    private IEnumerator DecreaseTemperatures()
    {
        float elapsedTime = 0f;
        float startingInnerboxTemp = innerboxTempValue;
        float startingOutterboxTemp = outterboxTempValue;

        while (elapsedTime < temperatureDecreaseDuration)
        {
            innerboxTempValue = Mathf.Lerp(startingInnerboxTemp, targetinnerboxTempValue, elapsedTime / temperatureDecreaseDuration);
            outterboxTempValue = Mathf.Lerp(startingOutterboxTemp, targetoutterboxTempValue, elapsedTime / temperatureDecreaseDuration);
            UpdateSecondaryTempText();
            UpdateOutterboxTempText();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        innerboxTempValue = targetinnerboxTempValue;
        outterboxTempValue = targetoutterboxTempValue;
        UpdateSecondaryTempText();
        UpdateOutterboxTempText();
        animator.SetTrigger("empty");
    }

    private void UpdateTemperatureText()
    {
        tempText.text = $"{temperature:F1}°C";
    }

    private void UpdateSecondaryTempText()
    {
        innerboxTemp.text = $"{innerboxTempValue:F1}°C";
    }

    private void UpdateOutterboxTempText()
    {
        outterboxTemp.text = $"{outterboxTempValue:F1}°C";
    }

    public void OnAnimationCompleted()
    {
        isAnimationPlaying = false;
        innerboxTemp.enabled = true;
        outterboxTemp.enabled = true;

        if (!isFirstAnimationCompleted)
        {
            isFirstAnimationCompleted = true;
            watchCollider.enabled = true;
        }
        foreach (GameObject objects in arrows)
        {
            objects.SetActive(true);
        }
    }
}
