using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePart : MonoBehaviour
{
    void OnCollisionStay(Collision other)
    {
            if (other.gameObject.CompareTag("Ground") && gameObject.CompareTag("Castle"))
            {
                StartCoroutine(CoUpdate());
            }
    }

    IEnumerator CoUpdate()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
