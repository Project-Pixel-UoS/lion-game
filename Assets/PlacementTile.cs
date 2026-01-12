using UnityEngine;

public class PlacementTile : MonoBehaviour
{
    public bool occupied;
    public SpriteRenderer sr;

    public Color normal = Color.black;
    public Color highlight = Color.green;

    public GameObject testVisual;

    void Start()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        sr.color = normal;
    }

    void Update()
    {
        bool canPlace = !occupied;
        sr.color = canPlace ? highlight : normal;
    }

    void OnMouseDown()
    {
        Debug.Log("Tile clicked");
        if (occupied) return;
        if (testVisual == null) return;

        Instantiate(
            testVisual,
            transform.position,
            Quaternion.identity
        );

        occupied = true;
    }
}
