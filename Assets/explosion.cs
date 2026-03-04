using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float force, radius, modifier;
    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Invoke("DestroyExplosion", 0.1f);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
