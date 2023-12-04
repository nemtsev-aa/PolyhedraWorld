using UnityEngine;
using DG.Tweening;

public class BlinkedElementState : ViewState {
    private float _duration = 0.3f;
    private Material _material;

    private Color _startColor;
    private Color _endColor = Color.white;

    private Tween _colorTween;

    public BlinkedElementState(IStateSwitcher stateSwitcher, ViewStateMachineData data, PolyhedraElement polyhedraElement) : base(stateSwitcher, data, polyhedraElement) {
        _material = Data.Material;
        _startColor = _material.color;
    }

    public override void Enter() {
        base.Enter();

        StartChangingColor();
    }

    public override void Exit() {
        base.Exit();

        StopChangingColor();
    }

    public override void Update() {
        base.Update();

        if (Data.IsBlinked == false)
            StateSwitcher.SwitchState<IdlingElementState>();
    }

    private void StartChangingColor() {
        _colorTween = _material.DOColor(_endColor, _duration / 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void StopChangingColor() {
        _colorTween.Kill();
        _colorTween = null;

        _material.color = _startColor;
    }
}
