using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolyhedrasPanel : UIPanel {
    public event Action<PolyhedraConfig> SelectedPolyhedraChanged;

    [SerializeField] private RectTransform _polyhedraViewParent;
    [SerializeField] private ToggleGroup _polyhedraViewGroup;
    
    private List<PolyhedraView> _polyhedraViewList = new List<PolyhedraView>();
    private PolyhedraConfigs _polyhedraConfigs;
    private UICompanentsFactory _companentsFactory;

    public void Init(PolyhedraConfigs polyhedraConfigs, UICompanentsFactory companentsFactory) {
        _polyhedraConfigs = polyhedraConfigs;
        _companentsFactory = companentsFactory;

        AddListeners();
    }

    public override void AddListeners() {
        base.AddListeners();
        
    }

    public override void RemoveListeners() {
        base.RemoveListeners();

    }

    public override void Show(bool value) {
        base.Show(value);

        if (value == false)
            Reset();
        else
            UpdateContent();
    }

    public override void UpdateContent() {
        base.UpdateContent();

        if (_polyhedraViewList.Count == 0)
            CreatePolyhedraViewList();

        Toggle[] toggles = _polyhedraViewGroup.GetComponentsInChildren<Toggle>();
        toggles[0].isOn = true;
    }

    public void Reset() {
        
    }

    private void CreatePolyhedraViewList() {
        foreach (var iConfig in _polyhedraConfigs.Configs) {
            PolyhedraViewConfig newConfig = new PolyhedraViewConfig(iConfig);
            PolyhedraView newView = _companentsFactory.Get<PolyhedraView>(newConfig, _polyhedraViewParent);
            newView.Toggle.group = _polyhedraViewGroup;
            newView.Int(iConfig);

            newView.SelectedPolyhedraViewChanged += OnSelectedPolyhedraViewChanged;
            _polyhedraViewList.Add(newView);
        }
    }

    private void OnSelectedPolyhedraViewChanged(PolyhedraConfig config) => SelectedPolyhedraChanged?.Invoke(config);

    private void FilterList(string value, bool isCyrillic) {
        if (value == "") {
            foreach (PolyhedraView item in _polyhedraViewList) {
                item.gameObject.SetActive(true);
            }
        } else {
            foreach (PolyhedraView item in _polyhedraViewList) {
                if (CheckView(item, value, isCyrillic) == true)
                    item.gameObject.SetActive(true);
                else
                    item.gameObject.SetActive(false);
            }
        }
    }

    private bool CheckView(PolyhedraView item, string value, bool isCyrillic) {
        bool checkResult;

        if (isCyrillic)
            checkResult = item.Config.Name.ToLower().Contains(value.ToLower());
        else
            checkResult = $"{item.Config.Type}".ToLower().Contains(value.ToLower());

        return checkResult;
    }
}
