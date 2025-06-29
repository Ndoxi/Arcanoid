using UnityEngine;

namespace App.LevelBuilder
{
    public partial class Builder
    {
        private class LevelScheme
        {
            public readonly Vector2 PlayerSpawnPosition;
            public readonly Vector2[] BrickSpawnPositions;

            public LevelScheme()
            {
                //hardcoded for the sake of speading up development
                PlayerSpawnPosition = new Vector2(0f, -3.2f);
                BrickSpawnPositions = new Vector2[12] 
                { 
                    new Vector2(-2f, 3.75f), new Vector2(-0.75f, 3.75f), new Vector2(0.75f, 3.75f), new Vector2(2f, 3.75f), 
                    new Vector2(-2f, 3f), new Vector2(-0.75f, 3f), new Vector2(0.75f, 3f), new Vector2(2f, 3f), 
                    new Vector2(-2f, 2.25f), new Vector2(-0.75f, 2.25f), new Vector2(0.75f, 2.25f), new Vector2(2f, 2.25f)
                };
            }
        }
    }
}