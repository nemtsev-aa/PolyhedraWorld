using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PolyhedraWidget : UICompanent {
    public Action<PolyhedrasCompanentTypes> SelectedCompanentChanged;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _edgesCountText;
    [SerializeField] private TextMeshProUGUI _vertexCountText;
    [SerializeField] private TextMeshProUGUI _planesCountText;

    [SerializeField] private ToggleGroup _group;
    [SerializeField] private Toggle _edgesToggle;
    [SerializeField] private Toggle _vertexToggle;
    [SerializeField] private Toggle _planesToggle;

    [SerializeField] private Image _iconImage;

    public PolyhedraConfig Config { get; private set; }
    private PolyhedrasCompanentTypes _selectedType;

    public void Int(PolyhedraConfig config) {
        Config = config;

        UpdateCompanents();
        AddListeners();
    }

    private void UpdateCompanents() {
        _nameText.text = Config.Name;
        _edgesCountText.text = $"{Config.Companents.Edges}";
        _vertexCountText.text = $"{Config.Companents.Vertexes}";
        _planesCountText.text = $"{Config.Companents.Planes}";

        _iconImage.sprite = Config.Icon;

        _edgesToggle.group = _group;
        _vertexToggle.group = _group;
        _planesToggle.group = _group;
    }

    private void AddListeners() {
        _edgesToggle.onValueChanged.AddListener(EdgesToggleClick);
        _vertexToggle.onValueChanged.AddListener(VertexToggleClick);
        _planesToggle.onValueChanged.AddListener(PlanesToggleClick);
    }

    private void RemoveListeners() {
        _edgesToggle.onValueChanged.RemoveListener(EdgesToggleClick);
        _vertexToggle.onValueChanged.RemoveListener(VertexToggleClick);
        _planesToggle.onValueChanged.RemoveListener(PlanesToggleClick);
    }

    private void EdgesToggleClick(bool value) {
        if (value == true) 
            SelectedCompanentChanged?.Invoke(PolyhedrasCompanentTypes.Edge);
    }

    private void VertexToggleClick(bool value) {
        if (value == true) 
            SelectedCompanentChanged?.Invoke(PolyhedrasCompanentTypes.Vertex);
    }

    private void PlanesToggleClick(bool value) {
        if (value == true) 
            SelectedCompanentChanged?.Invoke(PolyhedrasCompanentTypes.Plane);  
    }

    public override void Dispose() {
        base.Dispose();
        RemoveListeners();
    }
}
