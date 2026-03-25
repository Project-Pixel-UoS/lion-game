using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Direction group;

    private void Start()
    {
        WaveManager.Instance?.RegisterSpawnPoint(this);
    }
}

public enum Direction
{
    North,
    East,
    South,
    West,
}