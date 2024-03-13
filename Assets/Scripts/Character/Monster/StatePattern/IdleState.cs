
using UnityEngine;

public class IdleState : IState
{
    private float _timer;
    private MonsterController _monster;

    public IdleState(MonsterController monster)
    {
        _monster = monster;
    }
    
    public void Enter()
    {
        _timer = 0;
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 2.0f)
        {
            _monster.StateMachine.TransitionTo(_monster.StateMachine.WalkState);
        }
    }

    public void Exit()
    {
        
    }
}
