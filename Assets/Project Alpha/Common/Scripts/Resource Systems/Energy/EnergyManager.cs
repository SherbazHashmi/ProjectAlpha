using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{

    public class EnergyManager : MonoBehaviour
    {

        [SerializeField] bool isRegenActive = true;
        GameObject gameManagerObject;
        GameManager gameManager;
        Utilities utils = new Utilities();
        int energyAmountToAdd = 1;
        int multiplier = 1;
        [SerializeField] private GameObject BarObject;
        [SerializeField] GameObject BarBackgroundObject;
        Transform BarBackground;
        private SpriteRenderer BarSprite;
        [SerializeField] private GameObject zeroReference; 
        private float elapsed = 0f;
        Vector2 BarFullSize;
        [SerializeField] Text DebugText;
        GameObject _inputManagerObject;
        private InputManager _inputManager;
        GameObject _characterObject;
        protected Character _character;
        protected MMStateMachine<CharacterStates.MovementStates> _movement;

        

        void Start()
        {
            try
            {
                /// Finding Object Called GameManager 
                /// 
                gameManagerObject = GameObject.Find("GameManager");
                _inputManagerObject = GameObject.Find("InputManager");
                
                try
                {
                    _inputManager = _inputManagerObject.GetComponent<InputManager>();
   
                    /// Isoating actual Game Manager Object (Script)

                    gameManager = gameManagerObject.GetComponent<GameManager>();
                    // Setting Energy
                    
                    MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Set, 100, multiplier));
                    
                    /// Bar Sprite 
                    
                    BarSprite = BarObject.GetComponent<SpriteRenderer>();
                    
                    BarBackground = BarBackgroundObject.GetComponent<Transform>();

            

                    BarFullSize = BarSprite.size;

                    
                    
                }
                catch (System.NullReferenceException gameManagerObjectEx)
                {
                    Debug.Log("gameManager Object Returning Null");
                }

            }
            catch (System.NullReferenceException gameManagerEx)
            {
                Debug.Log("gameManager Object Returning Null");
            }
            
           

        }
        
        float calculateEnergyRatio()
        {
            return gameManager.EnergyLevel/100;
        }

        
        void increase()
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                //UnityEngine.Debug.Log("Increasing Energy");
                MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Add, 1, multiplier));
            }
        }
        
        
        void sprinting()
        {
            elapsed += Time.deltaTime;
            if ((_inputManager.RunButton.State.CurrentState != MMInput.ButtonStates.Off) && elapsed >= 1f)
            {                
                    elapsed = elapsed % 1f;
                    //UnityEngine.Debug.Log("Increasing Energy");
                    MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Remove, 10, multiplier));   
            }
        }

        void Update()
        {
            /// Resets Passed Decimal Point Number

            if (gameManager.EnergyActive== false && gameManager.EnergyActive == false && isRegenActive == true && gameManager.EnergyLevel <= 100)
            {
                
                DebugText.text = "" + (_inputManager.RunButton.State.CurrentState);
                Debug.Log("Power level : "+gameManager.PowerLevel+", Charge : "+gameManager.Charge+", Updating Charge to "+ Mathf.Abs(gameManager.PowerLevel/3) + " Energy Level : "+gameManager.EnergyLevel + " Current run button state : " + _inputManager.RunButton.State.CurrentState+ ", Desired State : " + MMInput.ButtonStates.ButtonPressed +  " Are Equal : " + (MMInput.ButtonStates.ButtonPressed == _inputManager.RunButton.State.CurrentState));
                increase();
                sprinting();
                updateBar();
                
            }
        }
        
        
        void updateBar()
        {
            // TODO : Improve Visual Power Handling. 
            BarSprite.transform.position = new Vector3((zeroReference.transform.position.x + (BarSprite.bounds.size.x /2) - 0.05f),BarBackground.position.y,BarBackground.position.z);
            BarSprite.size = new Vector2(BarFullSize.x * calculateEnergyRatio(),BarFullSize.y);
        }
        
        


    }
}
