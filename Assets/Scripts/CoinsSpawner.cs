using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float SpawnTimer;
    public float NewCoinTimer;
    public int MinCoins;
    public int MaxCoins;

    private float _spawnTimer;
    private float _newCoinTimer;
    private int _coinsToInstantiate;

    void Start()
    {
        _spawnTimer = SpawnTimer;
        _newCoinTimer = 0;
    }
    
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0) {
            _spawnTimer = SpawnTimer + Random.Range(-1f, 1f);
            _coinsToInstantiate = Random.Range(MinCoins, MaxCoins + 1);
            _newCoinTimer = NewCoinTimer;
        }
        _spawnTimer -= Time.deltaTime;

        if(_newCoinTimer <= 0 && _coinsToInstantiate > 0) {
            Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            _newCoinTimer = NewCoinTimer;
            _coinsToInstantiate--;
        }
        else {
            _newCoinTimer -= Time.deltaTime;
        }
    }
}
