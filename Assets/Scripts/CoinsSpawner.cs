using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public Jumping JumpinComponent { get; private set; }

    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private LevelSpeed _levelSpeed;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _newCoinCooldown;
    [SerializeField] private int _minCoins;
    [SerializeField] private int _maxCoins;
    private float _spawnTimer;
    private float _newCoinTimer;
    private int _coinsToInstantiate;

    private void Start()
    {
        JumpinComponent = GetComponent<Jumping>();
        _spawnTimer = _spawnCooldown;
        _newCoinTimer = 0;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0)
            StartCoinsLine();

        if(_newCoinTimer <= 0 && _coinsToInstantiate > 0)
            CreateCoin();
        else
            _newCoinTimer -= Time.deltaTime;
    }

    private void StartCoinsLine()
    {
        _spawnTimer = _spawnCooldown + Random.Range(-1f, 1f);
        _coinsToInstantiate = Random.Range(_minCoins, _maxCoins + 1);
        _newCoinTimer = _newCoinCooldown;
    }

    private void CreateCoin()
    {
        GameObject coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<Movement>().Constructor(_levelSpeed);
        _newCoinTimer = _newCoinCooldown;
        _coinsToInstantiate--;
    }
}
