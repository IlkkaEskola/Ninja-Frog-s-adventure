using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnInterval = 2f;

    //X-akselin arvot, joiden väillä kummitukset spawnaa
    private float xMin = 82f;
    private float xMax = 84f;

    //Y-akselin arvot, joiden välillä kummitukset spawnaa
    private float yMin = -3.5f;
    private float yMax = -1.5f;
    
    
    void Start()
    {    
        InvokeRepeating("SpawnGhost", 2f, spawnInterval);
    }

    void SpawnGhost()
    {
        float randomPosX = Random.Range(xMax, xMin);
        float randomPosY = Random.Range(yMax, yMin);
        Vector2 spawnPosition = new Vector2(randomPosX, randomPosY);

        Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
    }
}
