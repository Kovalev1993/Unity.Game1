using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpForce;
    
    private Rigidbody2D _rb;
    private int _coins = 0;
    private bool _inAir = false;

    private void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_inAir){
            _rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
            _inAir = true;
        }
        // Чтобы шарик не катился от лёгкого прикосновения за край уровня.
        _rb.velocity = new Vector2(0, _rb.velocity.y);

        // Если ушли за левый край уровня
        if(transform.position.x <= GM.leftBorder) {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D coll){
        _inAir = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            _coins++;
            GM.ChangeCoinsText(_coins);
        }
    }
}
