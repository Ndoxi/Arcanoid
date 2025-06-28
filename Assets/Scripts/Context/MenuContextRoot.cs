using strange.extensions.context.impl;

namespace App.Context
{
    public class MenuContextRoot : ContextView
    {
        private void Start()
        {
            context = new MenuContext(this);
            context.Start();
        }
    }
}