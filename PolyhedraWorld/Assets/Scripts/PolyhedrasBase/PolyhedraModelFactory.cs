using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PolyhedraModelFactory", menuName = "Factory/PolyhedraModelFactory")]
public class PolyhedraModelFactory : ScriptableObject {
    [SerializeField] private PolyhedraModelConfigs _modelConfigs;

    public PolyhedraModel Get(PolyhedraDescription description, Transform parent) {
        PolyhedraModelConfig config = GetModelConfig(description);
        PolyhedraModel model = Instantiate(config.ModelPrefab, parent);

        return model;
    }

    private PolyhedraModelConfig GetModelConfig(PolyhedraDescription description) {
        PolyhedraModelConfig config = _modelConfigs.List.FirstOrDefault(model =>
                model.Class == description.Class
                && model.Type == description.Type);

        return config;
    }
}
