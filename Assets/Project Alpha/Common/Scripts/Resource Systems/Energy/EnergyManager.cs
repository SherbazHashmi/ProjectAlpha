using System;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{

    [AddComponentMenu("Project Alpha/Managers/EnergyManager")] 

    public class EnergyManager : MonoBehaviour
    {

        /// <summary>
        /// Stating Global Variables 
        /// </summary>
        
        [Header("Energy")]
        [SerializeField] bool isRegenActive = true;
        [SerializeField] protected int PassiveEnergyIncreaseRate;
        [SerializeField] protected  int multiplier = 1;
        
        [Header("Bar")]
        [SerializeField] private GameObject BarObject;
        [SerializeField] GameObject BarBackgroundObject;
        [SerializeField] private GameObject zeroReference;
        
        [Header("Debug")]
        [SerializeField] Text DebugText;

        private GameObject _gameManagerObject;
        private GameManager  _gameManager;
        Transform BarBackground;
        private SpriteRenderer BarSprite;
        private float elapsed = 0f;
        Vector2 BarFullSize;
        GameObject _inputManagerObject;
        private InputManager _inputManager;
        private QuantumRun _characterRun;
        protected CharacterHorizontalMovement _characterBasicMovement;
        GameObject _characterObject;
        protected bool isRunning; 

        /// <summary>
        /// Initialises all global variables. 
        /// </summary>

        void Initialisation()
        {
            // Initialises Game Manager 
            try
            {
                _gameManagerObject = GameObject.Find("GameManager");
                _gameManager = _gameManagerObject.GetComponent<GameManager>();
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            // Initialises Input Manager  
            
            try
            {
                _inputManagerObject = GameObject.Find("InputManager");
                _inputManager = _inputManagerObject.GetComponent<InputManager>();

            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            // Initialises Character  
            
            try
            {
                _characterObject = GameObject.Find("Character 1");
                _characterRun = _characterObject.GetComponent<QuantumRun>();
                _characterBasicMovement = _characterObject.GetComponent<CharacterHorizontalMovement>();
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            // Initialises Bar Sprite

            try
            {
                BarSprite = BarObject.GetComponent<SpriteRenderer>(); 
                     
                BarBackground = BarBackgroundObject.GetComponent<Transform>(); 
 
                BarFullSize = BarSprite.size; 

            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
            
            // Initilises isRunning Variable
            //isRunning = _inputManager.RunButton.State.CurrentState != MMInput.ButtonStates.Off;
            
            // Initialises Energy Level
            MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Set, 100, multiplier));
            Debug.Log("Energy After Start Set :" + _gameManager.EnergyLevel );  
          
            
        }

        void Start()
        {
            try
            {
                Initialisation();

            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
        }
        
        
        
        /// <summary>
        /// Calculates Energy Ratio In Order To Produce Correct Number for Bar.  
        /// </summary>
        /// <returns>.</returns>
        
        float calculateEnergyRatio()
        {
            return _gameManager.EnergyLevel/100;
        }

        /// <summary>
        /// Handles Passively Increasing Energy By an Amount Every Second. Rate handled by PassiveEnergyIncreaseRate 
        /// </summary>
      
       
        void increase()
        {
            if (elapsed >= 1f && !isRunning)
            {
                elapsed = elapsed % 1f;
                MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Add, 5, multiplier));
            }
        }
        
        /// <summary>
        /// Handles Energy Changes when Sprinting
        /// </summary>
        
        void sprinting()
        {
            if (elapsed >= 1f && isRunning)
            { 
                if (_gameManager.EnergyLevel <= 10)
                {
                    MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Set, 0, 0));
                    elapsed = elapsed % 1f;

                }
                else
                {
                    MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Remove, 10, 1));   
                    elapsed = elapsed % 1f;

                }
            }
        }
        
        /// <summary>
        /// Stops Run If Needed Based on Energy Levels
        /// </summary>

        void stopRun()
        {
            if (_gameManager.EnergyLevel < 5)
            {
                _characterBasicMovement.MovementSpeed = 6;
            }
        }


        void Update()
        {
            /// Resets Passed Decimal Point Number

            if (_gameManager.EnergyActive== false && _gameManager.EnergyActive == false && isRegenActive == true && _gameManager.EnergyLevel <= 100)
            {
                //elapsed += Time.deltaTime;
                //Debug.Log("Power level : "+_gameManager.PowerLevel+", Charge : "+_gameManager.Charge+", Updating Charge to "+ Mathf.Abs(_gameManager.PowerLevel/3) + " Energy Level : "+_gameManager.EnergyLevel + " Current run button state : " + isRunning + ", Desired State : " + MMInput.ButtonStates.ButtonPressed +  " Are Equal : " + (MMInput.ButtonStates.ButtonPressed == _inputManager.RunButton.State.CurrentState));
                isRunning = _characterBasicMovement.MovementSpeed.Equals(16.0f);
                
                Debug.Log("Energy On Update :" + _gameManager.EnergyLevel + "Speed on update "+_characterBasicMovement.MovementSpeed );  

                
            }
        }


        private void LateUpdate()
        {
            isRunning = _characterBasicMovement.MovementSpeed.Equals(16.0f);
            increase();
            sprinting();
            updateBar();
            stopRun();
            elapsed += Time.deltaTime;
            DebugText.text = "" + isRunning + " " + _characterBasicMovement.MovementSpeed; //_characterBasicMovement.MovementSpeed;

        }

        /// <summary>
        /// Handles Visual Bar Changing.
        /// </summary>

        void updateBar()
        {
            if (_gameManager.EnergyLevel <= 100)
            {
                // TODO : Improve Visual Power Handling. 
                BarSprite.transform.position =
                    new Vector3((zeroReference.transform.position.x + (BarSprite.bounds.size.x / 2) - 0.05f),
                        BarBackground.position.y, BarBackground.position.z);
                BarSprite.size = new Vector2(BarFullSize.x * calculateEnergyRatio(), BarFullSize.y);
            }
        }




    }
}
