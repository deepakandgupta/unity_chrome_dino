using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timeToSpawn;
    float timer;

    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn) {
            timer = 0;
            SpawnObstacle();
        }
        
    }

    void SpawnObstacle() {
        if (obstacles.Length > 0)
        {
            GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)]);
        }
    }
}
