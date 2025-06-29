using App.Mediators;
using App.Views;
using UnityEngine;

namespace App.Context
{
    public class EndGameContext : BaseContext
    {
        public EndGameContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            mediationBinder.Bind<EndGameView>().To<EndGameMediator>();
        }
    }
}