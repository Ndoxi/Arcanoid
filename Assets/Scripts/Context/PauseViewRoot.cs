using strange.extensions.context.impl;

namespace App.Context
{
    public class PauseViewRoot : ContextView
    {
        private void Awake()
        {
            context = new PauseContext(this);
            context.Start();
        }
    }
}