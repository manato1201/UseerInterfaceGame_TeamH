using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;

    private void Awake()
    {
        if (DataInstance.Instance != null)
        {
            sensitivitySlider.value = DataInstance.Instance.mouseSensitivity;
        }
        else
        {
            sensitivitySlider.value = 1200f; 
        }

        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);

        UpdateSensitivity(sensitivitySlider.value);
    }

    void UpdateSensitivity(float newValue)
    {
        if (DataInstance.Instance != null)
        {
            DataInstance.Instance.mouseSensitivity = newValue;
        }
    }
}
