using App.Utility;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;
using strange.extensions.reflector.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Context
{
    public class BaseContext : MVCSContext
    {
        public BaseContext(MonoBehaviour view) : base(view, Flags.AUTO_STARTUP) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            BindInjector();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        private void BindInjector()
        {
            var injector = new Injector
            {
                binder = injectionBinder,
                reflector = new ReflectionBinder()
            };
            injectionBinder.Unbind<IInjector>();
            injectionBinder.Bind<IInjector>().ToValue(injector).CrossContext();
        }
    }
}