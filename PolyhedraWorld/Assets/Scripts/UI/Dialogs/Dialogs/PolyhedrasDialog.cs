using System;
using UnityEngine;

public class PolyhedrasDialog : Dialog {
    public event Action<PolyhedraConfig> PolyhedraSelected;

    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private PolyhedraConfigs _polyhedraConfigs;

    private PolyhedrasPanel _polyhedrasPanel;

    public override void Init() {
        base.Init();
    }

    public override void Show(bool value) {
        base.Show(value);

        _polyhedrasPanel.Reset();
    }

    public override void InitializationPanels() {
        _polyhedrasPanel = GetPanelByType<PolyhedrasPanel>();
        _polyhedrasPanel.Init(_polyhedraConfigs, _companentsFactory);
        _polyhedrasPanel.Show(true);
    }

    public override void AddListeners() {
        base.AddListeners();

        _polyhedrasPanel.SelectedPolyhedraChanged += OnSelectedPolyhedraChanged;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _polyhedrasPanel.SelectedPolyhedraChanged -= OnSelectedPolyhedraChanged;
    }

    private void OnSelectedPolyhedraChanged(PolyhedraConfig config) {
        Debug.Log($"{config.Name}");
        PolyhedraSelected?.Invoke(config);
    }
}
