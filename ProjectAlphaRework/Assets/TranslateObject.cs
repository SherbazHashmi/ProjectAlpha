using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    [SerializeField] private float x,y,speed;
    private Vector2 moveTowards;
    private bool canMove;
    private float width;
    private Vector2 initialPosition;
    void Start()
    {
        Debug.Log(this.gameObject.name);
        //RectTransform rt = (RectTransform)this.gameObject.transform;
        //width = rt.rect.width;
        //initialPosition = transform.localPosition;
        //moveTowards = new Vector2(initialPosition.x + width, initialPosition.y);

    }


    public void Update()
    {
        //Vector2.MoveTowards(new Vector2(transform.localPosition.x, transform.localPosition.y), moveTowards, 0.1f);
        //Debug.Log(width);
    }

    public void move()
    {
        //Debug.Log("Moving");
        //canMove = true;

    }
}
