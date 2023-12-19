using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowballSmallPrefab;
    public float spawnInterval = 2f;
    private float xMin = -29f;
    private float xMax = 164f;

    void Start()
    {
        // Start spawning snowballs after a delay
        InvokeRepeating("SpawnSnowball", 2f, spawnInterval);
    }


    void SpawnSnowball()
    {
        // Instantiate a snowball prefab at a random position
        float randomX = Random.Range(xMin, xMax);
        float posY = 17f;
        Vector2 spawnPosition = new Vector2(randomX, posY);

        Instantiate(snowballSmallPrefab, spawnPosition, Quaternion.identity);
    }
}
