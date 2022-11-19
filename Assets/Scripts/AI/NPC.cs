using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public static event Action<NPC, NPCState> OnStateChanged;

    public Customer Customer;
    public NPCMovement Movement { get; private set; }

    public NPCState State { get; private set; } = NPCState.available;

    public void Init()
    {
        Customer = GetReference<Customer>();
        Movement = GetReference<NPCMovement>();
    }

    private T GetReference<T>() where T : INPCReference
    {
        var reference = GetComponent<T>();
        reference.Init(this);
        return reference;
    }
    public void SetState(NPCState state)
    {
        State = state;

        Debug.Log($"SetState({name}, {state})");
        OnStateChanged?.Invoke(this, state);
    }

    public void CustomerFinished(Boolean isSuccess)
    {

    }
}

public interface INPCReference
{
    public void Init(NPC npc);
}