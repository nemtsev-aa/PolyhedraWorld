using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class PolyhedraModel : MonoBehaviour {
    [SerializeField] private List<PolyhedrasElement> _elements;
    
    private PolyhedrasElement _blinkedElement;

    public PolyhedraConfig Config { get; private set; }
    
    public void Init(PolyhedraConfig config) {
        Config = config;

        foreach (var iElement in _elements) {
            iElement.Init();
        }      
    }

    public void BlinkCompanent(PolyhedrasCompanentTypes type) {
        HideBlink();

        switch (type) {
            case PolyhedrasCompanentTypes.Edge:
                ShowElements<Edge>();
                break;

            case PolyhedrasCompanentTypes.Vertex:
                ShowElements<Vertex>();
                break;

            case PolyhedrasCompanentTypes.Plane:
                ShowElements<Plane>();
                break;

            default:
                throw new ArgumentNullException($"Invalid PolyhedrasCompanentTypes: {type}");
        }
    }

    private void HideBlink() {
        foreach (var iElement in _elements) {
            if (iElement.IsBlink == true) {
                iElement.Show(false);
            }
        }
    }

    private void ShowElements<T>() where T : PolyhedrasElement {
        PolyhedrasElement element = _elements.FirstOrDefault(element => element is T);

        if (element.IsBlink == false) {
            element.Show(true);
            _blinkedElement = element;
        }
    }
}
