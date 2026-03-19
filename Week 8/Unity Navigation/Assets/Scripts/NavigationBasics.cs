using UnityEngine;
using UnityEngine.AI;

public class NavigationBasics : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //agent.updateRotation = false;
        //agent.updatePosition = false;

        if (!agent.SetDestination(target.position))
        {
            print("Destination not on NavMesh");
        }
        
        //agent.destination = target.position;
    }

    void Update()
    {
        
    }
}
