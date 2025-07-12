using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    [SerializeField] private Slider sensitivitySlider;

    private void Awake()
    {
        Volume();
        Sensitivity();
    }

    private void Volume()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);

        bgmSlider.value = 0.8f;
        seSlider.value = 0.8f;
    }

    public void SetBGMVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("BGMVolume", dB);
    }

    public void SetSEVolume(float volume)
    {
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("SEVolume", dB);
    }



    private void Sensitivity()
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
