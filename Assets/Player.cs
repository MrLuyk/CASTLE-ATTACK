using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    public bool canJump = false;
    public int jumpCount = 0;
    public float jumpForce = 10000.0f;
    public Text tryAgain;
    //public int sceneCount;

    void Start()
    {
        //sceneCount = SceneManager.sceneCountInBuildSettings;
        //Debug.Log("Scene Number " + sceneCount);
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y >= 1.5f && jumpCount >= 1)
        {
            canJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canJump == true && jumpCount < 1)
        {
            Vector3 velocity = rigidbody.velocity;
            velocity.y = 0f;
            rigidbody.velocity = velocity;

            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Castle") || collision.gameObject.CompareTag("CastleBase") || 
            collision.gameObject.CompareTag("CastleRed") || collision.gameObject.CompareTag("CastleRedBase"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            tryAgain.text = "Try Again!";
        }
    }
}
