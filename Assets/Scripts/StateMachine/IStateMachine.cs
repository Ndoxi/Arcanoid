namespace App.StateMachines
{
    public interface IStateMachine
    {
        void ChangeState<T>() where T : IState;
    }
}