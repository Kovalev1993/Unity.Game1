using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : Spawner
{
    [SerializeField] private float _newCoinCooldown;
    [SerializeField] private int _minCoins;
    [SerializeField] private int _maxCoins;

    protected override Vector2 GetNextPosition()
    {
        return transform.position;
    }

    protected override void Spawn()
    {
        _lastSpawnTime = Time.time;
        StartCoroutine("CreateCoin", Random.Range(_minCoins, _maxCoins + 1));
    }

    private IEnumerator CreateCoin(int coinsToInstantiate)
    {
        for(int i = 0; i < coinsToInstantiate; i++)
        {
            _lastPosition = Instantiate(_prefab, GetNextPosition(), Quaternion.identity).transform.position;
            yield return new WaitForSeconds(_newCoinCooldown);
        }
    }
}
