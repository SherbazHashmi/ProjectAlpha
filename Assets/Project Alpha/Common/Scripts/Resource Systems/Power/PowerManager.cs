using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;
namespace MoreMountains.CorgiEngine
{

    public class PowerManager : MonoBehaviour
    {
		GameObject gameManagerObject;
		GameManager gameManager;

        // TODO :  You can clean this up but creating a general function that initialises a Game Manager Object. If I get time, clean up. 
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
            EnergyManager
        }


 




    }
}
