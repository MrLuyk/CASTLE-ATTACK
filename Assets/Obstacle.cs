using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float endRange = 30;

    void Start()
    {

    }

    void Update()
    {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;

            if (transform.position.z <= -endRange)
            {
                Destroy(gameObject);
            }
    }
}