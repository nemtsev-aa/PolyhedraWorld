using DG.Tweening;

public class HidenElementState : ViewState {
    private Tween _scaleTween;

    public HidenElementState(IStateSwitcher stateSwitcher, ViewStateMachineData data, PolyhedraElement polyhedraElement) : base(stateSwitcher, data, polyhedraElement) {
    }
    public override void Enter() {
        base.Enter();

        _scaleTween = ElementTransform.DOScale(0, 0.3f);
    }

    public override void Exit() {
        base.Exit();

        _scaleTween = ElementTransform.DOScale(1, 0.3f);
    }

    public override void Update() {
        base.Update();

        if (Data.IsHidden == false)
            StateSwitcher.SwitchState<IdlingElementState>();
    }
}
