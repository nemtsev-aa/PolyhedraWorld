using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
    [SerializeField] private Color _endColor = Color.clear;
    [SerializeField] private float _duration = 1f;

    private Material _material;
    private Color _startColor;
    private Coroutine _fadeRoutine;

    public void Init(Material material) {
        _material = material;
        _startColor = material.color;
        StartChangingColor();
    }

    public void StartChangingColor() {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);

        _fadeRoutine = StartCoroutine(FadeColor(_endColor));
    }

    public void StopChangingColor() {
        if (_fadeRoutine != null) {
            StopCoroutine(_fadeRoutine);

            _material.color = _startColor;
        }
    }

    private void Update() {
        if (_fadeRoutine == null)
            return;

        if (_material.color == _startColor) {
            StartCoroutine(FadeColor(_endColor));
        }
        else if (_material.color == _endColor) {
            StartCoroutine(FadeColor(_startColor));
        }
    }

    private IEnumerator FadeColor(Color targetColor) {
        float time = 0;

        while (time < _duration) {
            _material.color = Color.Lerp(_material.color, targetColor, time / _duration);
            time += Time.deltaTime;
            yield return null;
        }

        _material.color = targetColor;
    }
}
