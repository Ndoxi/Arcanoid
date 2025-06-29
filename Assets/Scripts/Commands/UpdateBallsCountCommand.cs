using App.Gameplay;
using strange.extensions.command.impl;

namespace App.Commands
{
    public class UpdateBallsCountCommand : Command
    {
        [Inject] public LevelProgressTracker LevelProgressTracker { get; private set; }

        public override void Execute()
        {
            LevelProgressTracker.OnBallDestroy();
        }
    }
}