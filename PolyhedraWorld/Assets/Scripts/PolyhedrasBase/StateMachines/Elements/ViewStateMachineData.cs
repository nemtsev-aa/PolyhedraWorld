using UnityEngine;

public class ViewStateMachineData {
    public ViewStateMachineData(Material material) {
        Material = material;
    }

    public Material Material { get; set; }
    public bool IsHidden { get; set; } = false;
    public bool IsBlinked { get; set; } = false;
}
