using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyIconLocation : MonoBehaviour {

    [SerializeField] Text currencyText;
    [SerializeField] Image icon;
    [SerializeField] Camera cam;
  


	// Use this for initialization
	void Start () {
        
        /// Icon Placement
        Vector3 currencyTextPosition = currencyText.rectTransform.position;
        currencyTextPosition.x = currencyTextPosition.x - 0.7f;
        currencyTextPosition.y = currencyTextPosition.y + 0.025f;
        icon.transform.position = currencyTextPosition;


	}


}
