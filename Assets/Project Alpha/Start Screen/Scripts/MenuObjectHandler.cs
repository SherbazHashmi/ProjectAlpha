using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.CorgiEngine
{

    public class MenuObjectHandler : MonoBehaviour
    {

        protected float _threshold = 0.1f;
        public MenuObject currentObject;
		protected float _horizontalMove;
		protected float _verticalMove;
        protected string _movement = "";
        public AudioSource ding;
        public float lastTapTime;





		// Use this for initialization
		void Start()
        {
            
            currentObject.setTextColour(Color.blue);
            lastTapTime = 0f;
 
        }


        // Update is called once per frame
        void Update()
        {
          handleInput();
        }


        void handleInput()
        {
            _movement = "";

            if (InputManager.Instance != null)
            {
                _horizontalMove = InputManager.Instance.PrimaryMovement.x;
                _verticalMove = InputManager.Instance.PrimaryMovement.y;
            }
            else
            {
                Debug.LogError("Input Manager Returning Null");

            }


            if ((Mathf.Abs(_horizontalMove) > _threshold) || (Mathf.Abs(_verticalMove) > _threshold))
            {
                if (_horizontalMove > _threshold)
                    _movement = "";

                if (_horizontalMove > _threshold)
                    _movement = "";

                if (_verticalMove > _threshold)
                {
                    if (currentObject.aboveObject != null)
                    {
                        currentObject.setTextColour(Color.white);
                        currentObject.aboveObject.setTextColour(Color.blue);
                        currentObject = currentObject.aboveObject;
                        ding.Play();
                    }
                    _movement = "Up";
					lastTapTime = Time.time;
				}

                if (_verticalMove < _threshold)
                {
                    if (currentObject.belowObject != null)
                    {
                        currentObject.setTextColour(Color.white);
                        currentObject.belowObject.setTextColour(Color.blue);
                        currentObject = currentObject.belowObject;
                        ding.Play();

                    }
                    _movement = "Down";
                    lastTapTime = Time.time;

                }
            }

            if (!_movement.Equals(""))
            {
                switch (_movement)
                {
                    case "Up":

                        if (currentObject.getAboveObject() != null)
                        {

                            if (currentObject.getText() != null)
                            {
                                currentObject.setTextColour(Color.white);
                                currentObject.aboveObject.setTextColour(Color.blue);
								currentObject = currentObject.getAboveObject();
								lastTapTime = Time.time;
                            }


                        }

                        break;

                    case "Down":

                        if (currentObject.getBelowObject() != null)
                        {

                            if (currentObject.getText() != null)
                            {
                                currentObject.setTextColour(Color.blue);
                                currentObject.belowObject.setTextColour(Color.white);
								currentObject = currentObject.getBelowObject();
								lastTapTime = Time.time;
                            }

                         

                        }

                        break;
                    default:
                        break;
                }


            }


    }
    
    }
}