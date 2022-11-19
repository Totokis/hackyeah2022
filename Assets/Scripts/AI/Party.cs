using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public static Party Instance;

    [SerializeField] private List<Waypoint> waypoints;

    private void Awake()
    {
        Instance = this;
    }

    public Waypoint GetEmptyWaypoint()
    {
        return waypoints.Find(x => x.Owner == null);
    }
}
