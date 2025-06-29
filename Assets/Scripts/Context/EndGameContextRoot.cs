using strange.extensions.context.impl;

namespace App.Context
{
    public class EndGameContextRoot : ContextView
    {
        private void Awake()
        {
            context = new EndGameContext(this);
            context.Start();
        }
    }
}