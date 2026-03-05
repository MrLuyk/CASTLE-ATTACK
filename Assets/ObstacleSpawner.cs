using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstacleRedPrefab;
    public GameObject obstacleCrownPrefab;
    public float timeToSpawn;
    private int obstacleCount = 0;
    public int obstacleCap = 8;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn < 0.0f && obstacleCount <= obstacleCap)
        {
            SpawnObstacle();
            timeToSpawn = Random.Range(1f, 2f);

            obstacleCount++;
        }
    }

    void SpawnObstacle()
    {
        int mightBeRed = Random.Range(1, 6);
        if (obstacleCount < obstacleCap && mightBeRed < 5)
        {
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
        if (obstacleCount < obstacleCap && mightBeRed == 5)
        {
            Instantiate(obstacleRedPrefab, transform.position, Quaternion.identity);
        }
        if (obstacleCount == obstacleCap)
        {
            Instantiate(obstacleCrownPrefab, transform.position, Quaternion.identity);
        }
    }
}
