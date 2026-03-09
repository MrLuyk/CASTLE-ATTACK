using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Transform[] tiles;

    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
}
