using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSelectorViewConfigs", menuName = "Config/DialogSelectorViewConfigs")]
public class DialogSelectorViewConfigs : ScriptableObject {
    [field: SerializeField] public Color HeaderColor { get; private set; }

    [field: SerializeField] public List<SelectorViewConfig> Configs { get; private set; }
}
