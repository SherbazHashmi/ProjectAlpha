using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectScalable : MonoBehaviour
{

    public Vector3 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = pos;
		//myRectTransform.localPosition = pos;

	}
}
