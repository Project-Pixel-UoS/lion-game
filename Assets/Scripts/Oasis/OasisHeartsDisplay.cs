using System.Collections.Generic;
using UnityEngine;

public class OasisHeartsDisplay : MonoBehaviour
{
    public OasisHealth oasis;
    public Transform heartsParent;
    public Heart heartPrefab;
    public Color fullColor = Color.white;
    public Color emptyColor = new Color(1f, 1f, 1f, 0.25f);

    private List<Heart> hearts = new List<Heart>();
    private int lastLives;

    void Start()
    {
        // Clear placeholder hearts placed in the editor
        for (int i = heartsParent.childCount - 1; i >= 0; i--)
        {
            Destroy(heartsParent.GetChild(i).gameObject);
        }

        // Spawn one heart per life
        for (int i = 0; i < oasis.maxLives; i++)
        {
            Heart h = Instantiate(heartPrefab, heartsParent);
            hearts.Add(h);
        }

        lastLives = oasis.currentLives;
        Refresh();
    }

    void Update()
    {
        if (oasis.currentLives != lastLives)
        {
            lastLives = oasis.currentLives;
            Refresh();
        }
    }

    void Refresh()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < oasis.currentLives)
            {
                hearts[i].fill.color = fullColor;
            }
            else
            {
                hearts[i].fill.color = emptyColor;
            }
        }
    }
}
