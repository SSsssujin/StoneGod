using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class WalkState : IState
{
    private readonly MonsterController _monster;

    private Vector3? _nullableInitalPosition;

    public WalkState(MonsterController monster)
    {
        _monster = monster;
    }
    
    public void Enter()
    {
        // if null, caching position
        _nullableInitalPosition ??= _monster.transform.position; // Has it moved to constructor?
        _monster.StartCoroutine(_cDoWalk());

        _agent.updatePosition = true;
        _agent.autoRepath = true;
    }

    public void Update()
    {
    }

    public void Exit()
    {
        _monster.StopCoroutine(nameof(_cDoWalk));
    }

    public IEnumerator _cDoWalk()
    {
        while (true)
        {
            Debug.Log("Move agent");
            
            _agent.SetDestination(_GetRandomDestination());
            
            yield return new WaitUntil(() => _IsReachDestination() == true);
            
            Debug.Log("Reach");

            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }

    private bool _IsReachDestination()
    {
        // !_agent.pathPending && !_agent.isStopped
        // _agent.remainingDistance <= _agent.stoppingDistance
        
        return _agent.remainingDistance <= _agent.stoppingDistance;
    }

    private Vector3 _GetRandomDestination()
    {
        Vector3 distWeight = new Vector3(_GetRandomWeightDist, 0, _GetRandomWeightDist);
        Vector3 newPos = _agent.transform.position + distWeight;
        if (Vector3.Distance(newPos, _initalPosition) > 5f)
        {
            Debug.Log("Set newPos to initial pos");
            newPos = _initalPosition;
        }
        return newPos;
    }

    // Private properties        
    private float _GetRandomWeightDist => Random.Range(-5f, 5f);
    private Vector3 _initalPosition => _nullableInitalPosition ??= Vector3.zero;
    private NavMeshAgent _agent => _monster.NavMeshAgent;
}
