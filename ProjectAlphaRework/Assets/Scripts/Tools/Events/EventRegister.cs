namespace Tools.Events
{
    public class EventRegister
    {
        public delegate void Delegate<T>( T eventType );

        public static void MMEventStartListening<EventType>(EventListener<EventType> caller) where EventType : struct
        {
            EventManager.AddListener<EventType>( caller );
        }

        public static void MMEventStopListening<EventType>(EventListener<EventType> caller) where EventType : struct
        {
            EventManager.RemoveListener<EventType>( caller );
        }
    }
}