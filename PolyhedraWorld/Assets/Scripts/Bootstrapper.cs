using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private DialogSelectorViewConfigs _selectorViewConfigs;

    [SerializeField] private DialogFactory _dialogFactory;
    [SerializeField] private UICompanentsFactory _companentsFactory;

    private DialogMediator _dialogMediator;
    private DialogSwitcher _dialogSwitcher;

    private void Start() {
        
        _dialogSwitcher = new DialogSwitcher(_dialogFactory, _uIManager.DialogsParent, _uIManager.SwitcherView);
        _dialogMediator = new DialogMediator(_dialogSwitcher);

        _uIManager.Init(_selectorViewConfigs, _companentsFactory, _dialogSwitcher, _dialogMediator);
    }
}
