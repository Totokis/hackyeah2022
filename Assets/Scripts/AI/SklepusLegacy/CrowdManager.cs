using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public static CrowdManager Instance; //hehe bo wiecie :-DDD

    [SerializeField] private List<Waypoint> _waypoints = new List<Waypoint>();
    [SerializeField] private List<Waypoint> _takenWaypoints = new List<Waypoint>();      
    [SerializeField] private List<MallDummyAI> _dummys = new List<MallDummyAI>();      

    [EasyButtons.Button]
    private void FindReferences()
    {
        _waypoints = new List<Waypoint>(FindObjectsOfType<Waypoint>());
        _dummys = new List<MallDummyAI>(FindObjectsOfType<MallDummyAI>());
    }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < _dummys.Count; i++)
        {
            Waypoint waypoint = _waypoints[Random.Range(0, _waypoints.Count)];
            _dummys[i].Agent.avoidancePriority = i;
            OrderDummy(_dummys[i], waypoint);
        }
    }

    public void OrderDummy(MallDummyAI dummy, Waypoint waypoint)
    {
        dummy.SetWaypoint(waypoint);
        _waypoints.Remove(waypoint);
    }

    public void AddWaypoint(Waypoint waypoint)
    {
        _waypoints.Add(waypoint);
    }

    public Waypoint GetWaypoint()
    {
        Waypoint waypoint = _waypoints[Random.Range(0, _waypoints.Count)];
        _waypoints.Remove(waypoint);
        return waypoint;
    }
}