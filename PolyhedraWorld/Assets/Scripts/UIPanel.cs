using System;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour, IDisposable {

    public virtual void Show(bool value) {
        gameObject.SetActive(value);
    }

    public virtual void UpdateContent() {

    }

    public virtual void AddListeners() {

    }

    public virtual void RemoveListeners() {

    }

    public void Dispose() {
        RemoveListeners();
    }
}
