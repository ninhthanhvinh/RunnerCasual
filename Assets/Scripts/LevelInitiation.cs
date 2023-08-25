using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitiation : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] collectibleObjs;

    private int obstacleCount;
    private int collectibleCount;

    // Start is called before the first frame update
    void Awake()
    {
        obstacleCount = Random.Range(1, 4);
        collectibleCount = Random.Range(1, 4);
    }

    private void Start()
    {
        for(int i = 0; i < obstacleCount; i++)
        {
            int randomX = Random.Range(-7, 7);
            int randomY = Random.Range(-10, 25);
            Vector3 randomPos = new Vector3(randomX, 0, randomY) + transform.position;
            int randomObstacle = Random.Range(0, obstacles.Length);
            GameObject obstacle = Instantiate(obstacles[randomObstacle], randomPos, obstacles[randomObstacle].transform.rotation);
            obstacle.transform.SetParent(transform);
        }

        for(int j = 0; j < collectibleCount; j++)
        {
            int randomX = Random.Range(-7, 7);
            int randomY = Random.Range(-25, 25);
            Vector3 randomPos = new Vector3(randomX, 2, randomY) + transform.position;
            GameObject collecting = Instantiate(collectibleObjs[Random.Range(0, collectibleObjs.Length)], randomPos, Quaternion.identity);
            collecting.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
