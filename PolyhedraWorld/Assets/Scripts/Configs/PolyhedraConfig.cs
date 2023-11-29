using UnityEngine;
using System;

[Serializable]
public class PolyhedraConfig : UICompanentConfig {
    [field: SerializeField] public PolyhedraTypes Type;
    [field: SerializeField] public string Name;
    [field: SerializeField] public Sprite Icon;
    [field: SerializeField] public PolyhedraCompanents Companents;

    public override void OnValidate() {
        throw new NotImplementedException();
    }
}
