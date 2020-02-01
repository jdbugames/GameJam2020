using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnerPointController : MonoBehaviour
{
    [SerializeField]
    private GameObject client;

    [SerializeField]
    private Transform pointDestination;

    [SerializeField]
    private Transform pointDelivery;

    [SerializeField]
    private float spawnerTime;

    [SerializeField]
    private int numberClients;

    [SerializeField]
    private bool canSpawner;


    private void Start()
    {
        StartCoroutine(RatSpawn());
    }

    IEnumerator RatSpawn()
    {
        int ratsSpawned = 0;
        while (canSpawner && ratsSpawned < numberClients)
        {
            Instantiate(client, this.transform.position, Quaternion.identity);
            ratsSpawned++;
            canSpawner = !canSpawner;

            yield return new WaitForSeconds(spawnerTime);
            canSpawner = !canSpawner;
        }
    }
}
