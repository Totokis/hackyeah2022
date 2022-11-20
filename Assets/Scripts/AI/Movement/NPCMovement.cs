using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NPCMovement : MonoBehaviour, INPCReference
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    public Waypoint Waypoint { get; private set; }

    private Vector3 targetPosition;

    private NPC npc;
    private NavMeshAgent agent;
    private CharacterAnimator _characterAnimator;

    public void Init(NPC npc)
    {
        this.npc = npc;

        agent = GetComponent<NavMeshAgent>();
        _characterAnimator = GetComponent<CharacterAnimator>();
    }


    public void Warp(Vector3 position)
    {
        agent.Warp(position);
    }

    public void GoToWaypoint(Waypoint waypoint)
    {
        if (Waypoint == waypoint)
            return;

        Waypoint?.SetOwner(null);

        Waypoint = waypoint;

        if (Waypoint)
        {
            Waypoint.SetOwner(npc);

            npc.SetState(NPCState.movement);
            SetTargetPosition(Waypoint.transform.position);
        }
    }

    public void GoToPosition(Vector3 position)
    {
        GoToWaypoint(null);
        SetTargetPosition(position);
    }

    private void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
        agent.SetDestination(targetPosition);
    }

    private void Update()
    {        
        float angle = Vector3.SignedAngle(agent.velocity.normalized, agent.desiredVelocity.normalized, transform.up);
        _characterAnimator.UpdateAnimator(transform.InverseTransformDirection(agent.velocity), angle);

        if (npc.State != NPCState.movement)
            return;

        var direction = (targetPosition - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotateSpeed);


    }
}