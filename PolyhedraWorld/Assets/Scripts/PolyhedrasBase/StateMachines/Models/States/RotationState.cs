public class RotationState : MovementState {
    public RotationState(IStateSwitcher stateSwitcher, MoveStateMachineData data, PolyhedraModel polyhedraModel) : base(stateSwitcher, data, polyhedraModel) {
    }

    public override void Enter() {
        base.Enter();

        Data.Speed = 1f;
    }

    public override void Exit() {
        base.Exit();

    }

    public override void Update() {
        base.Update();

        if (IsInputZero() == true)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
