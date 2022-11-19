using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Queue : MonoBehaviour
{
    [SerializeField] private Waypoint[] waypoints;

    [Space]
    [SerializeField] private float minWaitTime = 5;
    [SerializeField] private float maxWaitTime = 10;

    public List<NPC> NPCsInQueue;

    private void Start()
    {
        NPC.OnStateChanged += NPCOnStateChanged;

        FindNewNPC();
    }

    private void OnDestroy()
    {
        NPC.OnStateChanged -= NPCOnStateChanged;
    }

    private void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            if (NPCsInQueue.Count > 0)
            {
                NPCsInQueue.RemoveAt(0);
                UpdateWaypoints();
            }
        }
    }

    private IEnumerator CallNextCustomerAfter(float seconds)
    {
        while (seconds > 0)
        {
            seconds -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitUntil(() => NPCsInQueue.Count < waypoints.Length);

        FindNewNPC();
    }

    public void FindNewNPC()
    {
        var npc = NPCManager.Instance.GetNPCWithState(NPCState.available);

        if (npc == null)
            return;

        NPCsInQueue.Add(npc);

        UpdateWaypoints();

        StartCoroutine(CallNextCustomerAfter(Random.Range(minWaitTime, maxWaitTime)));
    }

    private void UpdateWaypoints()
    {
        for (int i = 0; i < NPCsInQueue.Count; i++)
        {
            if (i >= waypoints.Length)
                break;

            NPCsInQueue[i].Movement.GoToWaypoint(waypoints[i]);
        }
    }

    private void NPCOnStateChanged(NPC npc, NPCState state)
    {
        if (!NPCsInQueue.Contains(npc))
            return;

        if (state == NPCState.inQueue)
        {
            if (NPCsInQueue[0] == npc)
            {
                //START ORDER;
            }
        }
    }
}
