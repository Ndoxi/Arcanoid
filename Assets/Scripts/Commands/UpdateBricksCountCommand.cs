using App.Gameplay;
using strange.extensions.command.impl;

namespace App.Commands
{
    public class UpdateBricksCountCommand : Command
    {
        [Inject] public LevelProgressTracker LevelProgressTracker { get; private set; }

        public override void Execute()
        {
            LevelProgressTracker.OnBrickDestroy();
        }
    }
}