public class DialogMediator {
    public DialogMediator(DialogSwitcher dialogSwitcher) {
        
        GetDialogs();
        InitializationDialogs();
        AddListeners();
    }

    public DesktopDialog DesktopDialog { get; private set; }
    public TransactionsDialog TransactionsDialog { get; private set; }
    public CategoryDialog CategoryDialog { get; private set; }
    public FinancialGoalsDialog FinancialGoalsDialog { get; private set; }
    public SettingsDialog SettingsDialog { get; private set; }
    public AboutDialog AboutDialog { get; private set; }

    public DialogSwitcher DialogSwitcher { get; private set; }


    private void GetDialogs() {
        DesktopDialog = DialogSwitcher.GetDialogByType(DialogTypes.DesktopDialog).GetComponent<DesktopDialog>();
        TransactionsDialog = DialogSwitcher.GetDialogByType(DialogTypes.Transactions).GetComponent<TransactionsDialog>();
        CategoryDialog = DialogSwitcher.GetDialogByType(DialogTypes.Category).GetComponent<CategoryDialog>();
        FinancialGoalsDialog = DialogSwitcher.GetDialogByType(DialogTypes.FinancialGoals).GetComponent<FinancialGoalsDialog>();
        SettingsDialog = DialogSwitcher.GetDialogByType(DialogTypes.Settings).GetComponent<SettingsDialog>();
        AboutDialog = DialogSwitcher.GetDialogByType(DialogTypes.About).GetComponent<AboutDialog>();
    }

    private void InitializationDialogs() {
        DesktopDialog.Init(this);
        TransactionsDialog.Init(this);
        CategoryDialog.Init(this);
        FinancialGoalsDialog.Init(this);
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