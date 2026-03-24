using UnityEngine;

public class LoadSaveOnStart : MonoBehaviour
{
    void Start()
    {
        if (SaveSystem.LoadRequested)
        {
            SaveSystem.Load();
            SaveSystem.LoadRequested = false;
        }
    }
}
