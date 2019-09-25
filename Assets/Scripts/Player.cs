using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private UIGame _ui;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private int _coins = 0;
    private bool _inAir = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_inAir)
        {
            _rb.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
            _inAir = true;
        }

        StopIertiaMovement();
    }

    private void StopIertiaMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public float GetJumpForce()
    {
        return _jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        _inAir = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            _coins++;
            _ui.ChangeCoinsText(_coins);
        }
    }
}
