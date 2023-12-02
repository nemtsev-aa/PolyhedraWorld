public class PolyhedraWidgetConfig : UICompanentConfig {
    public PolyhedraWidgetConfig(PolyhedraConfig config) {
        Config = config;
    }

    public PolyhedraConfig Config;

    public override void OnValidate() { }
}
