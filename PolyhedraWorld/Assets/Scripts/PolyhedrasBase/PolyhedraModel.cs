using System.Collections.Generic;
using UnityEngine;
using System;

public class PolyhedraModel : MonoBehaviour {
    [SerializeField] private List<PolyhedraElement> _elements;
    private ModelStateMachine _stateMachine;
    private PolyhedraElement _selectedElement;

    public PolyhedraConfig Config { get; private set; }
    public ModelInput Input { get; private set; }

    private PolyhedraCompanentsMaterialConfig _materialConfig;

    public Transform Transform => gameObject.transform;
    public MoveStateMachineData MoveStateData { get; set; }

    private void Awake() {
        MoveStateData = new MoveStateMachineData();
        _stateMachine = new ModelStateMachine(this, MoveStateData);
    }

    public void Init(PolyhedraConfig config, ModelInput input, PolyhedraCompanentsMaterialConfig materialConfig) {
        Config = config;
        Input = input;
        _materialConfig = materialConfig;
        _materialConfig.ConfigChanged += OnConfigChanged;

        InitializationElements();
    }

    public void EnableInput(bool status) {
        if (status)
            Input.Enable();
        else
            Input.Disable();
    }

    public void RestoreOriginalViewState() {
        foreach (var iElement in _elements) {
           iElement.Reset();
        }
    }

    public void BlinkCompanent(PolyhedrasCompanentTypes type) {
        _selectedElement = GetElements(type);

        foreach (var iElement in _elements) {
            if (_selectedElement.Equals(iElement))
                iElement.Selected(true);
            else
                iElement.Selected(false);
        }
    }

    private void Update() {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void InitializationElements() {
        foreach (var iElement in _elements) {
            if (iElement is Edge)
                iElement.Init(_materialConfig.GetMaterialByCompanentType(PolyhedrasCompanentTypes.Edge));

            if (iElement is Vertex)
                iElement.Init(_materialConfig.GetMaterialByCompanentType(PolyhedrasCompanentTypes.Vertex));

            if (iElement is Plane)
                iElement.Init(_materialConfig.GetMaterialByCompanentType(PolyhedrasCompanentTypes.Plane));
        }
    }

    private PolyhedraElement GetElements(PolyhedrasCompanentTypes type) {
        switch (type) {
            case PolyhedrasCompanentTypes.Edge:
                return _elements.Find(element => element is Edge);

            case PolyhedrasCompanentTypes.Vertex:
                return _elements.Find(element => element is Vertex);

            case PolyhedrasCompanentTypes.Plane:
                return _elements.Find(element => element is Plane);
            default:
                throw new ArgumentNullException($"Invalid PolyhedrasCompanentTypes: {type}");
        }
    }

    private void OnConfigChanged() => InitializationElements();
}
