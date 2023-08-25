using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class TriggerObstacle : MonoBehaviour
{
    ParticleSystem ps;
    public Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ps != null)
        {
            ps.Play();
        }
        collider.enabled = true;
        Invoke(nameof(Destory), 3f);
    }

    private void Destory()
    {
        Destroy(gameObject);
    }
}
