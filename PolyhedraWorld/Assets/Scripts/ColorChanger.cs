using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour {
    [SerializeField] private float _duration = 0.3f;

    private Material _material;
    private Color _startColor;
    private Color _endColor = Color.white;

    private Tween _colorTween;

    public void Init(Material material) {
        _material = material;
        _startColor = material.color;
    }

    public void StartChangingColor() {
        _colorTween = _material.DOColor(_endColor, _duration / 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public void StopChangingColor() {
        _material.color = _startColor;
        _colorTween.Kill();
    }

    private Color GetNewColor(float time) {
        Color newColor = Color.clear;
        float max = Mathf.Max(_material.color.r, _material.color.g, _material.color.b);
        float colorOffset = Mathf.Sin(30 * time) * 0.5f + 0.5f;

        if (max == _material.color.r) {
            newColor = new Color(colorOffset, 0, 0, 0);
        } else if (max == _material.color.g) {
            newColor = new Color(0, colorOffset, 0, 0);
        } else if (max == _material.color.b) {
            newColor = new Color(0, 0, colorOffset, 0);
        }

        return newColor;
    }
}
