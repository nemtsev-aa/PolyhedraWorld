using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewsManager : UIPanel {
    public event Action<PolyhedrasCompanentTypes> PolyhedrasCompanentBlinked;

    [SerializeField] private List<UICompanent> _views;

    private PolyhedraConfig _config;
    private UICompanent _currentView;

    private SpecificationDialog _specificationDialog;
    private PolyhedraWidget _widget;

    public void Init(SpecificationDialog specificationDialog) {
        _specificationDialog = specificationDialog;

        _widget = GetViewByType<PolyhedraWidget>();
        AddListeners();
    }

    public override void AddListeners() {
        base.AddListeners();

        _specificationDialog.PolyhedraConfigChanged += InitializationViews;
        _widget.SelectedCompanentChanged += OnSelectedCompanentChanged;
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

        _specificationDialog.PolyhedraConfigChanged -= InitializationViews;
        _widget.SelectedCompanentChanged -= OnSelectedCompanentChanged;
    }

    public T GetViewByType<T>() where T : UICompanent {
        return (T)_views.FirstOrDefault(view => view is T);
    }

    public void ShowViewByType(Type type) {
        UICompanent view = _views.FirstOrDefault(view => view.GetType() == type);

        if (_currentView != null)
            _currentView.Show(false);

        _currentView = view;
        _currentView.Show(true);
    }

    private void InitializationViews(PolyhedraConfig config) {
        _config = config;

        DescriptionTextView description = GetViewByType<DescriptionTextView>(); 
        description.Init(_config.Description);

        _widget.Int(_config);

        LinksView linksView = GetViewByType<LinksView>();
        linksView.Init(_config.Links);
    }

    private void OnSelectedCompanentChanged(PolyhedrasCompanentTypes type) => PolyhedrasCompanentBlinked?.Invoke(type);
}
