using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionColorPanel : UIPanel {
    public event Action<PolyhedrasCompanentTypes, Color> MaterialsColorChanged;
    public event Action SettingsApplyed;

    [SerializeField] private List<ColorSelectorView> _companentColorViews;
    [SerializeField] private RectTransform _colorVariantViewParent;
    [SerializeField] private Button _applyButton;

    private PolyhedraCompanentsMaterialConfig _materialConfig;
    private UICompanentsFactory _companentsFactory;
    private List<ColorVariantView> _colorVariantView = new List<ColorVariantView>();
    private ColorSelectorView _currentView;
    private Color _color;

    public void Init(PolyhedraCompanentsMaterialConfig materialConfig, UICompanentsFactory companentsFactory) {
        _materialConfig = materialConfig;
        _companentsFactory = companentsFactory;

        AddListeners();
        InitializationcompanentColorViews();
        CreateColorVariantViews();
    }

    public override void AddListeners() {
        base.AddListeners();

        _applyButton.onClick.AddListener(ApplyButtonClick);
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        foreach (var iView in _colorVariantView) {
            iView.ColorSelected -= OnColorSelected;
        }

        _applyButton.onClick.RemoveListener(ApplyButtonClick);
    }

    private void InitializationcompanentColorViews() {
        foreach (var iCompanentView in _companentColorViews) {
            Color color = _materialConfig.GetMaterialByCompanentType(iCompanentView.CompanentType).color;
            iCompanentView.Init(color);
            iCompanentView.CompanentTypeSelected += OnCompanentTypeSelected;
        }
    }

    private void CreateColorVariantViews() {
        foreach (var iColor in _materialConfig.Colors) {
            ColorVariantViewConfig config = new ColorVariantViewConfig(iColor);
            ColorVariantView newView = _companentsFactory.Get<ColorVariantView>(config, _colorVariantViewParent);
            newView.Init(config);

            newView.ColorSelected += OnColorSelected;
            _colorVariantView.Add(newView);
        }
    }

    private void OnCompanentTypeSelected(ColorSelectorView view) {
        _currentView = view;
    } 

    private void OnColorSelected(Color color) {
        _color = color;
        _currentView.SetColor(color);
        MaterialsColorChanged?.Invoke(_currentView.CompanentType, _color);
    }

    private void ApplyButtonClick() => SettingsApplyed.Invoke();

}
