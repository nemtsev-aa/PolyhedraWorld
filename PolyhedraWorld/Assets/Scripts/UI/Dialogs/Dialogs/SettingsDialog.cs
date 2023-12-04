using System;
using UnityEngine;

public class SettingsDialog : Dialog {
    public event Action<PolyhedrasCompanentTypes, Color> ElementColorChanged;
    public event Action ColorSettingsChanged;

    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private PolyhedraCompanentsMaterialConfig _materialConfig;

     private SelectionColorPanel _selectionColor;

    public override void Init() {
        base.Init();
    }

    public override void InitializationPanels() {
        _selectionColor = GetPanelByType<SelectionColorPanel>();
        _selectionColor.Init(_materialConfig, _companentsFactory);
    }

    public override void AddListeners() {
        base.AddListeners();

        _selectionColor.MaterialsColorChanged += OnMaterialsColorChanged;
        _selectionColor.SettingsApplyed += OnSettingsApplyed;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _selectionColor.MaterialsColorChanged -= OnMaterialsColorChanged;
        _selectionColor.SettingsApplyed -= OnSettingsApplyed;
    }

    private void OnMaterialsColorChanged(PolyhedrasCompanentTypes type, Color color) => ElementColorChanged?.Invoke(type, color);
    private void OnSettingsApplyed() => ColorSettingsChanged?.Invoke();

}
