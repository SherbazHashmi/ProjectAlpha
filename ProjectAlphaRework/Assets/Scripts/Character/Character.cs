using UnderwolfStudios.ProjectAlpha;
using UnityEngine;

namespace General
{
    public enum CharacterStates {COMBAT,REST}
    public class Character : MonoBehaviour
    {
        public CharacterStates State { get; private set; }
        private Health _health;
        private Energy _energy;
        
        
    }
}