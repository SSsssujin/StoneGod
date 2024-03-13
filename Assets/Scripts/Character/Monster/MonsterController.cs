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
        _stateMachine.StateChanged += _PrintCurrentState;
        MonsterBinded += _OnMonsterBinded;
    }

    private void Start()
    {
        _stateMachine.Initialzie(_stateMachine.IdleState);
    }

    private void Update()
    {
        //_stateMachine.Update();
    }

    private void _PrintCurrentState(IState state)
    {
        //Debug.Log("State changed : " + state);
    }

    private void _OnMonsterBinded(bool isDefenseReduced)
    {
        //Debug.Log(gameObject + " is bind!!");
        //_stateMachine.TransitionTo(BindState);
        
        //if (isDefenseReduced)
        //  DefensePower --;
    }
    
    
    // Public properties
    public Action<bool> MonsterBinded;
    public StateMachine StateMachine => _stateMachine;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
}
