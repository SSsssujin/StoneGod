using System.Collections;

public interface IState
{
    public void Enter();
    public IEnumerator cUpdate();
    public void Exit();
}
