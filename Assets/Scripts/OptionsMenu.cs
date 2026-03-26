using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Load saved volume settings or set defaults
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);

        // Set sliders to saved values
        masterSlider.value = masterVolume;
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        // Apply the loaded volume settings
        SetMasterVolume(masterVolume);
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    public void SetMasterVolume(float sliderValue)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float sliderValue)
    {
        mainMixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sliderValue);
        PlayerPrefs.Save();
    }
}
