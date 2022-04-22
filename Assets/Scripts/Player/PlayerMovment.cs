using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Shooting))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private Animator _animator;

    private Shooting _shooting;
    private NavMeshAgent _agent;
    private float _nextPointDistance;
    private float _requiredDistance = 0.2f;
    private int _currentWayPoint;

    private const string _running = "Running";

    public event UnityAction LastWayPointTaken;

    private void Awake()
    {
        _animator.SetBool(_running, false);
        _agent = GetComponent<NavMeshAgent>();
        _shooting = GetComponent<Shooting>();
        _shooting.enabled = false;
        _currentWayPoint = 0;
    }

    private void Update()
    {
        if (_currentWayPoint == 0)
        {
            while (!Input.GetMouseButton(0))
            {
                return;
            }
            _shooting.enabled = true;
        }

        _nextPointDistance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].transform.position);

        if (_wayPoints[_currentWayPoint].AliveEnemy == 0 && _nextPointDistance < _requiredDistance)
        {
            if (_currentWayPoint < _wayPoints.Length - 1)
            {
                GoToNextPoint();
            }
            else
            {
                LastWayPointTaken?.Invoke();
            }
        }

        if (Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].transform.position) < _requiredDistance)
        {
            _animator.SetBool(_running, false);
        }
    }

    private void GoToNextPoint()
    {
        _currentWayPoint++;
        _agent.SetDestination(_wayPoints[_currentWayPoint].transform.position);
        _animator.SetBool(_running, true);
    }
}
