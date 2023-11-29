using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PolyhedraView : UICompanent {
    public event Action<PolyhedraConfig> SelectedPolyhedraViewChanged;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _iconImage;

    [field: SerializeField] public Toggle Toggle { get; private set; }
    public PolyhedraConfig Config { get; private set; }

    public void Int(PolyhedraConfig config) {
        Config = config;

        UpdateCompanents();
        AddListeners();
    }

    private void UpdateCompanents() {
        _nameText.text = Config.Name;
        _iconImage.sprite = Config.Icon;
        _toggle.isOn = false;
    }

    private void AddListeners() {
        _toggle.onValueChanged.AddListener(ToggleClick);
    }

    private void RemoveListeners() {
        _toggle.onValueChanged.RemoveListener(ToggleClick);
    }

    private void ToggleClick(bool value) {
        if (value == true)
            SelectedPolyhedraViewChanged?.Invoke(Config);
    }

    public override void Dispose() {
        base.Dispose();
        RemoveListeners();
    }
}
