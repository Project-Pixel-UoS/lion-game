using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const float MIN_VOLUME = 0.0001f;

    private void Start()
    {
        InitialiseAudio();
    }

    private void InitialiseAudio()
    {
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float music  = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfx    = PlayerPrefs.GetFloat("SfxVolume", 1f);

        masterSlider.SetValueWithoutNotify(master);
        musicSlider.SetValueWithoutNotify(music);
        sfxSlider.SetValueWithoutNotify(sfx);

        ApplyVolume("MasterVolume", master);
        ApplyVolume("MusicVolume", music);
        ApplyVolume("SfxVolume", sfx);
    }

    private void ApplyVolume(string parameter, float value)
    {
        float clamped = Mathf.Clamp(value, MIN_VOLUME, 1f);
        mainMixer.SetFloat(parameter, Mathf.Log10(clamped) * 20);
    }

    public void SetMasterVolume(float value)
    {
        ApplyVolume("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        ApplyVolume("SfxVolume", value);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}
