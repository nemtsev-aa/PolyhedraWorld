using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsDialog : Dialog {
    public override void Init() {

        AddListeners();
        IsInit = true;
    }

    public override void AddListeners() {
        base.AddListeners();
    }

    public override void RemoveListeners() {
        base.RemoveListeners();
    }
}
