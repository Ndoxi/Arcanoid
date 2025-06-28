using strange.extensions.context.impl;

namespace App.Context
{
    public class GameplayContextRoot : ContextView
    {
        private void Start()
        {
            context = new GameplayContext(this);
            context.Start();
        }
    }
}