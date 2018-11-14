using System;
using System.Security.Cryptography.X509Certificates;

namespace Tools.Events
{

    public struct GameEvent
    {
        public string EventName;

        public GameEvent(string eventName)
        {
            EventName = eventName;
        }
    }

    public class EventManager
    {
        
    }
}