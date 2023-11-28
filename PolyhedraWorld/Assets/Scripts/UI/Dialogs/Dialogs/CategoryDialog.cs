using System;
using UnityEngine;

public class CategoryDialog : Dialog {
    [SerializeField] private UICompanentsFactory _companentsFactory;

    public override void Init(DialogMediator mediator) {
        if (IsInit == true)
            return;

        base.Init(mediator);

        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();

    }

    public override void RemoveListeners() {
        base.RemoveListeners();

    }
}
