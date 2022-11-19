using Cysharp.Threading.Tasks.Triggers;
using JetBrains.Annotations;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour, INPCReference
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    public Waypoint Waypoint { get; private set; }

    private NPC npc;
    private NavMeshAgent agent;

    public void Init(NPC npc)
    {
        this.npc = npc;

        agent = GetComponent<NavMeshAgent>();
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
        Waypoint.SetOwner(npc);

        npc.SetState(NPCState.movement);
    }

    private void Update()
    {
        if (npc.State != NPCState.movement)
            return;

        var direction = (Waypoint.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        agent.SetDestination(Waypoint.transform.position);
    }
}