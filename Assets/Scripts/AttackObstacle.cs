using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObstacle : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * -transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}
