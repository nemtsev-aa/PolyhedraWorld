using DG.Tweening;

public class IdlingElementState : ViewState {
    private Tween _scaleTween;

    public IdlingElementState(IStateSwitcher stateSwitcher, ViewStateMachineData data, PolyhedraElement polyhedraElement) : base(stateSwitcher, data, polyhedraElement) {
    }

    public override void Enter() {
        base.Enter();

        _scaleTween = ElementTransform.DOScale(1, 0.3f);
    }

    public override void Exit() {
        base.Exit();
    }

    public override void Update() {
        base.Update();
    }
}
