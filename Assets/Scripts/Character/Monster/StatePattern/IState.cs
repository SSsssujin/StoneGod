using System.Collections;

public interface IState
{
    public void Enter();
    public void Update(); //IEnumerator로?
    public void Exit();

    //public IEnumerator cUpdate();
}
