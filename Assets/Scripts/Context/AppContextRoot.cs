using strange.extensions.context.impl;

namespace App.Context
{
    public class AppContextRoot : ContextView
    {
        private void Awake()
        {
            context = new AppContext(this);
            context.Start();
        }
    }
}