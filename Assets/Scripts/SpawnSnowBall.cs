using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowballSmallPrefab;
    public float spawnInterval = 3f;
    private float xMin = -29f;
    private float xMax = -2f;

    void Start()
    {
        // Start spawning snowballs after a delay (if needed)
        InvokeRepeating("SpawnSnowball", 2f, spawnInterval);
    }

    void SpawnSnowball()
    {
        // Instantiate a snowball prefab at a random position within the screen
        float randomX = Random.Range(xMin, xMax);
        float posY = 17f;
        Vector2 spawnPosition = new Vector2(randomX, posY);

        Instantiate(snowballSmallPrefab, spawnPosition, Quaternion.identity);
    }
}
