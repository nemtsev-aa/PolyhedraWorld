using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour, IDisposable {
    public event Action<PolyhedraConfig> ModelsRotated;
    public event Action<PolyhedrasCompanentTypes> CompanentBlinked;

    [SerializeField] private RectTransform _dialogsParent;
    
    private UICompanentsFactory _companentsFactory;
    private DialogFactory _dialogFactory;
    private PolyhedraConfigs _polyhedraConfigs;

    private DialogSwitcher _dialogSwitcher;
    private DialogMediator _dialogMediator;

    private Dictionary<DialogTypes, Dialog> _dialogsDictionary;
    
    public void Init(UICompanentsFactory companentsFactory, DialogFactory dialogFactory, PolyhedraConfigs polyhedraConfigs) {
        _companentsFactory = companentsFactory;
        _dialogFactory = dialogFactory;
        _dialogFactory.Init(_dialogsParent);
        CreateDialogs();

        _polyhedraConfigs = polyhedraConfigs;
        _dialogSwitcher = new DialogSwitcher(this);
        _dialogMediator = new DialogMediator(this, _dialogSwitcher, _polyhedraConfigs);
        _dialogMediator.PolyhedraSelected += OnPolyhedraSelected;
        _dialogMediator.PolyhedraCompanentSelected += OnPolyhedraCompanentSelected;

        _dialogSwitcher.ShowDialog(DialogTypes.Desktop);
    }

    public Dialog GetDialogByType(DialogTypes type) {
        if (_dialogsDictionary.Keys.Count == 0)
            throw new ArgumentNullException("DialogsDictionary is empty");

        return _dialogsDictionary[type];
    }

    public List<Dialog> GetDialogList() {
        return _dialogsDictionary.Values.ToList();
    }

    private void CreateDialogs() {
        _dialogsDictionary = new Dictionary<DialogTypes, Dialog> {
            { DialogTypes.Desktop, _dialogFactory.GetDialog<DesktopDialog>()},
            { DialogTypes.Polyhedras, _dialogFactory.GetDialog<PolyhedrasDialog>()},
            { DialogTypes.Specification, _dialogFactory.GetDialog<SpecificationDialog>()},
            { DialogTypes.Settings, _dialogFactory.GetDialog<SettingsDialog>()},
            { DialogTypes.About, _dialogFactory.GetDialog<AboutDialog>()}
        };

        foreach (var iDialog in _dialogsDictionary.Values) {
            iDialog.Init();
            iDialog.Close();
        }
    }

    private void OnPolyhedraSelected(PolyhedraConfig config) => ModelsRotated?.Invoke(config);

    private void OnPolyhedraCompanentSelected(PolyhedrasCompanentTypes type) => CompanentBlinked?.Invoke(type);

    public void Dispose() {
        _dialogMediator.PolyhedraSelected -= OnPolyhedraSelected;
        _dialogMediator.PolyhedraCompanentSelected -= OnPolyhedraCompanentSelected;
    }
}
