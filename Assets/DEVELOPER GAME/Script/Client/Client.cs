using UnityEngine.AI;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Transform pointDestination;



    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //pointDestination = ManagerClient.instance.positionFinal;

        //navMeshAgent.SetDestination(pointDestination.position);

        navMeshAgent.SetDestination(ManagerClient.instance.positionFinal[Random.Range(0,3)].position);
    }
}
