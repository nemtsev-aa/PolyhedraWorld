using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolyhedraModel : MonoBehaviour {
    [SerializeField] private List<PolyhedrasElement> _elements;
    private PolyhedrasElement _element;

    public void ShowVertexes(bool status) => ShowElements<Vertex>(status);
    public void ShowEdges(bool status) => ShowElements<Edge>(status);
    public void ShowPlanes(bool status) => ShowElements<Plane>(status);

    private void ShowElements<T>(bool status) where T : PolyhedrasElement {
        if (status == true) 
            _element = _elements.FirstOrDefault(element => element is T);

        _element.Show(status);
    }
}
