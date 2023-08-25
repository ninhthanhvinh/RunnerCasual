using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltLevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    private void OnTriggerEnter(Collider other)
    {
        int x = Random.Range(0, levelPrefabs.Length);
        Instantiate(levelPrefabs[x], transform.position + new Vector3(0, 0, 200), levelPrefabs[x].transform.rotation);
    }
}
