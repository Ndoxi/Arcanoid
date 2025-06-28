using App.Utility;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;
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

            injectionBinder.Unbind<IInjector>();
            injectionBinder.Bind<IInjector>().To<Injector>().ToSingleton();

            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }
    }
}