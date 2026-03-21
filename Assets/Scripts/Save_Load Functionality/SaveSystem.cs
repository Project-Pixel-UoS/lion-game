using UnityEngine;
using System.IO;
public class SaveSystem
{
    private static SaveData _currentSaveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public GameStatsSaveData gameStats;
    }

    public static bool SaveExists()
    {
        string path = Application.persistentDataPath + "/save.save";
        return System.IO.File.Exists(path);
    }

    public static string SaveFileName()
    {
        string fileName = Application.persistentDataPath + "/save" + ".save";
        return fileName;
    }

    public static void Save()
    {
        HandleSaveData(); // Update the current save data with the latest game stats

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_currentSaveData, true));
        Debug.Log("Game saved to: " + SaveFileName());
    }

    public static void HandleSaveData()
    {
        GameStatsManager.Instance.SaveStats(ref _currentSaveData.gameStats);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _currentSaveData = JsonUtility.FromJson<SaveData>(saveContent);
        Debug.Log("Game loaded from: " + SaveFileName());
        HandleLoadData(); // Load the saved game stats into the GameStatsManager
    }

    public static void HandleLoadData()
    {
        GameStatsManager.Instance.LoadStats(_currentSaveData.gameStats);
    }

    public static SaveData GetSaveData()
    {
        // If file exists, load it first
        if (File.Exists(SaveFileName()))
        {
            string saveContent = File.ReadAllText(SaveFileName());
            _currentSaveData = JsonUtility.FromJson<SaveData>(saveContent);
        }

        return _currentSaveData;
    }
}
