namespace UnderwolfStudios.ProjectAlpha
{
    public static class EventRegister
    {
        public delegate void Delegate<T>( T eventType );

        public static void EventStartListening<EventType>( this EventListener<EventType> caller ) where EventType : struct
        {
            EventManager.AddListener<EventType>( caller );
        }

        public static void EventStopListening<EventType>( this EventListener<EventType> caller ) where EventType : struct
        {
            EventManager.RemoveListener<EventType>( caller );
        }
    }
}