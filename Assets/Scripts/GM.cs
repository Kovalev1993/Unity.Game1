using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    public GameObject BoxPrefab;
    public Player player;
    public float SpawnTimer;
    public TextMeshProUGUI CoinsText;

    public float StartLevelSpeed;
    public static float LevelSpeed;
    public static float leftBorder;
    public static float GlobalTime;

    private static GM _gm;
    private float _spawnTimer;
    private Rigidbody2D _coinsSpawnerRB;
    private Transform _boxSpawner0;
    private Transform _boxSpawner1;
    private Transform _coinsSpawner;

    void Start()
    {
        _gm = GetComponent<GM>();
        leftBorder = transform.position.x;
        GlobalTime = 0;
        _spawnTimer = SpawnTimer;
        _coinsSpawnerRB = transform.Find("CoinsSpawner").GetComponent<Rigidbody2D>();
        _boxSpawner0 = transform.GetChild(0);
        _boxSpawner1 = transform.GetChild(1);
        _coinsSpawner = transform.GetChild(2);
    }
    
    void Update()
    {
        LevelSpeed = StartLevelSpeed + GlobalTime / 5;
        
        GlobalTime += Time.deltaTime;
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0) {
            _spawnTimer = SpawnTimer + Random.Range(-1f, 1f);

            // Рассчитываем расстояние, с которого нужно прыгать, чтобы перепрыгнуть нижнее препятствие. Формула баллистического движения:
            // S = v * v * sin(2a) / g
            // Т.к. нам требуется только половина пути (в наивысшей точке прыжка мы находимся ровно над препятствием), делим не на g, а на 2 * g.
            Vector2 vel = new Vector2(LevelSpeed, player.JumpForce);
            float distance = Vector2.SqrMagnitude(vel) * Mathf.Sin(2 * Vector2.Angle(new Vector2(0, vel.y), new Vector2(vel.x, 0))) / (2 * Physics2D.gravity.y);

            // Смещаем точки спауна ровно настолько, чтобы спаунер монеток перепрыгивал через нижнее препятствие.
            _boxSpawner0.position = new Vector3(_coinsSpawner.position.x + distance, _boxSpawner0.position.y, 0);
            _boxSpawner1.position = new Vector3(_coinsSpawner.position.x + distance, _boxSpawner1.position.y, 0);

            var boxPosition = Random.Range(0, 2);
            if(boxPosition == 0)
                Instantiate(BoxPrefab, _boxSpawner0.position, Quaternion.identity);
            else
                Instantiate(BoxPrefab, _boxSpawner1.position, Quaternion.identity);

            if(boxPosition == 0)
                _coinsSpawnerRB.AddForce(player.JumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        _spawnTimer -= Time.deltaTime;
    }

    public static void ChangeCoinsText(int coins) {
        _gm.CoinsText.text = "Монет собрано: " + coins.ToString();
    }
}
