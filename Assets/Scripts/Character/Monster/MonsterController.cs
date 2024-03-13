using System;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private MonsterCharacter _monsterCharacter;
    private StateMachine _stateMachine;
    
    // Components
    private NavMeshAgent _navMeshAgent;

    // 
    private void Awake()
    {
        // Caching
        _stateMachine = new StateMachine(this);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        // Add listeners
        _stateMachine.OnStateChanged += _PrintCurrentState;
        OnMonsterBinded += _OnMonsterBinded;
    }

    private void Start()
    {
        //_stateMachine.Initialzie(_stateMachine.IdleState);
    }

    private void Update()
    {
        //_stateMachine.Update();
    }

    private void _PrintCurrentState(IState state)
    {
        Debug.Log("State changed : " + state);
    }

    private void _OnMonsterBinded(bool isDefenseReduced)
    {
        Debug.Log(gameObject + " is bind!!");
        //_stateMachine.TransitionTo(BindState);
    }
    
    
    // Public properties
    public Action<bool> OnMonsterBinded;
    public StateMachine StateMachine => _stateMachine;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
}
