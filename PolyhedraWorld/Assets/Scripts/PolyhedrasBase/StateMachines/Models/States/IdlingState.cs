using UnityEngine;
using DG.Tweening;

public class IdlingState : MovementState {
    private Tween _rotateTween;

    public IdlingState(IStateSwitcher stateSwitcher, MoveStateMachineData data, PolyhedraModel polyhedraModel) : base(stateSwitcher, data, polyhedraModel) {
    }

    public override void Enter() {
        base.Enter();

        _rotateTween = ModelTransform.DORotate(Vector3.zero, 0.3f);
    }

    public override void Exit() {
        base.Exit();

    }

    public override void Update() {
        base.Update();

        if (IsInputZero() == false)
            StateSwitcher.SwitchState<RotationState>();
    }
}
