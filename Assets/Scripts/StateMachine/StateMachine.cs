using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.StateMachines
{
    public abstract class StateMachine : IStateMachine
    {
        private IState _currentState;
        protected abstract Dictionary<Type, IState> States { get; }

        public void ChangeState<T>() where T : IState
        {
            if (_currentState?.GetType() == typeof(T))
                return;

            _currentState?.Exit();
            _currentState = GetState<T>();
            _currentState.Enter();
        }

        private IState GetState<T>() where T : IState
        {
            return States[typeof(T)];
        }
    }
}