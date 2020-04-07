using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace UnderwolfStudios.ProjectAlpha
{
    
    public static class EventManager
    {
        private static Dictionary<Type, List<EventListenerBase>> _subscribers;

        static EventManager()
        {
            _subscribers = new Dictionary<Type, List<EventListenerBase>>();
        }
        
        public static void AddListener<GameEvent>(EventListener<GameEvent> listener)  where GameEvent : struct
        {
            Type eventType = typeof(GameEvent);
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers[eventType] = new List<EventListenerBase>();
            }
            else
            {
                _subscribers[eventType].Add(listener);
            }
            
        
        }

        public static void RemoveListener<GameEvent>(EventListener<GameEvent> listener) where GameEvent : struct
        {
            Type eventType = typeof(GameEvent);

            if (_subscribers.ContainsKey(eventType))
            {
                _subscribers[eventType].Remove(listener);
            }
            else
            {
                throw new ArgumentException(string.Format("Trying to remove listener that does not exist"));
            }
            
        }
        

        public static void TriggerEvent<GameEvent>(GameEvent gameEvent)
        {
            Type eventType = typeof(GameEvent);
            
            foreach (var subscriber in _subscribers[eventType])
            {
                try
                {
                    (subscriber as EventListener<GameEvent>).OnEvent(gameEvent);

                }
                catch (Exception e)
                {
                    Debug.Log("Error in Triggering Event" + e);
                }       
            }  
        }

        public static bool SubscriptionExists(Type type, EventListenerBase receiver)
        {
            return (_subscribers.ContainsKey(type) && _subscribers[type].Contains(receiver));
        }
        
    }
}