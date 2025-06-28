using App.StateMachines;
using strange.extensions.command.impl;
using UnityEngine;

namespace App.Commands
{
    public class AppStartCommand : Command 
    {
        [Inject] public IStateMachine StateMachine { get; private set; }

        public override void Execute()
        {
            StateMachine.ChangeState<MenuState>();
        }
    }
}