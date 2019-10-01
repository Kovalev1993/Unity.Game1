using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    enum Position : byte
    {
        Down,
        Top
    }

    [SerializeField] private GameObject _barrierPrefab;
    [SerializeField] private LevelSpeed _levelSpeed;
    [SerializeField] private CoinsSpawner _coinsSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private Transform _barrierSpawnerDown;
    [SerializeField] private Transform _barrierSpawnerUp;

    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = _spawnCooldown;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0)
        {
            _spawnTimer = _spawnCooldown + Random.Range(-1f, 1f);
            ShiftSelfToRight();

            var barrierPosition = Random.Range(0, 2) == 0 ? Position.Down : Position.Top;
            CreateBarrier(barrierPosition);

            if(barrierPosition == Position.Down)
                _coinsSpawner.JumpmentComponent.Jump(_player.JumpForce);
        }
        _spawnTimer -= Time.deltaTime;
    }

    private void ShiftSelfToRight()
    {
        Vector2 velocity = new Vector2(_levelSpeed.Get(), _player.JumpForce);
        float ballisticDistance = Vector2.SqrMagnitude(velocity) * Mathf.Sin(2 * Vector2.Angle(new Vector2(0, velocity.y), new Vector2(velocity.x, 0))) / Physics2D.gravity.y;
        transform.position = new Vector3(_coinsSpawner.transform.position.x + 0.5f * ballisticDistance, transform.position.y, 0);
    }

    private void CreateBarrier(Position barrierPosition)
    {
        if(barrierPosition == Position.Down)
            Instantiate(_barrierPrefab, _barrierSpawnerDown.position, Quaternion.identity).GetComponent<Movement>().SetSpeed(_levelSpeed);
        else
            Instantiate(_barrierPrefab, _barrierSpawnerUp.position, Quaternion.identity).GetComponent<Movement>().SetSpeed(_levelSpeed);
    }
}
