using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAt : MonoBehaviour, IDisposable {
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration = 1f;

    private UIManager _uIManager;
    private float _toYAngle;
    private Dictionary<PolyhedraTypes, float> _angels = new Dictionary<PolyhedraTypes, float>() {
            { PolyhedraTypes.Tetrahedron, 0},
            { PolyhedraTypes.Hexahedron, 72},
            { PolyhedraTypes.Octahedron, 144},
            { PolyhedraTypes.Dodecahedron, 216},
            { PolyhedraTypes.Icosahedron, 288}
    };

    public void Init(UIManager uIManager) {
        _uIManager = uIManager;
        _uIManager.ModelsRotated += OnModelsRotated;
    }

    private void OnModelsRotated(PolyhedraConfig config) {
        _toYAngle = _angels[config.Type];

        StartCoroutine(RotateCoroutine());
    }

    public void StartRotation(PolyhedraTypes type) {
        _toYAngle = _angels[type];

        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine() {
        float time = 0;
        float startAngle = _target.eulerAngles.y;

        while (time < _duration) {
            float angle = Mathf.LerpAngle(startAngle, _toYAngle, time / _duration);
            _target.eulerAngles = new Vector3(0, angle, 0);

            time += Time.deltaTime;
            yield return null;
        }

        _target.eulerAngles = new Vector3(0, _toYAngle, 0);
    }

    public void Dispose() {
        _uIManager.ModelsRotated -= OnModelsRotated;
    }
}
