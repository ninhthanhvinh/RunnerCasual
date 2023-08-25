using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField] private int reward;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("Player"))
        {
            //SFX + VFX
            other.GetComponent<Player>().AddReward(reward);
            Destroy(gameObject);
        }
    }
}
