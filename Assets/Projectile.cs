using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceAmount = 15.0f;
    public GameObject explosionPrefab;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;

        rigidbody.AddForce(forceDirection *  forceAmount, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {
        print("Collides with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Castle") || other.gameObject.CompareTag("CastleBase"))
        {
            //Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("CastleRed") || other.gameObject.CompareTag("CastleRedBase"))
        {
            //Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
