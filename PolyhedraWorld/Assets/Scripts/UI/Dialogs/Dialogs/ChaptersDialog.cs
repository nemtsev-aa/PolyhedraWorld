using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaptersDialog : Dialog {
    [SerializeField] private UICompanentsFactory _companentsFactory;
    [SerializeField] private PolyhedraConfigs _polyhedraConfigs;

    private DialogMediator _dialogMediator;
    private PolyhedrasPanel _polyhedrasPanel;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        _dialogMediator = mediator;
        
        InitializationPanels();
        base.Init(mediator);
        IsInit = true;
    }

    public override void Show(bool value) {
        base.Show(value);
 
    }

    public override void ShowPanel<T>(bool value) {
        base.ShowPanel<T>(value);

    }

    private void InitializationPanels() {
        _polyhedrasPanel = GetPanelByType<PolyhedrasPanel>();
        _polyhedrasPanel.Init(_polyhedraConfigs, _companentsFactory);
        _polyhedrasPanel.Show(true);
    }

    public override void AddListeners() {
        base.AddListeners();

    }

    public override void RemoveListeners() {
        base.RemoveListeners();
        
    }
}
