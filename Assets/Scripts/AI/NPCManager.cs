using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; }

    [SerializeField] private NPCSpawner spawner;

    private List<NPC> allNPCs = new();

    private void Awake()
    {
        Instance = this;

        allNPCs = spawner.Spawn(30);
    }

    public NPC GetNPCWithState(NPCState state)
    {
        return allNPCs.FindAll(x => x.State == state).Random();
    }

    public List<NPC> GetNPCWithState(NPCState state, int count)
    {
        var npcs = new List<NPC>();

        for (int i = 0; i < count; i++)
        {
            npcs.Add(GetNPCWithState(state));
        }

        return npcs;
    }
}
