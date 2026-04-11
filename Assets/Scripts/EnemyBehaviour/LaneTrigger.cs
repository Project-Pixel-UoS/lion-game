using System;
using UnityEngine;

public class LaneTrigger : MonoBehaviour
{
    public int enemyCount = 0;
    public string[] TagList = {"Zig_Zag_Enemy", "Helmet_Enemy", "Boots_Enemy", "Enemy"};

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered: " + other.name);
        foreach (string TagToTest in TagList)
        {
            if (other.CompareTag(TagToTest))
            {
                enemyCount++;
                return;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        foreach (string TagToTest in TagList)
        {
            if (other.CompareTag(TagToTest))
            {
                enemyCount--;
                return;
            }
        }
    }
}