using UnityEngine;
using MoreMountains.Tools;

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

        void Start()
        {
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
            /// Resets Passed Decimal Point Number

            if (gameManager.Paused == false && gameManager.EnergyActive == false && utils.isWholeNumber(Time.timeSinceLevelLoad))
            {
                MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Add, energyAmountToAdd, multiplier));
            }
        }


    }
}
