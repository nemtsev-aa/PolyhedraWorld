using UnityEngine;
using System;

[Serializable]
public class PolyhedraConfig : UICompanentConfig {
    [field: SerializeField] public PolyhedraTypes Type { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public PolyhedraCompanents Companents { get; private set; }
    [field: SerializeField] public Links Links { get; private set; }
    
    public override void OnValidate() {
        throw new NotImplementedException();
    }
}
