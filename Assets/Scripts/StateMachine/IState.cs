namespace App.StateMachines
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}