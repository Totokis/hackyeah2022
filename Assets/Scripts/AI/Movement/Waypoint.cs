using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private NPCState state;
    [SerializeField] private float range = 0.2f;

    public NPC Owner { get; private set; }

    public void SetOwner(NPC owner)
    {
        Owner = owner;
    }

    private void Update()
    {
        if (!Owner)
            return;

        if (Owner.State != NPCState.movement)
            return;

        if (IsOwnerOnWaypoint())
        {
            Owner.SetState(state);
            Owner.transform.forward = transform.forward;
        }
    }

    public bool IsOwnerOnWaypoint()
    {
        if (!Owner)
            return false;

        return Vector3.Distance(transform.position, Owner.transform.position) <= range;
    }
}
