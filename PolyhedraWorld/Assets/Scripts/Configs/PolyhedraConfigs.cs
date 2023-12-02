using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PolyhedraViewConfigs", menuName = "Config/PolyhedraViewConfigs")]
public class PolyhedraConfigs : ScriptableObject {
    [SerializeField] private List<PolyhedraConfig> _configs;

    public IReadOnlyList<PolyhedraConfig> Configs => _configs;

    public PolyhedraConfig GetPolyhedraViewConfigByType(PolyhedraTypes type) {
        return _configs.FirstOrDefault(config => config.Type == type);
    }
}
