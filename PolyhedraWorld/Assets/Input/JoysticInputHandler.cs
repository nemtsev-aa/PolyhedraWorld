using System;
using UnityEngine;

public class JoysticInputHandler : MonoBehaviour, IDisposable {
    public event Action<float, float> InputChanged;

    private UIManager _uIManager;

    public void Init(UIManager uIManager) {
        _uIManager = uIManager;
        _uIManager.InputValueChanged += OnInputValueChanged;
    }

    private void OnInputValueChanged(float horizontal, float vertical) => InputChanged?.Invoke(horizontal, vertical);

    public void Dispose() {
        _uIManager.InputValueChanged -= OnInputValueChanged;
    }
}
