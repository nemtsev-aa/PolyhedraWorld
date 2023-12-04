using UnityEngine;

public class ViewState : IState {
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly ViewStateMachineData Data;
    private readonly PolyhedraElement _polyhedraElement;

    public ViewState(IStateSwitcher stateSwitcher, ViewStateMachineData data, PolyhedraElement polyhedraElement) {
        StateSwitcher = stateSwitcher;
        Data = data;
        _polyhedraElement = polyhedraElement;
    }

    protected Transform ElementTransform => _polyhedraElement.transform;

    public virtual void Enter() {
        Debug.Log(GetType());
    }

    public virtual void Exit() { }

    public virtual void HandleInput() { }

    public virtual void Update() { }
}
