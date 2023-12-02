using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PolyhedraModelFactory", menuName = "Factory/PolyhedraModelFactory")]
public class PolyhedraModelFactory : ScriptableObject {
    private PolyhedraModelConfigs _modelConfigs;

    public void Init(PolyhedraModelConfigs modelConfigs) {
        _modelConfigs = modelConfigs;
    }

    public PolyhedraModel Get(PolyhedraTypes type, Transform parent) {
        PolyhedraModelConfig config = GetModelConfig(type);
        PolyhedraModel model = Instantiate(config.ModelPrefab, parent);

        return model;
    }

    private PolyhedraModelConfig GetModelConfig(PolyhedraTypes type) {
        PolyhedraModelConfig config = _modelConfigs.List.FirstOrDefault(model => model.Type == type);
        return config;
    }
}
