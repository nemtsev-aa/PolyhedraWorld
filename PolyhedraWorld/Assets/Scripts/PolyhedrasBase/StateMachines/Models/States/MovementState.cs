using UnityEngine;

public abstract class MovementState : IState {
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly MoveStateMachineData Data;
    private readonly PolyhedraModel _polyhedraModel;

    public MovementState(IStateSwitcher stateSwitcher, MoveStateMachineData data, PolyhedraModel polyhedraModel) {
        StateSwitcher = stateSwitcher;
        Data = data;
        _polyhedraModel = polyhedraModel;
    }

    protected ModelInput Input => _polyhedraModel.Input;
    protected Transform ModelTransform => _polyhedraModel.Transform;

    private Vector3 TurnHorizontal => Vector3.up * Data.XRotation;
    private Vector3 TurnVertical => Vector3.right * Data.YRotation;
    private Vector3 StopTurn => Vector3.zero;

    public virtual void Enter() {
        
    }

    public virtual void Exit() { }

    public void HandleInput() {
        float horizontal = Mathf.Abs(ReadHorizontalInput());
        float vertical = Mathf.Abs(ReadVerticalInput());

        if (horizontal > vertical) {
            Data.XInput = ReadHorizontalInput();
            Data.YInput = 0;
        } else if (horizontal < vertical) {
            Data.XInput = 0;
            Data.YInput = ReadVerticalInput();
        } else if (horizontal == vertical && horizontal == 0) {
            Data.XInput = 0;
            Data.YInput = 0;
        }
    }

    public virtual void Update() {
        ModelTransform.Rotate(GetRotation());
    }

    protected bool IsInputZero() {
        if (Data.XInput == 0 && Data.YInput == 0)
            return true;
        else
            return false;

    }
    private Vector3 GetRotation() {
        Data.XRotation = Data.XInput * Data.Speed;
        Data.YRotation = Data.YInput * Data.Speed;

        if (Data.XRotation != 0) {
            return TurnHorizontal;
        }

        if (Data.YRotation != 0) {
            return TurnVertical;
        }

        return StopTurn;
    }

    //private float ReadHorizontalInput() => Input.Movement.HorizontalRotation.ReadValue<float>();
    //private float ReadVerticalInput() => Input.Movement.VerticalRotation.ReadValue<float>();
    private float ReadHorizontalInput() => Input.HorizontalRotation;
    private float ReadVerticalInput() => Input.VerticalRotation;
}
