using UnityEngine;

namespace UnderwolfStudios.ProjectAlpha
{

    public class Energy : MonoBehaviour
    {
        private float _energy;
        public float UpdateAmount; // Amount of Energy Updated Every Second
        public float InitialEnergy; 

        private void Start()
        {
            throw new System.NotImplementedException();
        }

        private void Initialise()
        {
            // Setting Energy
            _energy = InitialEnergy!= 0f ? InitialEnergy : 100;
            
            // Setting Default Update Amount
            UpdateAmount = UpdateAmount == 0f ? 10 : UpdateAmount;
            
                

        }



    }
}
