using System.Collections.Generic;

public class ModelStateMachine : PolyhedraStateMachine {

    public ModelStateMachine(PolyhedraModel model, MoveStateMachineData data) {
        
        States = new List<IState>() {
            new IdlingState(this, data, model),
            new RotationState(this, data, model)
        };

        CurrentState = States[0];
        CurrentState.Enter();
    }
}
