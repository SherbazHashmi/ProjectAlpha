using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;
namespace MoreMountains.CorgiEngine
{

	/// <summary>
    /// Added This Class Just In Case We Choose To Passively Modify Power in Some Way. (Remove Power as Discussed with Ten).
	/// </summary>

	public class PowerManager : MonoBehaviour
    {

		GameObject gameManagerObject;
		GameManager gameManager;

       
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
    }
}
