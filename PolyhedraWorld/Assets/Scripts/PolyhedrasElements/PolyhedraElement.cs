using UnityEngine;

public class PolyhedraElement : MonoBehaviour {
    [SerializeField] protected Renderer Renderer;

    public ViewStateMachineData ViewStateData { get; private set; }
    public Material Material { get; private set; }

    protected Transform Transform => transform;
    protected ElementStateMachine StateMachine;
    protected Material WorkMaterial;

    public void Init(Material material) {
        Material = material;
        WorkMaterial = new Material(Material);
        Renderer.material = WorkMaterial;

        ViewStateData = new ViewStateMachineData(WorkMaterial);
        StateMachine = new ElementStateMachine(this, ViewStateData);
    }

    public void Selected(bool status) {
        ViewStateData.IsHidden = !status;
        ViewStateData.IsBlinked = status;

        if (ViewStateData.IsHidden == true)
            StateMachine.SwitchState<HidenElementState>();

        if (ViewStateData.IsBlinked == true)
            StateMachine.SwitchState<BlinkedElementState>();
    }

    public void Reset() {
        ViewStateData.IsHidden = false;
        ViewStateData.IsBlinked = false;
        Renderer.material = Material;

        StateMachine.SwitchState<IdlingElementState>();
    }

    private void Update() {
        StateMachine.HandleInput();
        StateMachine.Update();
    }
}
