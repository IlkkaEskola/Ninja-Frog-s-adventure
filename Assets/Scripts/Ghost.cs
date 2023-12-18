using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnInterval = 1.5f;
    public float speed;
    private float yMin = -3.5f;
    private float yMax = -1.5f;

    

    void Start()
    {    
        InvokeRepeating("SpawnGhost", 2f, spawnInterval);
        Destroy(gameObject, 2.2f);
    }


    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void SpawnGhost()
    {
        float posX = 83f;
        float randomPosY = Random.Range(yMax, yMin);
        Vector2 spawnPosition = new Vector2(posX, randomPosY);

        Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
    }
}
