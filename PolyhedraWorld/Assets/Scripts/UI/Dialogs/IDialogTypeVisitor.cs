public interface IDialogTypeVisitor {
    void Visit(Dialog dialog);
    void Visit(DesktopDialog desktop);
    void Visit(PolyhedrasDialog transactions);
    void Visit(SpecificationDialog category);
    void Visit(SettingsDialog settingsDialog);
    void Visit(AboutDialog aboutDialog);
}
