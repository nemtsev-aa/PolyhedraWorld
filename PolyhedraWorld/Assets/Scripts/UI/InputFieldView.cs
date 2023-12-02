using System;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldView : UICompanent, IDisposable {
    public event Action<string, bool> InputValueChanged;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _clearField;
    private bool _isCyrillic;

    public string Value { get; private set; }
    
    public void Init() {
        AddListeners();
    }

    public void SetValue(string value) {
        Value = value;
        ShowValue();
    }

    public string GetValue() {
        return _inputField.text;
    }

    public void Reset() => ClearFieldClick();

    private void AddListeners() {
        _inputField.onValueChanged.AddListener(InputFieldValueChanged);
        _clearField.onClick.AddListener(ClearFieldClick);

        _inputField.onValidateInput += ValidateCyrillic;
    }

    private void ShowValue() => _inputField.text = Value;

    private void InputFieldValueChanged(string value) {
        if (value == "")
            return;

        Value = value;
        InputValueChanged?.Invoke(value, _isCyrillic);
    }

    private char ValidateCyrillic(string text, int charIndex, char addedChar) {
        if (!Regex.IsMatch(text, @"\P{IsCyrillic}")) 
            _isCyrillic = true;
        else
            _isCyrillic = false;

        return addedChar;
    }

    private void ClearFieldClick() {
        Value = "";
        ShowValue();
    }

    public override void Dispose() {
        _inputField.onEndEdit.RemoveListener(InputFieldValueChanged);
        _clearField.onClick.RemoveListener(ClearFieldClick);
    }
}
