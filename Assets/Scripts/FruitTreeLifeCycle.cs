using UnityEngine;

public class FruitTreeLifeCycle : MonoBehaviour
{
    private GameObject placementManager;
    private PlacementManager placementManagerScript;
    public float lifetime;
    public float growingInterval; // The time between each fruit being created
    public float overripeTime; // Time until the tree becomes overripe
    private float lifeTimer;
    private float growingTimer;
    private float overripeTimer;
    private float removeTreeTimer; // Timer to wait a bit until the player can remove the tree
    private int fruit;

    void Start()
    {
        placementManager = GameObject.Find("PlacementManager"); // I had trouble with assigning object in inspector so this will have to do...
        placementManagerScript = placementManager.GetComponent<PlacementManager>();
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;
        growingTimer += Time.deltaTime;
        removeTreeTimer += Time.deltaTime;
        if (lifeTimer < lifetime)
        {
            if (growingTimer >= growingInterval)
            {
                growingTimer = 0;
                this.fruit += 1;
            }
        }
        else
        {
            overripeTimer += Time.deltaTime;
            if (overripeTimer >= overripeTime)
            {
                Destroy(gameObject);
            }
        }

        if (removeTreeTimer >= growingInterval)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null && hit.collider.name == "Fruit Tree(Clone)")
                {
                    placementManagerScript.fruit += this.fruit;
                    Destroy(gameObject);
                }
            }
            }
    }
}
