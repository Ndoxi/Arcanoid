namespace App.Gameplay
{
    public interface IPauseService
    {
        void Register(IPausable pausable);
        void Unregister(IPausable pausable);
        void RequestPause();
        void RequestResume();
    }
}