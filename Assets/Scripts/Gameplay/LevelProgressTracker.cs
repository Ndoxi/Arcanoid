using App.Signals;
using System;
using UnityEngine;

namespace App.Gameplay
{
    public class LevelProgressTracker
    {
        public enum LevelResult { Win, Lose }

        [Inject] public CompleteLevelSignal CompleteLevelSignal { get; private set; }

        private int _ballsCount;
        private int _bricksCount;

        public void Init(int ballsCount, int bricksCount)
        {
            if (ballsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(ballsCount));            
            if (bricksCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(bricksCount));

            _ballsCount = ballsCount;
            _bricksCount = bricksCount;
        }

        public void OnBallDestroy()
        {
            _ballsCount -= 1;

            if (_ballsCount <= 0)
                CompleteLevelSignal.Dispatch(LevelResult.Lose);
        }

        public void OnBrickDestroy()
        {
            _bricksCount -= 1;

            if (_bricksCount <= 0)
                CompleteLevelSignal.Dispatch(LevelResult.Win);
        }
    }
}