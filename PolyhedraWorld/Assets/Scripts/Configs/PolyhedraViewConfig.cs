public class PolyhedraViewConfig : UICompanentConfig {
    public PolyhedraViewConfig(PolyhedraConfig config) {
        Config = config;
    }

    public PolyhedraConfig Config;

    public override void OnValidate() { }
}
