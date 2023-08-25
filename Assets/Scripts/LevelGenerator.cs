using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public float waitTime = 10.0f;
    private float spawnZ = 200.0f;
    private bool creatingSection = false;
    private float levelLength = 50.0f;
    private int randomLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateLevel());
        }
    }

    private IEnumerator GenerateLevel()
    {
        randomLevel = Random.Range(0, levelPrefabs.Length);
        Vector3 spawnPoint = new Vector3(0, 0, spawnZ);
        Instantiate(levelPrefabs[randomLevel], spawnPoint, Quaternion.identity);
        spawnZ += levelLength;
        yield return new WaitForSeconds(waitTime);
        creatingSection = false;
    }

    public void Reset()
    {
        StopAllCoroutines();
        spawnZ = 150.0f;
        creatingSection = false;
    }
}
