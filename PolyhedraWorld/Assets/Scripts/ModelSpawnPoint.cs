using UnityEngine;

public class ModelSpawnPoint : MonoBehaviour {
    private PolyhedraModel _model;

    public bool IsEmpty {
        get {
            if (_model == null)
                return true;
            else
                return false;
        }
    }

    public void Init(PolyhedraModel model) {
        _model = model;
    }
}
