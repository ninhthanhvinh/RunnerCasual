using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Section"))
        {
            Destroy(other.gameObject);
        }
    }

    void RemoveSection()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(50, 50, 1), Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
