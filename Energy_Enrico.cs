using System;

namespace UnderwolfStudios.ProjectAlpha
{
    int Mod;
    public class GameManager : EventListener<EnergyEvent>
    {

        public int Energy { get; private set; }

        public void OnEvent(EnergyEvent energyEvent)
        {
            switch (energyEvent.EnergyEventType)
            {
                case EnergyEventType.Add:
                    _energy += Mod;
                    break;
                case EnergyEventType.Remove:
                    _energy -= Mod;
                    break;
                case EnergyEventType.RemoveAll
                    _energy:
                    0;
                    break;
            }
        }
    }
}
			
