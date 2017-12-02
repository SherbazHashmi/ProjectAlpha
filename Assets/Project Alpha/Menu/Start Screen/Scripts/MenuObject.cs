using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuObject : MonoBehaviour
{

    public MenuObject aboveObject;
    public MenuObject belowObject;
    public Text text;
    public bool isSelected  { get; set;}

	void Start()
	{
       
	}

	public MenuObject (MenuObject aboveObject) {
        this.aboveObject = aboveObject;
    }


    public MenuObject getAboveObject  () {
        return aboveObject;
    }

    public MenuObject getBelowObject () {
        return belowObject;
    }


	public void setAboveObject(MenuObject o)
	{
		aboveObject = o;
	}

	public void setBelowObject(MenuObject o)
	{
        belowObject = o;
	}

    public Text getText () {
        return text;
    }

    public void setTextColour (Color color) {
        text.color = color;
    }

   

}
