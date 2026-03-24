using UnityEngine;

public class LoadSaveOnStart : MonoBehaviour
{
    void Start()
    {
        if (SaveSystem.LoadRequested)
        {
            Debug.Log("Load requested on scene start.");

            if (SaveSystem.SaveExists())
            {
                Debug.Log("Save file found. Loading save...");
                SaveSystem.Load();
            }
            else
            {
                Debug.LogWarning("Load requested, but no save file exists. Starting fresh.");
            }

            SaveSystem.LoadRequested = false;
        }
        else
        {
            Debug.Log("No load requested. Starting fresh.");
        }
    }
}