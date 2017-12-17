using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{

    public class EnergyManager : MonoBehaviour
    {

        [SerializeField] bool isRegenActive = true;
        static bool havePassedDecimalPoint = false;
        GameObject gameManagerObject;
        GameManager gameManager;
        int energyAmountToAdd = 1;
        int multiplier = 1;

        void Start()
        {
            /// Setup Time Variable
            /// 
            float time = Time.time;



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
            if (gameManager.Paused == false && gameManager.EnergyActive == false && isWholeNumber(Time.time))
            {
                MMEventManager.TriggerEvent(new EnergyEvent(EnergyEventType.Add, energyAmountToAdd, multiplier));
            }
        }


        static bool isWholeNumber(double num)
        {
            string str = num.ToString();
            string afterDecimalPoint = getAfterDecimalPoint(str);
            return (afterDecimalPoint.Equals("0"));
        }

        static string getAfterDecimalPoint(string str)
        {
            if (str.Length > 0)
            {
                if (str[0] == '.')
                {
                    havePassedDecimalPoint = true;
                    return getAfterDecimalPoint(str.Substring(1));
                }
                else if (havePassedDecimalPoint)
                {

                    return str[0] + getAfterDecimalPoint(str.Substring(1));
                }
                else
                {
                    return getAfterDecimalPoint(str.Substring(1));
                }
            }
            else
            {
                return "";
            }
        }
    }
}
