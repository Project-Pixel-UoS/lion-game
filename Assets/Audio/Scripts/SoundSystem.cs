using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private static SoundSystem instance;

    public static SoundSystem Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [SerializeField]
    private SfxDefinition[] sfxDefinitions;

    private Dictionary<SfxType, SfxDefinition> sfxMap;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

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
            audioSource.PlayOneShot(sfx.clip, sfx.volume);
        }
    }
}
