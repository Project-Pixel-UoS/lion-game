using UnityEngine;

[System.Serializable]
public class SfxDefinition
{
    public SfxType sfxType;  // Effectively the sfx ID
    public AudioClip clip;
    public float level = 1f;
}
