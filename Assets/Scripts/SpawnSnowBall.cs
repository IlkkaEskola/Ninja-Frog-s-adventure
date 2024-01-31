using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowBall : MonoBehaviour
{
    public GameObject snowballSmallPrefab;
    public float spawnInterval = 2f;
    private float xMin = -29f; //Kent‰n alkup‰‰
    private float xMax = 164f; //Kent‰n loppup‰‰

    void Start()
    {
        
        InvokeRepeating("SpawnSnowball", 2f, spawnInterval);
    }


    void SpawnSnowball()
    {
        
        float randomX = Random.Range(xMin, xMax);
        float posY = 17f;
        Vector2 spawnPosition = new Vector2(randomX, posY);

        Instantiate(snowballSmallPrefab, spawnPosition, Quaternion.identity);
    }
}
