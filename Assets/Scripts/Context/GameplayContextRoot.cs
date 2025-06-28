using strange.extensions.context.impl;

namespace App.Context
{
    public class GameplayContextRoot : ContextView
    {
        private void Awake()
        {
            context = new GameplayContext(this);
            context.Start();
        }
    }
}