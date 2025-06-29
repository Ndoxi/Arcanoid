using System.Collections.Generic;
using UnityEngine;

namespace App.LevelBuilder
{
    public partial class Builder
    {
        public class Level
        {
            public readonly List<GameObject> Entities;

            public Level()
            {
                Entities = new List<GameObject>();
            }
        }
    }
}