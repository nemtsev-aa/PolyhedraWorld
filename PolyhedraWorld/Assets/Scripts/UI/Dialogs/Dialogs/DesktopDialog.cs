using System;
using UnityEngine;

public class DesktopDialog : Dialog {
    private DialogMediator _dialogMediator;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        base.Init(mediator);
        _dialogMediator = mediator;

        

        IsInit = true;
        UpdateWidgets();
    }

    public override void AddListeners() {
        base.AddListeners();

        
    }

    public void UpdateWidgets() { }


    public override void RemoveListeners() {
        base.RemoveListeners();

        
    }
}
