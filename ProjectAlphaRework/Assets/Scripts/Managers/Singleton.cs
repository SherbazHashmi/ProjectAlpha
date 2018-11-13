using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

	private static T instance;

	public static T Instance {
		get
        {			
	        if (instance == null)                           //Check if instance already exists
            {
                instance = FindObjectOfType<T>();           //if not, set instance to of type T
                                                            //If instance already exists and it's not this:
            }
            else if (instance != FindObjectOfType<T>())
            {				
		        Destroy(FindObjectOfType<T>());             //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            }

            //DontDestroyOnLoad(FindObjectOfType<T>());
            return instance;                                //Sets this to not be destroyed when reloading scene            
        }
    }
}
