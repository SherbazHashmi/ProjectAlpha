using System;
using System.Security.Cryptography;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.UI;

namespace MoreMountains.CorgiEngine
{

	/// <summary>
    /// Added This Class Just In Case We Choose To Passively Modify Power With Depletion Rates Based on Charges. (Remove Power as Discussed with Ten).
	/// </summary>

	public class PowerManager : MonoBehaviour
    {

		GameObject gameManagerObject;
        GameManager gameManager;
       	[SerializeField] public int DepletionRate { get; set; }
        Utilities utils;
	    [SerializeField] private GameObject PowerBarObject;
	    SpriteRenderer PowerBarSprite;
	    Vector2 powerBarFullSize;
	    [SerializeField] private float TestingOnlyStartingEnergy;
	    [SerializeField] GameObject DebugEnergy;
	    [SerializeField] GameObject PowerBarBackgroundObject;
	    [SerializeField] Transform PowerBarBackground;
	    [SerializeField] private GameObject zeroReference;
	    private float elapsed = 0f;
	    
	    
	    private Text energyText; 
	  
	   
	  
	    

         

		void Start()
        {
            /// Instantiating a New Utilities Module For Dealing With Seconds.
            utils = new Utilities();

            /// Setting Depletion Rate
            /// (PowerPoints per Second)
            /// 
			try
			{
				
				/// Finding Object Called GameManager 
				/// 
				gameManagerObject = GameObject.Find("GameManager");
				// Getting Sprite Renderer
				
				
				PowerBarSprite = PowerBarObject.GetComponent<SpriteRenderer>();
				try
				{
					
					powerBarFullSize = PowerBarSprite.size;
					PowerBarSprite.size = new Vector2(0,0);

					/// Isoating actual Game Manager Object (Script)

					gameManager = gameManagerObject.GetComponent<GameManager>();

					energyText = DebugEnergy.GetComponent<Text>();
					PowerBarBackground = PowerBarBackgroundObject.GetComponent<Transform>();
									
					// Testing Sprite Renderer
					updateBar();
					MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Add, TestingOnlyStartingEnergy));

					
					
					
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

        void Update()
        {
	        deplete();
	        gameManager.updateCharge();
	        energyText.text = gameManager.Charge+ "C";
	        
	        updateBar();

            /// Setting Depletion Rate Based On Number Of Charges

            switch (Mathf.FloorToInt(gameManager.Charge)) {
                case 0 :
                    DepletionRate = 0;
                    break;

                case 1 :
                    DepletionRate = 1;
                    break;
                case 2 :
                    DepletionRate = 2;
                    break;
                case 3:
                    DepletionRate = 5;
                    break;
                    
            }

        }


	    float calculatePowerRatio()
	    {
		    return gameManager.PowerLevel/100;
	    }


	    void deplete()
	    {
		    elapsed += Time.deltaTime;
		    if (elapsed >= 1f)
		    {
			    elapsed = elapsed % 1f;
			    Debug.Log("Depleting");
			    MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Remove, DepletionRate));
		    }
	    }
	    
	    void updateBar()
	    {
		    // TODO : Improve Visual Power Handling. 
		    PowerBarSprite.transform.position = new Vector3((zeroReference.transform.position.x + (PowerBarSprite.bounds.size.x /2) - 0.05f),PowerBarBackground.position.y,PowerBarBackground.position.z);
		    PowerBarSprite.size = new Vector2(powerBarFullSize.x * calculatePowerRatio(),powerBarFullSize.y);
	    }
    }
}
