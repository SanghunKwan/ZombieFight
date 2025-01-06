using UnityEngine;
using UnityEngine.AI;

public class tempMonster : MonoBehaviour
{
    NavMeshAgent agent;
    bool isForward;
    Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(transform.position + (Vector3.forward * 3));
        startPos = transform.position;

    }
    private void Update()
    {
        Debug.Log(agent.transform.position);
        if (agent.hasPath)
            return;

        if (isForward)
        {
            agent.SetDestination(transform.position + (Vector3.forward * 3) + (Vector3.right * 3));
        }
        else
            agent.SetDestination(startPos);
        isForward = !isForward;

    }


}
