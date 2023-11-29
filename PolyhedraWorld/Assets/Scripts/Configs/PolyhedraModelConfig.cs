using UnityEngine;
using System;

[Serializable]
public class PolyhedraModelConfig {
    [field: SerializeField] public PolyhedraClass Class { get; private set; }
    [field: SerializeField] public PolyhedraTypes Type { get; private set; }
    [field: SerializeField] public PolyhedraModel ModelPrefab { get; private set; }
}
