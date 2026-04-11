using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public LaneTrigger[] lanes;
    public GameObject[] arrows;

    void Update()
    {
        for (int i = 0; i < lanes.Length; i++)
        {
            arrows[i].SetActive(lanes[i].enemyCount > 0);
        }
    }
}
