using UnityEngine;
using System;

public class DialogMediator : IDisposable {
    public event Action<PolyhedraConfig> PolyhedraSelected;
    public event Action<PolyhedrasCompanentTypes> PolyhedraCompanentSelected;
    public event Action<float, float> JoysticValueChanged;
    public event Action ColorSettingsChanged;

    private UIManager _uIManager;
    private UICompanentsFactory _companentsFactory;

    public DialogMediator(UIManager uIManager, DialogSwitcher dialogSwitcher,
                          PolyhedraConfigs configs, PolyhedraCompanentsMaterialConfig materialConfig,
                          UICompanentsFactory companentsFactory) {

        _uIManager = uIManager;
        _companentsFactory = companentsFactory;

        _dialogSwitcher = dialogSwitcher;
        Configs = configs;
        MaterialConfig = materialConfig;

        GetDialogs();
        AddListeners();
    }

    private DesktopDialog _desktopDialog;
    private PolyhedrasDialog _polyhedrasDialog;
    private SpecificationDialog _specificationDialog;
    private SettingsDialog _settingsDialog;
    private AboutDialog _aboutDialog;

    private DialogSwitcher _dialogSwitcher;
    public PolyhedraConfigs Configs { get; }
    public PolyhedraConfig Config { get; }
    public PolyhedraCompanentsMaterialConfig MaterialConfig { get; }

    private void GetDialogs() {
        _desktopDialog = _uIManager.GetDialogByType(DialogTypes.Desktop).GetComponent<DesktopDialog>();
        _polyhedrasDialog = _uIManager.GetDialogByType(DialogTypes.Polyhedras).GetComponent<PolyhedrasDialog>();
        _specificationDialog = _uIManager.GetDialogByType(DialogTypes.Specification).GetComponent<SpecificationDialog>();
        _settingsDialog = _uIManager.GetDialogByType(DialogTypes.Settings).GetComponent<SettingsDialog>();
        _aboutDialog = _uIManager.GetDialogByType(DialogTypes.About).GetComponent<AboutDialog>();
    }

    private void AddListeners() {
        SubscribeToDesktopDialogActions();
        SubscribeToPolyhedrasDialogActions();
        SubscribeToSpecificationDialogActions();
        SubscribeToSettingsDialogActions();
        SubscribeToAboutDialogActions();
    }

    private void RemoveListeners() {
        UnSubscribeToDesktopDialogActions();
        UnSubscribeToPolyhedrasDialogActions();
        UnSubscribeToSpecificationDialogActions();
        UnSubscribeToSettingsDialogActions();
        UnSubscribeToAboutDialogActions();
    }

    #region DesktopDialogActions
    private void SubscribeToDesktopDialogActions() {
        _desktopDialog.PolyhedrasDialogShowed += OnPolyhedrasDialogShowed;
        _desktopDialog.SettingsDialogShowed += OnSettingsDialogShowed;
        _desktopDialog.AboutDialogShowed += OnAboutDialogShowed;
        _desktopDialog.Quited += OnQuited;
        _desktopDialog.BackClicked += OnQuited;
    }

    private void UnSubscribeToDesktopDialogActions() {
        _desktopDialog.PolyhedrasDialogShowed -= OnPolyhedrasDialogShowed;
        _desktopDialog.SettingsDialogShowed -= OnSettingsDialogShowed;
        _desktopDialog.AboutDialogShowed -= OnAboutDialogShowed;
        _desktopDialog.Quited -= OnQuited;
    }

    private void OnPolyhedrasDialogShowed() => _dialogSwitcher.ShowDialog(DialogTypes.Polyhedras);

    private void OnSettingsDialogShowed() => _dialogSwitcher.ShowDialog(DialogTypes.Settings);

    private void OnAboutDialogShowed() => _dialogSwitcher.ShowDialog(DialogTypes.About);

    private void OnQuited() => Application.Quit();

    #endregion

    #region PolyhedrasDialogActions

    private void SubscribeToPolyhedrasDialogActions() {
        _polyhedrasDialog.PolyhedraSelected += OnPolyhedraSelected;
        _polyhedrasDialog.BackClicked += OnPolyhedrasDialogBackClicked;
    }

    private void UnSubscribeToPolyhedrasDialogActions() {
        _polyhedrasDialog.PolyhedraSelected -= OnPolyhedraSelected;
        _polyhedrasDialog.BackClicked -= OnPolyhedrasDialogBackClicked;
    }

    private void OnPolyhedraSelected(PolyhedraConfig config) {
        PolyhedraSelected?.Invoke(config);

        _specificationDialog.SetPolyhedraConfig(config);
        _dialogSwitcher.ShowDialog(DialogTypes.Specification);
    }

    private void OnPolyhedrasDialogBackClicked() => _dialogSwitcher.ShowDialog(DialogTypes.Desktop);
    #endregion

    #region SpecificationDialogActions
    private void SubscribeToSpecificationDialogActions() {
        _specificationDialog.BackClicked += OnSpecificationDialogBackClicked;
        _specificationDialog.PolyhedraCompanentSelected += OnPolyhedraCompanentSelected;
        _specificationDialog.JoysticValueChanged += OnJoysticValueChanged;
    }

    private void UnSubscribeToSpecificationDialogActions() {
        _specificationDialog.BackClicked -= OnSpecificationDialogBackClicked;
        _specificationDialog.PolyhedraCompanentSelected -= OnPolyhedraCompanentSelected;
        _specificationDialog.JoysticValueChanged -= OnJoysticValueChanged;
    }

    private void OnSpecificationDialogBackClicked() => _dialogSwitcher.ShowDialog(DialogTypes.Polyhedras);

    private void OnPolyhedraCompanentSelected(PolyhedrasCompanentTypes type) => PolyhedraCompanentSelected?.Invoke(type);

    private void OnJoysticValueChanged(float horizontal, float vertical) => JoysticValueChanged?.Invoke(horizontal, vertical);
    #endregion

    #region SettingsDialogActions
    private void SubscribeToSettingsDialogActions() {
        _settingsDialog.BackClicked += OnPolyhedrasDialogBackClicked;
        _settingsDialog.ElementColorChanged += OnElementColorChanged;
        _settingsDialog.ColorSettingsChanged += OnColorSettingsChanged;
    }

    private void UnSubscribeToSettingsDialogActions() {
        _settingsDialog.BackClicked -= OnPolyhedrasDialogBackClicked;
        _settingsDialog.ElementColorChanged -= OnElementColorChanged;
        _settingsDialog.ColorSettingsChanged -= OnColorSettingsChanged;
    }

    private void OnElementColorChanged(PolyhedrasCompanentTypes type, Color color) {
        MaterialConfig.SetColorByCompanentType(type, color);
    }

    private void OnColorSettingsChanged() => ColorSettingsChanged?.Invoke();

    #endregion

    #region AboutDialogActions
    private void SubscribeToAboutDialogActions() {
        _aboutDialog.BackClicked += OnPolyhedrasDialogBackClicked;
    }

    private void UnSubscribeToAboutDialogActions() {
        _aboutDialog.BackClicked -= OnPolyhedrasDialogBackClicked;
    }

    #endregion

    public void Dispose() {
        RemoveListeners();
    }
}