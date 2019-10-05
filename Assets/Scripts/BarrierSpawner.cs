using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : Spawner
{
    [SerializeField] private Transform _barrierSpawnerDown;
    [SerializeField] private Transform _barrierSpawnerUp;

    protected override Vector2 GetNextPosition()
    {
        if(Random.value > 0.5f)
            return transform.position + _barrierSpawnerDown.localPosition;
        else
            return transform.position + _barrierSpawnerUp.localPosition;
    }
}
