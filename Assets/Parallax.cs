using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Transform[] tiles;
    public float left = -225f;
    //public Vector3 right = new Vector3;

    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].position += Vector3.back * moveSpeed * Time.deltaTime;

            if (tiles[i].position.z <= left)
            {
                tiles[i].position = new Vector3(-25f, 0f, 75.9f);
            }
        }
    }
}
