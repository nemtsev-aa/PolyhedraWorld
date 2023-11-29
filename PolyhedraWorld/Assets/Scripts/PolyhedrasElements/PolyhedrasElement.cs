using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class PolyhedrasElement : MonoBehaviour {
    [SerializeField] protected Material Material;
    [SerializeField] protected ColorChanger ColorChanger;

    private void OnValidate() {
        ColorChanger = GetComponent<ColorChanger>();
    }

    public virtual void Show(bool status) {
        if (status == true) {
            ColorChanger.Init(Material);
            ColorChanger.StartChangingColor();
        }
        else {
            ColorChanger.StopChangingColor();
        }  
    }
}
