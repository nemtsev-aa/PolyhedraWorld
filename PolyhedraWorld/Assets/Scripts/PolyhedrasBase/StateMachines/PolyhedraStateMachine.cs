using System.Collections.Generic;
using System.Linq;

public class PolyhedraStateMachine : IStateSwitcher {
    protected List<IState> States;
    protected IState CurrentState;

    public void SwitchState<T>() where T : IState {
        IState state = States.FirstOrDefault(state => state is T);

        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }

    public void Update() => CurrentState.Update();

    public void HandleInput() => CurrentState.HandleInput();

}
