namespace Tools.Events
{
    public interface EventListener<T> : EventListenerBase
    {
        void OnEvent(T eventType);
    }
}