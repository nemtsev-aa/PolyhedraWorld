public interface IDialogTypeVisitor {
    void Visit(Dialog dialog);
    void Visit(DesktopDialog desktop);
    void Visit(ChaptersDialog transactions);
    void Visit(SpecificationDialog category);
    void Visit(FinancialGoalsDialog financialGoals);
    void Visit(SettingsDialog settingsDialog);
    void Visit(AboutDialog aboutDialog);
}
