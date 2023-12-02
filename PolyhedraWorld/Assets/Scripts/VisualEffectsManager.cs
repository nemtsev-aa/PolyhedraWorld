using System;
using UnityEngine;

public class VisualEffectsManager : MonoBehaviour, IDisposable {
    private UIManager _uIManager;
    private PolyhedrasModelSpawner _modelSpawner;

    private PolyhedraModel _activeModel;

    public void Init(UIManager uIManager, PolyhedrasModelSpawner modelSpawner) {
        _uIManager = uIManager;
        _modelSpawner = modelSpawner;

        _uIManager.ModelsRotated += OnModelsRotated;
        _uIManager.CompanentBlinked += OnCompanentBlinked;
    }

    private void OnModelsRotated(PolyhedraConfig config) => _activeModel = _modelSpawner.GetModelByType(config.Type);

    private void OnCompanentBlinked(PolyhedrasCompanentTypes type) => _activeModel.BlinkCompanent(type);

    public void Dispose() {
        _uIManager.ModelsRotated -= OnModelsRotated;
        _uIManager.CompanentBlinked -= OnCompanentBlinked;
    }
}
