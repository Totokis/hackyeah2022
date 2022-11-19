using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCSpawner
{
    [SerializeField] private Transform parent;
    [SerializeField] private NPC prefab;
    [SerializeField] private MinMaxVector3[] positions;

    public List<NPC> Spawn(int count)
    {
        var npcs = new List<NPC>();

        for (int i = 0; i < count; i++)
        {
            var position = positions.Random().Random();

            var npc = Object.Instantiate(prefab, position, Quaternion.identity, parent);

            npc.Init();
            npc.Movement.Warp(position);

            npcs.Add(npc);
        }

        return npcs;
    }
}
