using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnermyAI : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Wandering
    }

    [Header("Stats")]
    public float speed;

    [Header("AI")]
    private AIState aiState;
    public float detectDistance;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    public float playerDistance;

    private NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetState(AIState.Wandering);
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, CharacterManager.Instance.Player.transform.position);

        switch (aiState)
        {
            case AIState.Idle:
                PassiveUpdate();
                break;
            case AIState.Wandering:
                PassiveUpdate();
                break;
        }
    }

    public void SetState(AIState state)
    {
        aiState = state;

        switch (aiState) 
        {
            case AIState.Idle:
                agent.speed = speed;
                agent.isStopped = true;
                break;
            case AIState.Wandering:
                agent.speed = speed;
                agent.isStopped = false;
                break;
        }
    }

    void PassiveUpdate()
    {
        if(aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }
    }

    void WanderToNewLocation()
    {
        if (aiState != AIState.Idle) return;

        SetState(AIState.Wandering);
        agent.SetDestination(GetWanderLocation());
    }

    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;

        while(Vector3.Distance(transform.position, hit.position) < detectDistance)
        {
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if(i == 30) break;
        }
        return hit.position;
    }
}
