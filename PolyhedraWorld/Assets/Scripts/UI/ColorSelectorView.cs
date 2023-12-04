using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectorView : MonoBehaviour, IDisposable {
    public event Action<ColorSelectorView> CompanentTypeSelected;

    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _colorIcon;

    [field: SerializeField] public PolyhedrasCompanentTypes CompanentType;

    public void Init(Color color) {
        _colorIcon.color = color;

        AddListeners();
    }

    public void SetColor(Color color) => _colorIcon.color = color;

    private void AddListeners() {
        _toggle.onValueChanged.AddListener(ToggleClick);
    }

    private void RemoveListeners() {
        _toggle.onValueChanged.RemoveListener(ToggleClick);
    }

    private void ToggleClick(bool value) {
        if (value)
            CompanentTypeSelected?.Invoke(this);
    }

    public void Dispose() {
        RemoveListeners();
    }
}
