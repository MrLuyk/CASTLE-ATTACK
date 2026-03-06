using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstacleRedPrefab;
    public GameObject obstacleCrownPrefab;
    public float timeToSpawn;
    private int obstacleCount = 0;
    public int obstacleCap = 8;
    //public int sceneCount;

    void Start()
    {
        //sceneCount = SceneManager.sceneCountInBuildSettings;
        //Debug.Log("Scene Number " + sceneCount);
        timeToSpawn = Random.Range(2f, 4f);
    }

    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn < 0.0f && obstacleCount <= obstacleCap)
        {
            SpawnObstacle();
            timeToSpawn = Random.Range(2f, 4f);

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
        if (obstacleCount < obstacleCap && mightBeRed == 5)// && sceneCount == 2
        {
            Instantiate(obstacleRedPrefab, transform.position, Quaternion.identity);
        }
        if (obstacleCount == obstacleCap)
        {
            Instantiate(obstacleCrownPrefab, transform.position, Quaternion.identity);
        }
    }
}
