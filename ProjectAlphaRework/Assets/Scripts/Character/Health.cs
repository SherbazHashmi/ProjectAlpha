using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace General
{
    public class Health : MonoBehaviour
    {
        private float _health;
        public float InitialHealth;
        private void Start()
        {
            Initialise();
        }

        private bool Initialise()
        {
            try
            {
                // Setting the Health
                _health = InitialHealth != 0f ? InitialHealth : 100; 
                // Slider Setup
                SliderSetup();
                // 
                
                

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        // TODO: Link to Slider Health Object

        private bool SliderSetup()
        {
            try
            {

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;                
            }
        }
                
    }
}