using strange.extensions.context.impl;

namespace App.Context
{
    public class MenuContextRoot : ContextView
    {
        private void Awake()
        {
            context = new MenuContext(this);
            context.Start();
        }
    }
}