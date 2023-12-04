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
        _uIManager.ColorSettingsChanged += OnColorSettingsChanged;

        _activeModel = _modelSpawner.GetModelByType(PolyhedraTypes.Tetrahedron);
    }

    private void OnModelsRotated(PolyhedraConfig config) {
        _activeModel.EnableInput(false);
        _activeModel.RestoreOriginalViewState();

        _activeModel = _modelSpawner.GetModelByType(config.Type);
        _activeModel.EnableInput(true);
    }

    private void OnCompanentBlinked(PolyhedrasCompanentTypes type) => _activeModel.BlinkCompanent(type);

    private void OnColorSettingsChanged() {
        _modelSpawner.Reset();
        _modelSpawner.StartWork();
    }

    public void Dispose() {
        _uIManager.ModelsRotated -= OnModelsRotated;
        _uIManager.CompanentBlinked -= OnCompanentBlinked;
        _uIManager.ColorSettingsChanged -= OnColorSettingsChanged;
    }
}
