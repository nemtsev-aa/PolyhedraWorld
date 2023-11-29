using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
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

        _fadeRoutine = StartCoroutine(ShowEffect());
    }

    public void StopChangingColor() {
        if (_fadeRoutine != null) {
            StopCoroutine(_fadeRoutine);

            _material.color = _startColor;
        }
    }

    private IEnumerator ShowEffect() {
        for (float t = 0; t < _duration; t += Time.deltaTime) {
            _material.SetColor("_EmissionColor", new Color(Mathf.Sin(30 * t) * 0.5f + 0.5f, 0, 0, 0));
            
            yield return null;
        }
    }
}
