using UnityEngine;
using System;

[Serializable]
public struct PolyhedraCompanents {
    [field: SerializeField] public int Edges { get; private set; }
    [field: SerializeField] public int Vertexes { get; private set; }
    [field: SerializeField] public int Planes { get; private set; }
}
