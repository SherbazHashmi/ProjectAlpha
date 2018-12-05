using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnderwolfStudios.ProjectAlpha
{
   
    [AddComponentMenu("Corgi Engine/Managers/Game Manager")]
    public class GameManager : Singleton<GameManager>, EventListener<EngineEvent>, EventListener<PointsEvent>, EventListener<EnergyEvent>
    {
        public int Points { get; private set; }
        public float Energy { get; private set; }
        public float EnergyMax { get; private set; }
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

        public void OnEvent(EnergyEvent energyEvent)
        {
            switch (energyEvent.EnergyEventType)
            {
                case EnergyEventType.AddAll:
                    Energy = EnergyMax;
                    break;
                case EnergyEventType.Add:
                    Energy++;
                    break;
                case EnergyEventType.Remove:
                    Energy--;
                    break;
                case EnergyEventType.RemoveAll:
                    Energy = 0;
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

    public enum EnergyEventType
    {
        Add,
        Remove,
        AddAll,
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

    public struct EnergyEvent
    {
        public EnergyEventType EnergyEventType;

        public EnergyEvent(EnergyEventType energyEventType)
        {
            this.EnergyEventType = energyEventType;
        }

    }





}
