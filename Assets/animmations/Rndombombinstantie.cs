using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBombInstantiate : MonoBehaviour
{
    public GameObject bombDropper;
    private float spawnInterval = 1f; // Interval between bomb spawns
    private float timeSinceLastSpawn = 2f; // Time elapsed since last bomb was spawned

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BallDrops());
    }

    private IEnumerator BallDrops()
    {
        while (true) // Infinite loop to keep spawning bombs
        {
            if (timeSinceLastSpawn >= spawnInterval)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, -2), 20, Random.Range(-5, 5));
                Instantiate(bombDropper, randomSpawnPosition, Quaternion.identity);
                timeSinceLastSpawn = 0f; // Reset the timer after spawning a bomb
            }
            yield return null; // Wait for the next frame
            timeSinceLastSpawn += Time.deltaTime; // Update the elapsed time
        }
    }
}
