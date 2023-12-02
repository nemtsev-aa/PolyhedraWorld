using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PolyhedraWidget : UICompanent {
    public event Action<PolyhedrasCompanentTypes> SelectedCompanentChanged;

    [SerializeField] private TextMeshProUGUI _edgesCountText;
    [SerializeField] private TextMeshProUGUI _vertexCountText;
    [SerializeField] private TextMeshProUGUI _planesCountText;

    [SerializeField] private ToggleGroup _group;
    [SerializeField] private Toggle _edgesToggle;
    [SerializeField] private Toggle _vertexToggle;
    [SerializeField] private Toggle _planesToggle;

    public PolyhedraConfig Config { get; private set; }

    public void Int(PolyhedraConfig config) {
        Config = config;

        UpdateCompanents();
        AddListeners();
    }

    private void UpdateCompanents() {
        _edgesCountText.text = $"{Config.Companents.Edges}";
        _vertexCountText.text = $"{Config.Companents.Vertexes}";
        _planesCountText.text = $"{Config.Companents.Planes}";

        _edgesToggle.group = _group;
        _vertexToggle.group = _group;
        _planesToggle.group = _group;

        Toggle[] toggles = _group.GetComponentsInChildren<Toggle>();
        toggles[0].isOn = true;
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
