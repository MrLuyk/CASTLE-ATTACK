using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DestroyCannonball : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Cannonball"))
            {
                Destroy(other.gameObject);
            }
    }
}
