using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFeedback : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text statusText;

    private int clickCount;

    private void OnEnable()
    {
        if (button != null) button.onClick.AddListener(OnButtonClicked);
        if (slider != null) slider.onValueChanged.AddListener(OnSliderChanged);
        if (inputField != null) inputField.onValueChanged.AddListener(OnTextChanged);
        Refresh();
    }

    private void OnDisable()
    {
        if (button != null) button.onClick.RemoveListener(OnButtonClicked);
        if (slider != null) slider.onValueChanged.RemoveListener(OnSliderChanged);
        if (inputField != null) inputField.onValueChanged.RemoveListener(OnTextChanged);
    }

    private void OnButtonClicked()
    {
        clickCount++;
        Refresh();
    }

    private void OnSliderChanged(float value)
    {
        Refresh();
    }

    private void OnTextChanged(string value)
    {
        Refresh();
    }

    private void Refresh()
    {
        if (statusText == null) return;

        float sliderValue = slider != null ? slider.value : 0f;
        string typed = inputField != null && !string.IsNullOrEmpty(inputField.text) ? inputField.text : "-";

        statusText.text = $"Button clicked: {clickCount}   |   Slider: {sliderValue:0.00}   |   Text: {typed}";
    }
}
