using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ToolsTypes {
    Description,
    Parameters,
    Links
}

public class ToolsPanel : UIPanel {
    public event Action<Type> ToolSelected;
    [SerializeField] private TextMeshProUGUI _polyhedraNameText;

    [SerializeField] private ToggleGroup _toolsParent;
    [SerializeField] private Toggle _description;
    [SerializeField] private Toggle _parameters;
    [SerializeField] private Toggle _links;

    private SpecificationDialog _specificationDialog;

    public void Init(SpecificationDialog specificationDialog) {
        _specificationDialog = specificationDialog;

        SetParentFromToggles();
        AddListeners();
    }

    public override void AddListeners() {
        base.AddListeners();
        
        _specificationDialog.PolyhedraConfigChanged += OnPolyhedraConfigChanged;
        _description.onValueChanged.AddListener(DescriptionValueChanged);
        _parameters.onValueChanged.AddListener(ParameterValueChanged);
        _links.onValueChanged.AddListener(LinksValueChanged);
    }


    public override void RemoveListeners() {
        base.RemoveListeners();

        _specificationDialog.PolyhedraConfigChanged -= OnPolyhedraConfigChanged;
        _description.onValueChanged.RemoveListener(DescriptionValueChanged);
        _parameters.onValueChanged.RemoveListener(ParameterValueChanged);
        _links.onValueChanged.RemoveListener(LinksValueChanged);
    }

    private void OnPolyhedraConfigChanged(PolyhedraConfig config) {
        _polyhedraNameText.text = config.Name;

        DescriptionValueChanged(true);
    }

    public override void Show(bool value) {
        base.Show(value);

        DescriptionValueChanged(true);
    }

    private void SetParentFromToggles() {
        _description.group = _toolsParent;
        _parameters.group = _toolsParent;
        _links.group = _toolsParent;
    }

    private void DescriptionValueChanged(bool value) {
        if (value == true)
            ToolSelected?.Invoke(typeof(DescriptionTextView));
    }

    private void ParameterValueChanged(bool value) {
        if (value == true)
            ToolSelected?.Invoke(typeof(PolyhedraWidget));
    }

    private void LinksValueChanged(bool value) {
        if (value == true)
            ToolSelected?.Invoke(typeof(LinksView));
    }
}
