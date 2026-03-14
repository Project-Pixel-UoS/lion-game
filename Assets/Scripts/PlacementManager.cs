using UnityEngine;

/// <summary>
/// This Singleton script holds the main functionality relating to the selection of lions from the deployment menu, and the dropping them onto an available slot.
/// This script should be instantiated when the scene is first loaded as long as the script is activated on a gameObject. (Such as the PlacementManager GameObject).
/// Open Deployment Menu -> Select Lion from Deployment Menu -> Select Tile to Place Lion On
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>
/// 

public enum DeploymentMenuType
{
    Lion,
    Energy
}

public class PlacementManager : MonoBehaviour
{
    //Creates Instance for Singleton
    public static PlacementManager Instance; 

    //Stores the type of deployment menu currently open (Lion or Energy)
    public DeploymentMenuType currentMenu;

    //Stores the Gameobject of Lion selected
    public GameObject selectedLion; 

    public PlacementTile currentTile; //Stores the tile that is currently being hovered over by the mouse
    [SerializeField] private GameObject deploymentMenuPanel; //Stores the Deployment Menu Panel Gameobject so that it can be toggled on/off
    [SerializeField] private GameObject placementPromptPanel; //Stores the Placement Prompt Panel Gameobject so that it can be toggled on/off
    [SerializeField] private GameObject cancelButton; //Stores the Cancel Button Gameobject so that it can be toggled on/off

    //Is TRUE if the player is deciding which tile to place a lion
    public bool isPlacing; 

    void Awake()
    {
        Instance = this; //Creates the Singleton
    }

    public void SelectLion(GameObject lion) //Allows the selected lion in deployment menu to be stored
    {
        selectedLion = lion;
    }

    //Cancels the selection of a lion
    public void Cancel()
    {
        selectedLion = null;
        currentTile = null;
        cancelButton.SetActive(false); //Close the Cancel Button after cancelling a selection
        placementPromptPanel.SetActive(false); //Close the Placement Prompt Panel
        deploymentMenuPanel.SetActive(false); //Close the Deployment Menu Panel
        Debug.Log("Selection Cancelled");
    }

    public void OpenDeploymentMenu() //Opens the Deployment Menu and closes the Placement Prompt Panel and Cancel Button
    {
        Debug.Log("Opening Deployment Menu");
        deploymentMenuPanel.SetActive(true); //Open the Deployment Menu Panel
        
        deploymentMenuPanel.GetComponent<LionEnergyMenuLoader>().SwitchMenuType(currentMenu);
        
        placementPromptPanel.SetActive(false); //Close the Placement Prompt Panel
        cancelButton.SetActive(true); //Open the Cancel Button
    }

    public void SetCurrentMenuType(DeploymentMenuType menuType) //Sets the type of deployment menu currently open (Lion or Energy)
    {
        currentMenu = menuType;
    }
    public void SetCurrentTile(PlacementTile tile)
    {
        currentTile = tile;
    }

    //Uses an available placmeent tile to instantiate the selection Lion athe the tile's position
    public void Place(PlacementTile tile)
    {
        if (tile.occupied) return; //End Function if a lion isn't selected or the tile is occupied

        //Spawn the stored Gameobject at the tile's position
        Instantiate(selectedLion, tile.transform.position, tile.transform.rotation);
        tile.occupied = true;

        placementPromptPanel.SetActive(false); //Close the Placement Prompt Panel after placing a lion
        cancelButton.SetActive(false); //Close the Cancel Button after placing a lion

        //Call the Cancel Function so that only one Lion can be placed at a time
        Cancel(); 
    }

    public void PlaceAtCurrentTile() {
        if (selectedLion == null) return;
        if (currentTile.occupied) return; //End Function if a lion isn't selected or the tile is occupied

        //Spawn the stored Gameobject at the tile's position
        Instantiate(selectedLion, currentTile.transform.position, currentTile.transform.rotation);
        currentTile.occupied = true;

        currentTile.GetComponent<Collider2D>().enabled = false; //Re-enable the tile's collider after placing a lion

        placementPromptPanel.SetActive(false); //Close the Placement Prompt Panel after placing a lion
        cancelButton.SetActive(false); //Close the Cancel Button after placing a lion

        //Call the Cancel Function so that only one Lion can be placed at a time
        Cancel(); 
    }
}
