using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsSpawnerBase : MonoBehaviour {
    [SerializeField] protected List<ModelSpawnPoint> SpawnPoints;
    protected Coroutine Spawn;

    [field: SerializeField] public float SpawnCooldown { get; private set; }

    public virtual void StartWork() {
        if (SpawnPoints.Count == 0)
            throw new ArgumentOutOfRangeException($"Invalid SpawnPoints count: {SpawnPoints}");

        StopWork();

        Spawn = StartCoroutine(SpawnObjects());
    }

    protected virtual void StopWork() {
        if (Spawn != null)
            StopCoroutine(Spawn);
    }

    public abstract void Reset();

    protected abstract IEnumerator SpawnObjects();
}
