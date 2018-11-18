namespace UnderwolfStudios.ProjectAlpha
{
    public interface EventListener<T> : EventListenerBase
    {
        void OnEvent(T eventType);
    }
}