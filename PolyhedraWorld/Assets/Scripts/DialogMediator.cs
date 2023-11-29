public class DialogMediator {
    public DialogMediator(DialogSwitcher dialogSwitcher) {
        DialogSwitcher = dialogSwitcher;

        GetDialogs();
        InitializationDialogs();
        AddListeners();
    }

    public DesktopDialog DesktopDialog { get; private set; }
    public ChaptersDialog ChaptersDialog { get; private set; }
    public SpecificationDialog SpecificationDialog { get; private set; }
    public SettingsDialog SettingsDialog { get; private set; }
    public AboutDialog AboutDialog { get; private set; }

    public DialogSwitcher DialogSwitcher { get; private set; }


    private void GetDialogs() {
        DesktopDialog = DialogSwitcher.GetDialogByType(DialogTypes.Desktop).GetComponent<DesktopDialog>();
        ChaptersDialog = DialogSwitcher.GetDialogByType(DialogTypes.Chapters).GetComponent<ChaptersDialog>();
        SpecificationDialog = DialogSwitcher.GetDialogByType(DialogTypes.Specification).GetComponent<SpecificationDialog>();
        SettingsDialog = DialogSwitcher.GetDialogByType(DialogTypes.Settings).GetComponent<SettingsDialog>();
        AboutDialog = DialogSwitcher.GetDialogByType(DialogTypes.About).GetComponent<AboutDialog>();
    }

    private void InitializationDialogs() {
        DesktopDialog.Init(this);
        ChaptersDialog.Init(this);
        SpecificationDialog.Init(this);
        SettingsDialog.Init(this);
        AboutDialog.Init(this);
    }

    private void AddListeners() {
        SubscribeToDesktopDialogActions();
        SubscribeToCategoryDialogActions();
        SubscribeToTransactionsDialogActions();
    }

    #region DesktopDialogActions
    private void SubscribeToDesktopDialogActions() {
        
    }

    #endregion

    #region CategoryDialogActions
    private void SubscribeToCategoryDialogActions() {
        
    }

    #endregion

    #region TransactionDialogActions
    private void SubscribeToTransactionsDialogActions() {
        
    }

    #endregion
}