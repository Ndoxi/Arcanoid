using UnityEngine;

namespace App.Input
{
    public class InputReader : IInputReader
    {
        private const string MovementAxisName = "Horizontal";
        private const KeyCode LaunchKey = KeyCode.Space;
        private const KeyCode PauseKey = KeyCode.Escape;

        public float GetMovement()
        {
            return UnityEngine.Input.GetAxis(MovementAxisName);
        }

        public bool LaunchPressed()
        {
            return UnityEngine.Input.GetKeyUp(LaunchKey);
        }
    }
}