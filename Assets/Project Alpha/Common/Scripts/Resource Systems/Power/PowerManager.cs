using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;
namespace MoreMountains.CorgiEngine
{

    public class PowerManager : MonoBehaviour
    {


        protected int Power = 0;
        protected int BurstLevel = 0;
        public int Threshold = 30;


        void Start()
        {
            Power = 0;
            BurstLevel = 0;
        }

        void Update()
        {

        }


        void updateBurst()
        {
            BurstLevel = Power / Threshold;
        }






    }
}
