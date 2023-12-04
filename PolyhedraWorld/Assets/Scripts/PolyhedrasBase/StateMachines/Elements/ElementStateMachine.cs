using System.Collections.Generic;

public class ElementStateMachine : PolyhedraStateMachine {
    public ElementStateMachine(PolyhedraElement element, ViewStateMachineData data) {
        
        States = new List<IState>() {
            new IdlingElementState(this, data, element),
            new BlinkedElementState(this, data, element),
            new HidenElementState(this, data, element)
        };

        CurrentState = States[0];
        CurrentState.Enter();
    }
}
