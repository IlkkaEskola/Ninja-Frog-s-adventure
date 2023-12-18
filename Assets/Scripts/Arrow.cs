using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float spawnInterval = 1.5f;
    public float speed;
    private float yMin = -3.5f;
    private float yMax = -1.5f;

    void Start()
    {
        InvokeRepeating("SpawnArrow", 2f, spawnInterval);
        
    }


    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        Destroy(gameObject, 2f);
    }

    void SpawnArrow()
    {
        // Instantiate a snowball prefab at a random position
        float posX = 82f;
        float randomPosY = Random.Range(yMax, yMin);
        Vector2 spawnPosition = new Vector2(posX, randomPosY);

        Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
    }
}
