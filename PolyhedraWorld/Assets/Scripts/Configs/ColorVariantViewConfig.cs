using UnityEngine;
using System;

[Serializable]
public class ColorVariantViewConfig : UICompanentConfig {
    public ColorVariantViewConfig(Color color) {
        Color = color;
    }

    public Color Color { get; private set; }

    public override void OnValidate() {
        
    }
}
