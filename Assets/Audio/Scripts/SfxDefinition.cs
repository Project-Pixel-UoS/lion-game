using UnityEngine;

[System.Serializable]
public class SfxDefinition
{
    public SfxType sfxType;  // Effectively the sfx ID
    public AudioClip clip;
    public float volume = 1f;
}
