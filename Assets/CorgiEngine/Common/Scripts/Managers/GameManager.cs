using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;

namespace MoreMountains.CorgiEngine
{	
	/// <summary>
	/// A list of the possible Corgi Engine base events
	/// </summary>
	public enum CorgiEngineEventTypes
	{
		LevelStart,
		LevelEnd,
		Pause,
		UnPause,
		PlayerDeath,
		Respawn
	}

	/// <summary>
	/// A type of events used to signal level start and end (for now)
	/// </summary>
	public struct CorgiEngineEvent
	{
		public CorgiEngineEventTypes EventType;
		/// <summary>
		/// Initializes a new instance of the <see cref="MoreMountains.CorgiEngine.CorgiEngineEvent"/> struct.
		/// </summary>
		/// <param name="eventType">Event type.</param>
		public CorgiEngineEvent(CorgiEngineEventTypes eventType)
		{
			EventType = eventType;
		}
	} 

	/// <summary>
	/// A list of the methods available to change the current score
	/// </summary>
	public enum PointsMethods
	{
		Add,
		Set
	}

	/// <summary>
	/// A type of event used to signal changes to the current score
	/// </summary>
	public struct CorgiEnginePointsEvent
	{
		public PointsMethods PointsMethod;
		public int Points;
		/// <summary>
		/// Initializes a new instance of the <see cref="MoreMountains.CorgiEngine.CorgiEnginePointsEvent"/> struct.
		/// </summary>
		/// <param name="pointsMethod">Points method.</param>
		/// <param name="points">Points.</param>
		public CorgiEnginePointsEvent(PointsMethods pointsMethod, int points)
		{
			PointsMethod = pointsMethod;
			Points = points;
		}
	}

    /// <summary>
    /// A list of the methods availble to change the number of chips
    /// </summary>

    public enum ChipsMethods {
        Add,
        Set,
        Spend
    }

    public struct CorgiEngineChipsEvent {
        public ChipsMethods ChipsMethod;
        public int ChipPoints;
       
        ///<summary> 
        /// Initialises a new instance of the chips struct. 
        /// <param name="chipsMethod"> Chips Method</param>
        /// <param name="
        /// </summary>


        public CorgiEngineChipsEvent (ChipsMethods chipsMethod, int chipPoints){
            ChipsMethod = chipsMethod;
            ChipPoints = chipPoints;
        }
    }


	/// <summary>
	/// A list of the methods available to change the current score
	/// </summary>
	public enum TimeScaleMethods
	{
		Set,
		For,
		Reset
	}

	public struct CorgiEngineTimeScaleEvent
	{
		public TimeScaleMethods TimeScaleMethod;
		public float TimeScale;
		public float Duration;

		public CorgiEngineTimeScaleEvent(TimeScaleMethods timeScaleMethod, float timeScale, float duration)
		{
			TimeScaleMethod = timeScaleMethod;
			TimeScale = timeScale;
			Duration = duration;
		}
	}

	public enum PauseMethods
	{
		PauseMenu,
		Inventory
	}


	/// <summary>
	/// The game manager is a persistent singleton that handles points and time
	/// </summary>
	[AddComponentMenu("Corgi Engine/Managers/Game Manager")]
	public class GameManager : 	PersistentSingleton<GameManager>, 
								MMEventListener<MMGameEvent>, 
								MMEventListener<CorgiEngineEvent>, 
								MMEventListener<CorgiEnginePointsEvent>,
                                MMEventListener<CorgiEngineChipsEvent>,
								MMEventListener<CorgiEngineTimeScaleEvent>,
                                MMEventListener<EnergyEvent>,
                                MMEventListener<PowerEvent>
	{		
		/// the target frame rate for the game
		public int TargetFrameRate=300;
		/// the current number of game points
		public int Points { get; private set; }
        /// players's current number of chips
        public int ChipPoints { get; private set; }
        /// player's current energy level
        public float EnergyLevel { get; private set; }
        /// the current power level
        public int PowerLevel {get; private set;}
        /// the current charge 
        public int Charge { get; private set; }
        /// power threshold (the point at which a charge is generated)
        [SerializeField] int PowerThreshold = 30;
        /// player's current energy regeneration rate
		public float EnergyRegenerationSpeed = 1;
		/// true if the game is currently paused
		public bool Paused { get; set; }
        /// true if energy regen is enabled
        public bool EnergyActive { get; set; }
		/// true if we've stored a map position at least once
		public bool StoredLevelMapPosition{ get; set; }
		/// the current player
		public Vector2 LevelMapPosition { get; set; }

	    // storage
		protected Stack<float> _savedTimeScale;
		protected bool _inventoryOpen = false;
		protected bool _pauseMenuOpen = false;
		protected InventoryInputManager _inventoryInputManager;

	    /// <summary>
	    /// On Start(), sets the target framerate to whatever's been specified
	    /// </summary>
	    protected virtual void Start()
	    {
			Application.targetFrameRate = TargetFrameRate;
			_savedTimeScale = new Stack<float> ();
	    }
					
		/// <summary>
		/// this method resets the whole game manager
		/// </summary>
		public virtual void Reset()
		{
			Points = 0;
            ChipPoints = 0;
			Time.timeScale = 1f;
			Paused = false;
			GUIManager.Instance.RefreshPoints ();
            GUIManager.Instance.RefreshChipPoints();
		}	
			
		/// <summary>
		/// Adds the points in parameters to the current game points.
		/// </summary>
		/// <param name="pointsToAdd">Points to add.</param>
		public virtual void AddPoints(int pointsToAdd)
		{
			Points += pointsToAdd;
			GUIManager.Instance.RefreshPoints ();
		}


        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// Adds the ChipPoints in parameters to the current game ChipPoints.
        /// </summary>
        /// <param name="ChipPointsToAdd">ChipPoints to add.</param>
        public virtual void AddChipPoints(int chipPointsToAdd)
        {
            ChipPoints += chipPointsToAdd;
            Debug.Log("Added "+chipPointsToAdd+" chip points");
			GUIManager.Instance.RefreshChipPoints();
		}
		
		/// <summary>
		/// use this to set the current points to the one you pass as a parameter
		/// </summary>
		/// <param name="points">Points.</param>
		public virtual void SetPoints(int points)
		{
			Points = points;
			GUIManager.Instance.RefreshPoints ();
		}

		/// <summary>
		/// use this to set the remove points to the one you pass as a parameter
		/// </summary>
		/// <param name="pointsToRemove">Points to Remove.</param>
		public virtual void RemovePoints(int chipPointsToRemove)
		{
            if (ChipPoints >= 1)
            {
                ChipPoints = ChipPoints - 1;
                GUIManager.Instance.RefreshChipPoints();
            } 
		}



        /// <summary>
        /// use this to set chip points
        /// </summary>
        /// <param name="chipPointsToSet">Chip points to set.</param>

        public virtual void SetChipPoints (int chipPointsToSet) {
            ChipPoints = chipPointsToSet;
			GUIManager.Instance.RefreshChipPoints();
		}


		/// <summary>
		/// use this to add power
		/// </summary>

        public virtual void AddPower (int powerToAdd) {
            /// add power
            PowerLevel = PowerLevel + powerToAdd;
            /// update charges
            updateCharge();
        }


        ///<summary>
        /// use this to remove power
        /// </summary>

        public virtual void RemovePower (int powerToRemove) {
            PowerLevel = PowerLevel - powerToRemove;
            updateCharge();
        }

        ///<summary>
        /// use this to set power
        /// </summary>
        /// <param name="powerToSet">Power to Set </param>

        public virtual void SetPower (int powerToSet) {
            PowerLevel = powerToSet;
            updateCharge();
        }


        ///<summary>
        /// use this to update charges, usually in all events where power is modified.
        /// </summary>


        public virtual void updateCharge () {
			Charge = Mathf.Abs(PowerLevel / PowerThreshold);
		}
         




		/// <summary>
		/// sets the timescale to the one in parameters
		/// </summary>
		/// <param name="newTimeScale">New time scale.</param>
		public virtual void SetTimeScale(float newTimeScale)
		{
			_savedTimeScale.Push(Time.timeScale);
			Time.timeScale = newTimeScale;
		}
		
		/// <summary>
		/// Resets the time scale to the last saved time scale.
		/// </summary>
		public virtual void ResetTimeScale()
		{
			if (_savedTimeScale.Count > 0)
			{
				Time.timeScale = _savedTimeScale.Peek();
				_savedTimeScale.Pop ();	
			}
			else
			{
				Time.timeScale = 1f;
			}
		}

		protected virtual void SetActiveInventoryInputManager(bool status)
		{
			_inventoryInputManager = GameObject.FindObjectOfType<InventoryInputManager> ();
			if (_inventoryInputManager != null)
			{
				_inventoryInputManager.enabled = status;
			}
		}
		
		/// <summary>
		/// Pauses the game or unpauses it depending on the current state
		/// </summary>
		public virtual void Pause(PauseMethods pauseMethod = PauseMethods.PauseMenu)
		{	
			if ((pauseMethod == PauseMethods.PauseMenu) && _inventoryOpen)
			{
				return;
			}

			// if time is not already stopped		
			if (Time.timeScale>0.0f)
			{
				Instance.SetTimeScale(0.0f);
				Instance.Paused=true;
				if ((GUIManager.Instance!= null) && (pauseMethod == PauseMethods.PauseMenu))
				{
					GUIManager.Instance.SetPause(true);	
					_pauseMenuOpen = true;
					SetActiveInventoryInputManager (false);
				}
				if (pauseMethod == PauseMethods.Inventory)
				{
					_inventoryOpen = true;
				}
			}
			else
			{
				UnPause(pauseMethod);
			}		
			LevelManager.Instance.ToggleCharacterPause();
		}

	    /// <summary>
	    /// Unpauses the game
	    /// </summary>
		public virtual void UnPause(PauseMethods pauseMethod = PauseMethods.PauseMenu)
	    {
	        Instance.ResetTimeScale();
	        Instance.Paused = false;
			if ((GUIManager.Instance!= null) && (pauseMethod == PauseMethods.PauseMenu))
	        { 
				GUIManager.Instance.SetPause(false);
				_pauseMenuOpen = false;
				SetActiveInventoryInputManager (true);
	        }
			if (_inventoryOpen)
			{
				_inventoryOpen = false;
			}
	    }


        ///<summary> 
        /// Adds an amount of Energy To Total Game Energy
        /// </summary>


        public virtual void AddEnergy (float amount) {
            EnergyLevel += amount;
            Debug.Log("Added "+amount+"Energy");
        } 

        public virtual void RemoveEnergy (float amount) {
            EnergyLevel -= amount;
            Debug.Log("Added "+amount + "Energy");
        }


        /// <summary>
        /// Sets Amount of Energy
        /// </summary>

        public virtual void SetEnergyLevel (float amount) {
            EnergyLevel = amount;
        }



		///<summary>
		/// Sets Rate of Energy Regeneration
		/// </summary>

		public virtual void SetEnergyRegen (float percentage) {
            EnergyRegenerationSpeed = percentage;
        }

        ///<summary>
        /// Gets Rate of Energy Regeneration
        /// </summary>

        public virtual float getEnergyRegeneration () {
            return EnergyRegenerationSpeed;
        }

        /// <summary>
        /// Gets Energy 
        /// </summary>

        public virtual float getEnergyLevel () {
            return EnergyLevel;
        }




		/// <summary>
		/// Catches MMGameEvents and acts on them, playing the corresponding sounds
		/// </summary>
		/// <param name="gameEvent">MMGameEvent event.</param>
		public virtual void OnMMEvent(MMGameEvent gameEvent)
		{
			switch (gameEvent.EventName)
			{
				case "inventoryOpens":
					Pause (PauseMethods.Inventory);
					break;

				case "inventoryCloses":
					Pause (PauseMethods.Inventory);
					break;
			}
		}

		/// <summary>
		/// Catches CorgiEngineEvents and acts on them, playing the corresponding sounds
		/// </summary>
		/// <param name="engineEvent">CorgiEngineEvent event.</param>
		public virtual void OnMMEvent(CorgiEngineEvent engineEvent)
		{
			switch (engineEvent.EventType)
			{
				case CorgiEngineEventTypes.Pause:
					Pause ();
					break;
				
				case CorgiEngineEventTypes.UnPause:
					UnPause ();
					break;
			}
		}

		/// <summary>
		/// Catches CorgiEnginePointsEvents and acts on them, playing the corresponding sounds
		/// </summary>
		/// <param name="pointEvent">CorgiEnginePointsEvent event.</param>
		public virtual void OnMMEvent(CorgiEnginePointsEvent pointEvent)
		{
			switch (pointEvent.PointsMethod)
			{
				case PointsMethods.Set:
					SetPoints (pointEvent.Points);
					break;

				case PointsMethods.Add:
					Debug.LogError("Adding");
					AddPoints (pointEvent.Points);
					break;
			}
		}

		/// <summary>
		/// Catches CorgiEngineChipsEvents and acts on them, playing the corresponding sounds
		/// </summary>
		/// <param name="chipEvent">CorgiEngineChipsEvent event.</param>
		public virtual void OnMMEvent(CorgiEngineChipsEvent chipsEvent)
		{
			switch (chipsEvent.ChipsMethod)
			{
                case ChipsMethods.Spend:
                    RemovePoints(chipsEvent.ChipPoints);
                    break;

				case ChipsMethods.Add:
                    AddChipPoints(chipsEvent.ChipPoints);
					break;

                case ChipsMethods.Set:
                    SetChipPoints(chipsEvent.ChipPoints);
                    break;
			}
		}


        /// <summary>
        /// Catches CorgiEngineEnergyEvents and acts on them 
        /// </summary>
        /// <param name="EnergyEvent">EnergyEvent</param> 
        /// 

        public virtual void OnMMEvent(EnergyEvent energyEvent) {
            switch(energyEvent.energyEventType) {
                case (EnergyEventType.Add) :
                    AddEnergy(energyEvent.amount);
                    break;

                case (EnergyEventType.Remove) :
                    RemoveEnergy(energyEvent.amount);
                    break;
            }

        }


		/// <summary>
		/// Catches PowerEvent and acts on them 
		/// </summary>
		/// <param name="PowerEvent">PowerEvent</param> 
		/// 

		public virtual void OnMMEvent(PowerEvent powerEvent)
		{
			switch (powerEvent.powerEventType)
			{
                case (PowerEventType.Add):
                    AddPower(powerEvent.amount);
					break;
                case (PowerEventType.Remove):
					RemovePower(powerEvent.amount);
					break;
                case (PowerEventType.Set):
                    SetPower(powerEvent.amount);
                    break;
			}

		}


		/// <summary>
		/// Catches CorgiEngineTimeScaleEvents and acts on them, playing the corresponding sounds
		/// </summary>
		/// <param name="timeScaleEvent">CorgiEngineTimeScaleEvent event.</param>
		public virtual void OnMMEvent(CorgiEngineTimeScaleEvent timeScaleEvent)
		{
			switch (timeScaleEvent.TimeScaleMethod)
			{
				case TimeScaleMethods.Reset:
					ResetTimeScale ();
					break;

				case TimeScaleMethods.Set:
					SetTimeScale (timeScaleEvent.TimeScale);
					break;

				case TimeScaleMethods.For:
					StartCoroutine (ChangeTimeScaleForCo (timeScaleEvent.TimeScale, timeScaleEvent.Duration));
					break;
			}
		}

		protected virtual IEnumerator ChangeTimeScaleForCo(float newTimeScale, float timeScaleDuration)
		{
			SetTimeScale (newTimeScale);
			GUIManager.Instance.SetTimeSplash (true);
			// we multiply the duration by the timespeed to get the real duration in seconds
			yield return new WaitForSeconds(timeScaleDuration);
			ResetTimeScale ();
			GUIManager.Instance.SetTimeSplash (false);
		}

		/// <summary>
		/// OnEnable, we start listening to events.
		/// </summary>
		protected virtual void OnEnable()
		{
			this.MMEventStartListening<MMGameEvent> ();
			this.MMEventStartListening<CorgiEngineEvent> ();
			this.MMEventStartListening<CorgiEnginePointsEvent> ();
            this.MMEventStartListening<CorgiEngineChipsEvent>();
			this.MMEventStartListening<CorgiEngineTimeScaleEvent> ();
            this.MMEventStartListening<EnergyEvent>();
            this.MMEventStartListening<PowerEvent>();
		}

		/// <summary>
		/// OnDisable, we stop listening to events.
		/// </summary>
		protected virtual void OnDisable()
		{
			this.MMEventStopListening<MMGameEvent> ();
			this.MMEventStopListening<CorgiEngineEvent> ();
			this.MMEventStopListening<CorgiEnginePointsEvent> ();
			this.MMEventStopListening<CorgiEngineChipsEvent>();
			this.MMEventStopListening<CorgiEngineTimeScaleEvent> ();
            this.MMEventStopListening<EnergyEvent>();
			this.MMEventStopListening<PowerEvent>();

		}
	}
}