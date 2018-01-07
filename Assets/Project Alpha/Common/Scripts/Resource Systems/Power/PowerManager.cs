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
	    [SerializeField] private GameObject BarObject;
	    SpriteRenderer BarSprite;
	    Vector2 BarFullSize;
	    [SerializeField] private float StartingResource;
	    [SerializeField] GameObject Debug;
	    [SerializeField] GameObject BarBackgroundObject;
	    Transform BarBackground;
	    [SerializeField] private GameObject zeroReference;
	    private float elapsed = 0f;
  
	    private Text DebugText; 

		void Start()
        {
            
            /// Setting Depletion Rate
            /// (PowerPoints per Second)
            /// 
			try
			{
				
				/// Finding Object Called GameManager 
				/// 
				gameManagerObject = GameObject.Find("GameManager");
				// Getting Sprite Renderer
				
				
				BarSprite = BarObject.GetComponent<SpriteRenderer>();
				try
				{
					
					BarFullSize = BarSprite.size;
					BarSprite.size = new Vector2(0,0);

					/// Isoating actual Game Manager Object (Script)

					gameManager = gameManagerObject.GetComponent<GameManager>();

					DebugText = Debug.GetComponent<Text>();
					BarBackground = BarBackgroundObject.GetComponent<Transform>();
									
					// Testing Sprite Renderer
					updateBar();
					MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Add, StartingResource));

					
					
					
				}
				catch (System.NullReferenceException gameManagerObjectEx)
				{
					UnityEngine.Debug.Log("gameManager Object Returning Null");
				}

			}
			catch (System.NullReferenceException gameManagerEx)
			{
				UnityEngine.Debug.Log("gameManager Object Returning Null");
			}

		}

        void Update()
        {
	        deplete();
	        gameManager.updateCharge();
	        DebugText.text = gameManager.Charge+ "C";
	        
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
			    // UnityEngine.Debug.Log("Depleting");
			    MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Remove, DepletionRate));
		    }
	    }
	    
	    void updateBar()
	    {
		    // TODO : Improve Visual Power Handling. 
		    BarSprite.transform.position = new Vector3((zeroReference.transform.position.x + (BarSprite.bounds.size.x /2) - 0.05f),BarBackground.position.y,BarBackground.position.z);
		    BarSprite.size = new Vector2(BarFullSize.x * calculatePowerRatio(),BarFullSize.y);
	    }
    }
}
