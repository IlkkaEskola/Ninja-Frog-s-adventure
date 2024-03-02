using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowballSmallPrefab;
    public float spawnInterval = 2f;
    
    private float xMin = -29f; //Kent‰n alkup‰‰
    private float xMax = 164f; //Kent‰n loppup‰‰

    private float yMin = 17f;
    private float yMax = 20f;

    void Start()
    {
        InvokeRepeating("SpawnSnowball", 2f, spawnInterval);
    }

    void SpawnSnowball()
    {
        float randomPosX = Random.Range(xMin, xMax);
        float randomPosY = Random.Range(yMin, yMax);
        Vector2 spawnPosition = new Vector2(randomPosX, randomPosY);

        Instantiate(snowballSmallPrefab, spawnPosition, Quaternion.identity);
    }
}

