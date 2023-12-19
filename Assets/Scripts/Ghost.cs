using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnInterval = 2f;
    
    private float yMin = -3.5f;
    private float yMax = -1.5f;

    

    void Start()
    {    
        InvokeRepeating("SpawnGhost", 2f, spawnInterval);
        //Destroy(gameObject, 3f);
    }

    void SpawnGhost()
    {
        float posX = 82f;
        float randomPosY = Random.Range(yMax, yMin);
        Vector2 spawnPosition = new Vector2(posX, randomPosY);

        Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
    }

    
}
