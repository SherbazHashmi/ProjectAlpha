using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnderwolfStudios.ProjectAlpha
{
   
    [AddComponentMenu("Corgi Engine/Managers/Game Manager")]
    public class GameManager : Singleton<GameManager>, EventListener<EngineEvent>,EventListener<PointsEvent>
    {
        public int Points { get; private set; }
        public bool Paused { get; private set; }
        
        public void OnEvent(EngineEvent engineEvent)
        {
            switch (engineEvent.EventType)
            {
                case EngineEventType.Pause:
                    // TODO Kevern : Add HUD CODE HERE 
                    Instance.Paused = true;
                    
                    throw new System.NotImplementedException();
                    break;
                    
                 case EngineEventType.Resume:
                     // TODO Kevern : Add HUD CODE HERE 
                     Instance.Paused = false;
                     throw new System.NotImplementedException();
                     break;         
                 
            }
        }


        private void OnEnable()
        {
            this.EventStartListening<EngineEvent>();
            this.EventStartListening<PointsEvent>();
        }

        private void OnDisable()
        {
            this.EventStopListening<EngineEvent>();
            this.EventStopListening<PointsEvent>();
        }

        public void OnEvent(PointsEvent pointsEvent)
        {
            switch (pointsEvent.PointsEventType)
            {
                case PointsEventType.Add :
                    Points++;
                    break;
                case PointsEventType.Remove:
                    Points--;
                    break;
                case PointsEventType.RemoveAll:
                    Points = 0;
                    break;
            }
        }
    }
    
    public enum EngineEventType
    {
        LevelStart, LevelEnd, Pause, Resume, Death, Respawn
    }

    public struct EngineEvent
    {
        public readonly EngineEventType EventType;

        public EngineEvent(EngineEventType eventType)
        {
            EventType = eventType;
        }
    }


    public enum PauseMethods
    {
        PauseMenu, 
        TalentMenu
    }

    public enum PointsEventType
    {
        Add, 
        Remove,
        RemoveAll
    }

    public struct PointsEvent
    {
        public PointsEventType PointsEventType;

        public PointsEvent(PointsEventType pointsEventType)
        {
            this.PointsEventType = pointsEventType;
        }
        
    }
    
    
    
    

}
