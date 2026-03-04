using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    // TODO: Reference to Rigidbody2D component should have class scope.
    Rigidbody rigidbody;
    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float jumpForce = 10.0f;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
