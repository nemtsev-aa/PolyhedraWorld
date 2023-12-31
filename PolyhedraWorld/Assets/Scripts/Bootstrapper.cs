using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private SmoothLookAt _smoothLookAt;
    [SerializeField] private VisualEffectsManager _visualEffectsManager;

    [SerializeField] private PolyhedraModelConfigs _polyhedraModelConfigs;
    [SerializeField] private PolyhedraCompanentsMaterialConfig _materialConfig;
    [SerializeField] private PolyhedrasModelSpawner _modelSpawner;
    [SerializeField] private PolyhedraModelFactory _modelFactory;

    [SerializeField] private PolyhedraConfigs _polyhedraConfigs;

    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private JoysticInputHandler _handler;

    private void Start() {
        Logger.Instance.Log("������ ������ [Bootstrapper: Start]");

        _uIManager.Init(_companentsFactory, _dialogFactory, _polyhedraConfigs, _materialConfig);
        _smoothLookAt.Init(_uIManager);

        _modelFactory.Init(_polyhedraModelConfigs);
        
        _handler.Init(_uIManager);
        _modelSpawner.Init(_modelFactory, _polyhedraConfigs, _handler, _materialConfig);
        _modelSpawner.StartWork();

        _visualEffectsManager.Init(_uIManager, _modelSpawner);

        Logger.Instance.Log("����� ������ [Bootstrapper: Start]");
    }
}
