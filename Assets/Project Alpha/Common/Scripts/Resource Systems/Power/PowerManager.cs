using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{

	/// <summary>
    /// Added This Class Just In Case We Choose To Passively Modify Power With Depletion Rates Based on Charges. (Remove Power as Discussed with Ten).
	/// </summary>

	public class PowerManager : MonoBehaviour
    {

		GameObject gameManagerObject;
        GameManager gameManager;
        protected int DepletionRate { get; set; }
        Utilities utils;



		void Start()
        {
            /// Instantiating a New Utilities Module For Dealing With Seconds.
            utils = new Utilities();

            /// Setting Depletion Rate
            /// (PowerPoints per Second)
            DepletionRate = 0;

			try
			{
				/// Finding Object Called GameManager 
				/// 
				gameManagerObject = GameObject.Find("GameManager");

				try
				{

					/// Isoating actual Game Manager Object (Script)

					gameManager = gameManagerObject.GetComponent<GameManager>();


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
            /// Setting Depletion Rate Based On Number Of Charges

            switch (gameManager.Charge) {
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

            if (gameManager.Paused == false && gameManager.EnergyActive == false && utils.isWholeNumber(Time.timeSinceLevelLoad))
            {
                MMEventManager.TriggerEvent(new PowerEvent(PowerEventType.Remove, DepletionRate));
            }
        }
    }
}
