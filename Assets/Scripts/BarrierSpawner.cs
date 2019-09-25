using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _barrierPrefab;
    [SerializeField] private LevelSpeed _levelSpeed;
    [SerializeField] private Transform _coinsSpawnerTransform;
    [SerializeField] private Rigidbody2D _coinsSpawnerRB;
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
            Displace();

            var barrierPositionIsUp = Random.Range(0, 2) == 0;
            GameObject barrier = null;
            if(barrierPositionIsUp)
                barrier = Instantiate(_barrierPrefab, _barrierSpawnerUp.position, Quaternion.identity);
            else
                barrier = Instantiate(_barrierPrefab, _barrierSpawnerDown.position, Quaternion.identity);
            barrier.GetComponent<Movement>().Constructor(_levelSpeed);

            if(!barrierPositionIsUp)
                _coinsSpawnerRB.AddForce(_player.GetJumpForce() * Vector2.up, ForceMode2D.Impulse);
        }
        _spawnTimer -= Time.deltaTime;
    }
    
    private void Displace()
    {
        Vector2 vel = new Vector2(_levelSpeed.Get(), _player.GetJumpForce());
        float ballisticDistance = Vector2.SqrMagnitude(vel) * Mathf.Sin(2 * Vector2.Angle(new Vector2(0, vel.y), new Vector2(vel.x, 0))) / Physics2D.gravity.y;
        transform.position = new Vector3(_coinsSpawnerTransform.position.x + 0.5f * ballisticDistance, transform.position.y, 0);
    }
}
