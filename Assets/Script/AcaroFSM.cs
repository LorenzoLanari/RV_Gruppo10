using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AcaroFSM : MonoBehaviour
{
    [SerializeField] private List<Vector3> _waypoints;
    public GameObject _target;
    [SerializeField] private Collider _groundCollider;
    [SerializeField] private float _minChaseDistance = 3f;
    [SerializeField] private float _minAttackDistance = 2f;
    [SerializeField] private float _stoppingDistance = 1f;
    public Animator _animator;
    public bool Attacking = false;
    private FiniteStateMachine<AcaroFSM> _stateMachine;

    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;
    

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _stateMachine = new FiniteStateMachine<AcaroFSM>(this);

        _target = GameObject.FindGameObjectWithTag("Player");
        _groundCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
        //transform.localRotation = Quaternion.Euler(0f, 90f, 0.0f);

        _animator = GetComponentInChildren<Animator>();

        //STATES
        State patrolState = new PatrolState("Patrol", this);
        State chaseState = new ChaseState("Chase", this);
        State stopState = new StopState("Stop", this);

        //TRANSITIONS
        _stateMachine.AddTransition(patrolState, chaseState, () => DistanceFromTarget() <= _minChaseDistance);
        _stateMachine.AddTransition(chaseState,patrolState, () => DistanceFromTarget() > _minChaseDistance);
        _stateMachine.AddTransition(chaseState,stopState, () => DistanceFromTarget() <= _stoppingDistance);
        _stateMachine.AddTransition(stopState,chaseState, () => DistanceFromTarget() > _stoppingDistance);

        //WAYPOINTS
        for (int i = 0; i < 5; i++)
        {
            Vector3 min = _groundCollider.bounds.min;
            Vector3 max = _groundCollider.bounds.max;          
            Vector3 tmp_vec = new Vector3(UnityEngine.Random.Range(min.x, max.x), 2f, UnityEngine.Random.Range(min.z, max.z));         
            _waypoints.Add(tmp_vec); 
        }
        //START STATE
        _stateMachine.SetState(patrolState);
    }

    void Update() => _stateMachine.Tik();
    public void StopAgent(bool stop) => _navMeshAgent.isStopped = stop;
    public void SetWayPointDestination()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0f)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex];
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    }
    public void FollowTarget() => _navMeshAgent.SetDestination(_target.transform.position);
    
    //TRANSITION FUNCTIONS
    private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);


    public void ProvideDamage()
    {
       
        Attacking = false;
    }
}

public class PatrolState : State
{
    private AcaroFSM _guard;
    public PatrolState(string name, AcaroFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(false);
        
    }

    public override void Tik()
    {

        _guard.SetWayPointDestination();
    }

    public override void Exit()
    {
        
    }
}

public class ChaseState : State
{
    private AcaroFSM _guard;
    public ChaseState(string name, AcaroFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(false);
       
    }

    public override void Tik()
    {
        _guard.FollowTarget();
    }

    public override void Exit()
    {
    }
}

public class StopState : State
{
    private AcaroFSM _guard;
    public StopState(string name, AcaroFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(true);
        
    }

    public override void Tik()
    {
        if (!_guard.Attacking)
        {
            _guard.Attacking = true;
            if(_guard._animator !=null)
                _guard._animator.SetTrigger("attack");
            _guard._target.GetComponent<Rob_Health>().TakeDamage(1);
            _guard.Invoke("ProvideDamage", 2f);
            
        }
         
    }

    public override void Exit()
    {
    }

}
