using System;

[Serializable]
public class StateMachine
{
    private MonsterController _monsterController;

    public IdleState IdleState;
    public WalkState WalkState;
    
    public IState CurrentState { get; private set; }

    public StateMachine(MonsterController monster)
    {
        _monsterController = monster;

        IdleState = new(monster);
        WalkState = new(monster);
    }
    
    // enum ?
    public void Initialzie(IState state)
    {
        CurrentState = state;
        state.Enter();
        
        StateChanged?.Invoke(state);
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        // notify other objects that state has changed
        StateChanged?.Invoke(nextState);
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public event Action<IState> StateChanged;
}
