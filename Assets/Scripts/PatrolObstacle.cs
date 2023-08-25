using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolObstacle : Obstacle
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * - transform.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.Rotate(0, 180, 0);
            speed *= -1;
        }
    }
}
