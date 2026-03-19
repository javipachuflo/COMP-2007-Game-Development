using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolBehaviour : MonoBehaviour
{
    public CheckpointSystem checkpointSystem;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(checkpointSystem.CurrentPoint);

        GotoNextPoint();
    }

    void Update()
    {
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {
        checkpointSystem.NextPoint();
        agent.SetDestination(checkpointSystem.CurrentPoint);
    }
}
