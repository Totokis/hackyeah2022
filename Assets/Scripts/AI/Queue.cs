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
                OnOrderCompleted(true);
            }
        }

        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            if (NPCsInQueue.Count > 0)
            {
                OnOrderCompleted(false);
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
                npc.Customer.OnStartWaiting(OnOrderCompleted);
            }
        }
    }

    private void OnOrderCompleted(bool success)
    {
        if (success)
        {
            NPCsInQueue[0].Movement.GoToWaypoint(Party.Instance.GetEmptyWaypoint());

            var count = Random.Range(0, 4);

            for (int i = 0; i < count; i++)
            {
                var npc = NPCManager.Instance.GetNPCWithState(NPCState.available);

                if (npc)
                    npc.Movement.GoToWaypoint(Party.Instance.GetEmptyWaypoint());
            }
        }
        else
        {
            NPCsInQueue[0].Movement.GoToPosition(new Vector3(13.7f, 0, -8.3f));

            var count = Random.Range(0, 4);

            for (int i = 0; i < count; i++)
            {
                var npc = NPCManager.Instance.GetNPCWithState(NPCState.onParty);

                if (npc)
                    npc.Movement.GoToPosition(new Vector3(48, 0, 48));
            }
        }

        NPCsInQueue.RemoveAt(0);
        UpdateWaypoints();
    }
}
