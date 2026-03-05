using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBase : MonoBehaviour
{
    public float checkDistance = 2.0f;
    public string targetTag = "Castle";
    private bool blockAbove = false;

    void Update()
    {
        RaycastHit hit;

        Vector3 origin = transform.position + Vector3.up * 2.0f;

        Debug.DrawRay(origin, Vector3.up * checkDistance, Color.red);

        if (Physics.Raycast(origin, Vector3.up, out hit, checkDistance))
        {
            Debug.Log("RAYCAST");
            if (hit.collider.CompareTag(targetTag))
            {
                Debug.Log("Correct object above: " + hit.collider.name);
                blockAbove = true;
            }
        }
        BaseCheck();
    }

    public void BaseCheck()
    {
        if (gameObject.CompareTag("CastleBase") && blockAbove == false)
        {
            StartCoroutine(CoUpdate());
        }
        blockAbove = false;
    }



    IEnumerator CoUpdate()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
