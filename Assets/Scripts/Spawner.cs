using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] private float _cooldown;

    protected float _lastSpawnTime;
    protected Vector2 _lastPosition;

    private void Update()
    {
        if(_lastSpawnTime + _cooldown < Time.time)
            Spawn();
    }

    protected abstract Vector2 GetNextPosition();

    protected virtual void Spawn()
    {
        _lastSpawnTime = Time.time;
        _lastPosition = Instantiate(_prefab, GetNextPosition(), Quaternion.identity).transform.position;
    }
}
