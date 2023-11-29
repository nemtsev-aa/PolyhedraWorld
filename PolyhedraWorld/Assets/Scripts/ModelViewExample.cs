using UnityEngine;

public class ModelViewExample : MonoBehaviour {
    [SerializeField] private PolyhedraModel _model;

    [ContextMenu("ShowEdges")]
    public void ShowEdges() => _model.ShowEdges(true);
    [ContextMenu("HideEdges")]
    public void HideEdges() => _model.ShowEdges(false);
    [ContextMenu("ShowVertex")]
    public void ShowVertex() => _model.ShowVertexes(true);
    [ContextMenu("HideVertexes")]
    public void HideVertexes() => _model.ShowVertexes(false);
    [ContextMenu("ShowPlanes")]
    public void ShowPlanes() => _model.ShowPlanes(true);
    [ContextMenu("HidePlanes")]
    public void HidePlanes() => _model.ShowPlanes(false);
}
