using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorVariantView : UICompanent, IDisposable {
    public event Action<Color> ColorSelected;

    [SerializeField] private Image _colorIcon;
    [SerializeField] private Button _selectorButton;
    private ColorVariantViewConfig _config;

    public void Init(ColorVariantViewConfig config) {
        _config = config;
        _colorIcon.color = _config.Color;

        AddListeners();
    }

    private void AddListeners() {
        _selectorButton.onClick.AddListener(SelectorColorClick);
    }

    private void RemoveListeners() {
        _selectorButton.onClick.RemoveListener(SelectorColorClick);
    }

    private void SelectorColorClick() => ColorSelected?.Invoke(_config.Color);
    
}
