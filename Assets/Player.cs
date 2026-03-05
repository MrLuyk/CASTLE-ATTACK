using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    // TODO: Reference to Rigidbody2D component should have class scope.
    Rigidbody rigidbody;
    public bool canJump = false;
    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float jumpForce = 10.0f;
    public Text tryAgain;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Use GetComponent to get a reference to attached Rigidbody2D
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: On the frame the player presses down the space bar, add an instant upwards
        // force to the rigidbody.
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (transform.position.y >= 1.5f)
        {
            canJump = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Castle") || collision.gameObject.CompareTag("CastleBase"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            tryAgain.text = "Try Again!";
        }
    }
}
