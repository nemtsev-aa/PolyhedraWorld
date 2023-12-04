using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolyhedrasModelSpawner : ObjectsSpawnerBase {
    public event Action StartCreated;
    public event Action StopCreated;

    private PolyhedraModelFactory _modelFactory;
    private PolyhedraConfigs _configs;
    private List<PolyhedraModel> _models;
    private JoysticInputHandler _handler;
    private PolyhedraCompanentsMaterialConfig _materialConfig;

    public void Init(PolyhedraModelFactory modelFactory, PolyhedraConfigs configs,
                        JoysticInputHandler handler, PolyhedraCompanentsMaterialConfig materialConfig) {
        
        _modelFactory = modelFactory;
        _configs = configs;
        _handler = handler;
        _materialConfig = materialConfig;
    }

    public PolyhedraModel GetModelByType(PolyhedraTypes type) {
        return _models.FirstOrDefault(model => model.Config.Type == type);
    }

    public override void Reset() {
        foreach (var iModel in _models) {
            iModel.RestoreOriginalViewState();
        }
    }

    protected override IEnumerator SpawnObjects() {
        StartCreated?.Invoke();

        _models = new List<PolyhedraModel>();

        for (int i = 0; i < SpawnPoints.Count; i++) {
            PolyhedraConfig config = _configs.Configs[i];
            PolyhedraTypes type = config.Type;
            
            PolyhedraModel model = _modelFactory.Get(type, transform);
            ModelInput input = new ModelInput(_handler);

            model.Init(config, input, _materialConfig);
            MoveModelToSpawnPoint(model, SpawnPoints[i]);
            
            _models.Add(model);

            yield return new WaitForSeconds(SpawnCooldown);
        }

        StopCreated?.Invoke();
    }

    private void MoveModelToSpawnPoint(PolyhedraModel model, ModelSpawnPoint spawnPoint) {
        model.transform.SetParent(spawnPoint.transform);
        model.transform.position = spawnPoint.transform.position;

        spawnPoint.Init(model);
    }

    private void ClearModelsList() {
        foreach (var iModel in _models) {
            Destroy(iModel.gameObject);
        }

        _models.Clear();
    }
}
