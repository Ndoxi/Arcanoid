using App.Signals;
using strange.extensions.injector.api;
using System;
using System.Collections.Generic;

namespace App.StateMachines
{
    public class AppStateMachine : StateMachine
    {
        [Inject] public MenuState MenuState { get; private set; }
        [Inject] public GameplayState GameplayState { get; private set; }
        [Inject] public PauseState PauseState { get; private set; }

        protected override Dictionary<Type, IState> States => _states;
        private Dictionary<Type, IState> _states;

        [PostConstruct]
        public void Init()
        {
            _states = new Dictionary<Type, IState>()
            {
                { typeof(MenuState), MenuState },
                { typeof(GameplayState), GameplayState },
                { typeof(PauseState), PauseState }
            };
        }
    }
}