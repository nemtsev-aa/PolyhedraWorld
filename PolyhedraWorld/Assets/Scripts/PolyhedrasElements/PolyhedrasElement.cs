using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class PolyhedrasElement : MonoBehaviour {
    [SerializeField] protected Material Material;
    [SerializeField] protected Renderer Renderer;
    [SerializeField] protected ColorChanger ColorChanger;
    protected Material WorkMaterial;
    
    public bool IsBlink { get; private set; } = false;
    

    private void OnValidate() {
        ColorChanger = GetComponent<ColorChanger>();
    }

    public void Init() {
        WorkMaterial = new Material(Material);
        Renderer.material = WorkMaterial;
    }

    public virtual void Show(bool status) {
        if (status == true) {
            ColorChanger.Init(WorkMaterial);
            ColorChanger.StartChangingColor();
            IsBlink = true;
        }
        else {
            ColorChanger.StopChangingColor();
            Renderer.material = Material;
            IsBlink = false;
        }  
    }
}
