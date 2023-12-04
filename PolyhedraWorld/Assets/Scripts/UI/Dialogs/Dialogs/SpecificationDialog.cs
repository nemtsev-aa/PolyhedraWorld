using System;
using UnityEngine;

public class SpecificationDialog : Dialog {
    public event Action<PolyhedraConfig> PolyhedraConfigChanged;
    public event Action<PolyhedrasCompanentTypes> PolyhedraCompanentSelected;
    public event Action<float, float> JoysticValueChanged;

    [SerializeField] private DynamicJoystick _joystick;

    private ToolsPanel _toolsPanel;
    private ViewsManager _viewsManager;
    private PolyhedraConfig _config;

    public override void Init() {
        base.Init();
    }

    public override void InitializationPanels() {
        _toolsPanel = GetPanelByType<ToolsPanel>();
        _toolsPanel.Init(this);

        _viewsManager = GetPanelByType<ViewsManager>();
        _viewsManager.Init(this);
    }

    public override void AddListeners() {
        base.AddListeners();

        _toolsPanel.ToolSelected += OnToolSelected;
        _viewsManager.PolyhedrasCompanentBlinked += OnPolyhedrasCompanentBlinked;
        _joystick.JoysticDrag += OnJoysticDrag;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _toolsPanel.ToolSelected -= OnToolSelected;
        _viewsManager.PolyhedrasCompanentBlinked -= OnPolyhedrasCompanentBlinked;
    }

    public void SetPolyhedraConfig(PolyhedraConfig config) {
        _config = config;
        PolyhedraConfigChanged?.Invoke(_config);
    }

    private void OnJoysticDrag(float horizontal, float vertical) => JoysticValueChanged?.Invoke(horizontal, vertical);

    private void OnToolSelected(Type type) => _viewsManager.ShowViewByType(type);

    private void OnPolyhedrasCompanentBlinked(PolyhedrasCompanentTypes type) => PolyhedraCompanentSelected?.Invoke(type);
}
