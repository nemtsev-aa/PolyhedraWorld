using System;
using UnityEngine;
using UnityEngine.UI;

public class LinkView : UICompanent {
    public event Action<string> LinkClicked;

    [SerializeField] private Button _linkButton;

    private string _linkText;

    public void Init(string text) {
        _linkText = text;

        AddListeners();
    }

    private void AddListeners() {
        _linkButton.onClick.AddListener(LinkClick);
    }

    private void RemoveListeners() {
        _linkButton.onClick.RemoveListener(LinkClick);
    }

    private void LinkClick() => LinkClicked?.Invoke(_linkText);

    public override void Dispose() {
        base.Dispose();

        RemoveListeners();
    }
}
