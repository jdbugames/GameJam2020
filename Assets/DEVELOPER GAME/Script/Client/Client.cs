using UnityEngine.AI;
using UnityEngine;
using System;

public class Client : MonoBehaviour
{
    [SerializeField]
    private GameObject objectDeliver;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform pointDestination;
    [SerializeField]
    private Transform pointDelivery;
    [SerializeField]
    private bool deliveredObject = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(pointDestination.transform.position);
    }

    private void Update()
    {
        if(transform.position == pointDestination.position)
        {
            DeliverObject();
        }
    }

    private void DeliverObject()
    {
        deliveredObject = true;
        objectDeliver.transform.parent = pointDelivery;
        objectDeliver.transform.localPosition = new Vector3(0, 0, 0);
    }
}
