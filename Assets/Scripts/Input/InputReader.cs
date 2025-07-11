﻿using UnityEngine;

namespace App.Input
{
    public class InputReader : IInputReader
    {
        private const string MovementAxisName = "Horizontal";
        private const KeyCode LaunchKey = KeyCode.Space;
        private const KeyCode PauseKey1 = KeyCode.Escape;
        private const KeyCode PauseKey2 = KeyCode.Backspace;

        public float GetMovement()
        {
            return UnityEngine.Input.GetAxis(MovementAxisName);
        }

        public bool LaunchPressed()
        {
            return UnityEngine.Input.GetKeyUp(LaunchKey);
        }

        public bool PausePressed()
        {
            return UnityEngine.Input.GetKeyUp(PauseKey1) 
                   || UnityEngine.Input.GetKeyUp(PauseKey2);
        }
    }
}