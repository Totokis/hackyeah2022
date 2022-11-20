using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private NPCState state;
    [SerializeField] private float range = 0.2f;

    public NPC Owner { get; private set; }

    private void Start()
    {
        if (GetComponent<MeshRenderer>())
            GameObject.Destroy(GetComponent<MeshRenderer>());
        if (GetComponent<MeshFilter>())
            GameObject.Destroy(GetComponent<MeshFilter>());

    }

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

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/AlignWaypointsWithNavmesh", priority = -1000)]
    private static void AlignWaypointsWithNavmesh()
    {
        var waypoints = new List<Waypoint>();

        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            waypoints.AddRange(root.GetComponentsInChildren<Waypoint>());
        }

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (NavMesh.SamplePosition(waypoints[i].transform.position, out NavMeshHit hit, 100f, NavMesh.AllAreas))
            {
                waypoints[i].transform.position = hit.position;
            }
        }

        EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        Debug.Log($"Aligned {waypoints.Count} waypoints");
    }
#endif
}
