using System;

public class EventManager : Singleton<EventManager>
{
    public class ESVoidEvent
    {
        public event Action EventChannel;
        public void RaiseEvent() =>  EventChannel?.Invoke();
    }
    
    public class ESGenericEvent<T>
    {
        public event Action<T> EventChannel;
        public void RaiseEvent(T t) =>  EventChannel?.Invoke(t);
    }
    
    // public static Action OnPlayerDead;

    public ESVoidEvent PlayerDead;
}
