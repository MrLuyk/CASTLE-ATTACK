using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Cannon : MonoBehaviour
{
    Rigidbody rigidbody;
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 90.0f;
    public ParticleSystem fireFX;
    public int numProjectiles = 0;
    public float jumpForce = 10.0f;

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        fireFX.Play();
        numProjectiles++;
    }
}
