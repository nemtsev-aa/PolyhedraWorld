using UnityEngine;

public class LinksView : UICompanent {
    [SerializeField] private LinkView _razvertkaView;
    [SerializeField] private LinkView _modelView;

    public void Init(Links links) {
        _razvertkaView.Init(links.Razvertka);
        _modelView.Init(links.Model);

        AddListeners();
    }

    private void AddListeners() {
        _razvertkaView.LinkClicked += OnLinkClicked;
        _modelView.LinkClicked += OnLinkClicked;
    }

    private void RemoveListeners() {
        _razvertkaView.LinkClicked -= OnLinkClicked;
        _modelView.LinkClicked -= OnLinkClicked;
    }

    private void OnLinkClicked(string link) => Application.OpenURL(link);

    public override void Dispose() {
        base.Dispose();
        RemoveListeners();
    }
}
