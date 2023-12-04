using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PolyhedraCompanentsMaterialConfig", menuName = "Config/PolyhedraCompanentsMaterialConfig")]
public class PolyhedraCompanentsMaterialConfig : ScriptableObject {
    public event Action ConfigChanged;

    [SerializeField] private Material EdgeMaterial;
    [SerializeField] private Material VertexMaterial;
    [SerializeField] private Material PlaneMaterial;

    [field: SerializeField] public List<Color> Colors { get; private set; }

    public Material GetMaterialByCompanentType(PolyhedrasCompanentTypes type) {
        switch (type) {
            case PolyhedrasCompanentTypes.Edge:
                return EdgeMaterial;

            case PolyhedrasCompanentTypes.Vertex:
                return VertexMaterial;

            case PolyhedrasCompanentTypes.Plane:
                return PlaneMaterial;
            
            default:
                throw new ArgumentNullException($"Invalid PolyhedrasCompanentTypes: {type}");
        }
    }

    public void SetColorByCompanentType(PolyhedrasCompanentTypes type, Color color) {
        GetMaterialByCompanentType(type).color = color;
        ConfigChanged?.Invoke();
    }
}
