using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PolyhedraModelConfigs", menuName = "Config/PolyhedraModelConfigs")]
public class PolyhedraModelConfigs : ScriptableObject {
    [SerializeField] private List<PolyhedraModelConfig> _modelConfigs;

    public IEnumerable<PolyhedraModelConfig> List => _modelConfigs;
}
