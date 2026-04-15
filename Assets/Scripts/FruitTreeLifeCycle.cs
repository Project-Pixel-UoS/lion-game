using TMPro;
using UnityEngine;

public class FruitTreeLifeCycle : MonoBehaviour
{
    private GameObject placementManager;
    private PlacementManager placementManagerScript;
    public TextMeshProUGUI fruitCounter; // Reference to the fruit counter text
    public float lifetime; // The full lifetime of the tree until it starts to die
    public float growingInterval; // The time between each fruit being created
    public float overripeTime; // Time until the tree becomes overripe
    private float lifeTimer; // Timer to track lifetime of tree
    private float growingTimer; // Timer to track time between fruit growing
    private float overripeTimer; // Timer to track time between last fruit being created and tree dying
    private float removeTreeTimer; // Timer to wait a bit once tree is placed so it doesn't delete instantly
    private int fruit; // Fruit produced by the tree

    void Start()
    {
        placementManager = PlacementManager.Instance.gameObject;
        placementManagerScript = placementManager.GetComponent<PlacementManager>();
        fruitCounter.text = "Fruit: 0";
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;
        growingTimer += Time.deltaTime;
        removeTreeTimer += Time.deltaTime;

        // Grow fruit until tree has hit its lifetime
        if (lifeTimer < lifetime)
        {
            if (growingTimer >= growingInterval)
            {
                growingTimer = 0;
                this.fruit += 1;
                fruitCounter.text = "Fruit: " + this.fruit;
            }
        }
        else // Wait a bit until tree dies
        {
            overripeTimer += Time.deltaTime;
            if (overripeTimer >= overripeTime)
            {
                Destroy(gameObject);
            }
        }

        if (removeTreeTimer >= growingInterval)
        {
            // Harvest tree by left-clicking on it
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
