using System.Collections.Generic;

namespace App.Gameplay
{
    public class PauseService : IPauseService
    {
        private readonly List<IPausable> _listeners;

        public PauseService()
        {
            _listeners = new List<IPausable>();
        }

        public void Register(IPausable pausable)
        {
            _listeners.Add(pausable);
        }

        public void Unregister(IPausable pausable)
        {
            _listeners.Remove(pausable);
        }

        public void RequestPause()
        {
            foreach (var listener in _listeners)
                listener.Pause();
        }

        public void RequestResume()
        {
            foreach (var listener in _listeners)
                listener.Resume();
        }
    }
}