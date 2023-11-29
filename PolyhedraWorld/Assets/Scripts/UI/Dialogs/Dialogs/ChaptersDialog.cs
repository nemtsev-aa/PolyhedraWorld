using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaptersDialog : Dialog {
    [SerializeField] private UICompanentsFactory _companentsFactory;
    
    private DialogMediator _dialogMediator;

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

    private void InitializationPanels() {
        
    }

    public override void AddListeners() {
        base.AddListeners();

        
    }

    public override void RemoveListeners() {
        base.AddListeners();
        
    }
}
