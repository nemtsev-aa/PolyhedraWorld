using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private SmoothLookAt _smoothLookAt;
    [SerializeField] private VisualEffectsManager _visualEffectsManager;

    [SerializeField] private PolyhedraModelConfigs _polyhedraModelConfigs;
    [SerializeField] private PolyhedrasModelSpawner _modelSpawner;
    [SerializeField] private PolyhedraModelFactory _modelFactory;

    [SerializeField] private PolyhedraConfigs _polyhedraConfigs;

    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private void Start() {
        _uIManager.Init(_companentsFactory, _dialogFactory, _polyhedraConfigs);
        _smoothLookAt.Init(_uIManager);

        _modelFactory.Init(_polyhedraModelConfigs);
        _modelSpawner.Init(_modelFactory, _polyhedraConfigs);
        _modelSpawner.StartWork();

        _visualEffectsManager.Init(_uIManager, _modelSpawner);
    }
}
