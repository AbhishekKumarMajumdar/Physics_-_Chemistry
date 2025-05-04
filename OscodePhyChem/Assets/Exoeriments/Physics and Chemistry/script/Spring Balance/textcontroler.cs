using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Slider slider;

    // Measurement format string
    public string measurementFormat = " units";

    // Value range for the text display
    public float displayMinValue = 1f;
    public float displayMaxValue = 100f;

    void Start()
    {
        // Set initial text value to match the slider's initial value
        UpdateTextValue(slider.value);

        // Subscribe to the slider's OnValueChanged event
        slider.onValueChanged.AddListener(UpdateTextValue);
    }

    void UpdateTextValue(float value)
    {
        // Map the slider value to the display range and round to the nearest integer
        int mappedValue = Mathf.RoundToInt(MapValue(value, slider.minValue, slider.maxValue, displayMinValue, displayMaxValue));

        // Update the text value to match the mapped value and append measurement format
        textMeshPro.text = mappedValue.ToString() + measurementFormat;
    }

    // Method to map a value from one range to another
    private float MapValue(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
    }
}
