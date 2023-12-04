using System;

public class ModelInput : IDisposable {
    private bool _isEnable = false;
    private float _horizontalRotation;
    private float _verticalRotation;

    private JoysticInputHandler _handler;

    public ModelInput(JoysticInputHandler handler) {
        _handler = handler;
        _handler.InputChanged += OnInputChanged;
    }

    private void OnInputChanged(float horizontal, float vertical) {
        if (_isEnable == true) {
            _horizontalRotation = horizontal;
            _verticalRotation = vertical;
        } 
    }

    public float HorizontalRotation => _horizontalRotation;
    public float VerticalRotation => _verticalRotation;

    public void Enable() => _isEnable = true;
    public void Disable() => _isEnable = false;

    public void Dispose() {
        _handler.InputChanged -= OnInputChanged;
    }
}
