using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    
    [SerializeField] private LevelCell cellPrefab; 
    [SerializeField] private Transform gridParent;
    
    [Header("Settings")]
    public int totalLevels = 50;
    public int levelsUnlocked = 12;
    
    
    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 1; i <= totalLevels; i++)
        {
            LevelCell newCell = Instantiate(cellPrefab, gridParent);
            
         
            bool unlocked = (i <= levelsUnlocked);
            newCell.Setup(i, unlocked);
        }
        
        Canvas.ForceUpdateCanvases();
    }
}
