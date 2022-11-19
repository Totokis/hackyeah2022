using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Cysharp.Threading.Tasks;

public class MallDummyAI : MonoBehaviour
{
    public NavMeshAgent Agent => _agent;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private CharacterAnimator _characterAnimator;

    private Waypoint _waypoint;
    private Vector3 _localVelocity;
    private CrowdManager _cm;
    private void Start()
    {
        _cm = CrowdManager.Instance;
    }

    public void SetWaypoint(Waypoint waypoint)
    {
        _waypoint= waypoint;
        _agent.SetDestination(waypoint.transform.position);
        CheckDistance();
    }

    void Update()
    {
        _localVelocity = transform.InverseTransformDirection(_agent.velocity);
        _characterAnimator.UpdateAnimator(_localVelocity);
    }

    async UniTask CheckDistance()
    {
        while((_agent?.remainingDistance > _agent?.stoppingDistance + 0.1f))
        {
            if(!_agent) return;

            await UniTask.NextFrame();
        }
        await UniTask.Delay(100);

        _cm.AddWaypoint(_waypoint);
        _cm.OrderDummy(this, _cm.GetWaypoint());
    }
}