using UnityEngine;

namespace UnderwolfStudios.ProjectAlpha
{
    public class InputManager : Singleton<InputManager>
    {
        [Header("Player Binding")]
        public string PlayerID; // This is the Player ID.
        public enum InputMode {MOBILE,DESKTOP} // Two Possible Ways to Interact with the Game
        
        public InputMode CurrentInputMode { get; protected set;} // Current Input Mode
        
    }
}