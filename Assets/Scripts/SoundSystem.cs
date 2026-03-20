using System;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum SFXEvent { 

}

[Serializable]
public struct SoundEffect {
    public AudioClip audio;
    public SFXEvent type;
    [Range (0,1)] public float level;
}