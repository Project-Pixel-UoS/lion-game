using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSystem : MonoBehaviour
{
    private static SoundSystem instance;

    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private AudioMixerGroup musicGroup;

    public static SoundSystem Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [SerializeField]
    private SfxDefinition[] sfxDefinitions;

    private Dictionary<SfxType, SfxDefinition> sfxMap;
    private AudioSource sfxAudioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource.playOnAwake = false;
        sfxAudioSource.outputAudioMixerGroup = sfxGroup;

        sfxMap = new Dictionary<SfxType, SfxDefinition>();

        foreach (var sfx in sfxDefinitions)
        {
            if (sfx.sfxType == SfxType.None)
            {
                Debug.LogWarning("[SoundManager] SfxType is not selected for one of the provided sounds. Skipping this sound.");
                continue;
            }

            if (sfx.clip == null)
            {
                Debug.LogWarning($"[SoundManager] No sound given for type: '{sfx.sfxType}'. Skipping this sound.");
                continue;
            }

            if (!sfxMap.ContainsKey(sfx.sfxType))
            {
                sfxMap.Add(sfx.sfxType, sfx);
            }
            else
            {
                Debug.LogWarning($"Duplicate sound given for type: '{sfx.sfxType}'. Skipped this sound.");
            }
        }
    }

    public void PlaySfx(SfxType type)
    {
        if (sfxMap.TryGetValue(type, out var sfx))
        {
            sfxAudioSource.PlayOneShot(sfx.clip, sfx.volume);
        }
    }
}
