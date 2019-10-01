using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpForce => _jumpForce;

    [SerializeField] private UIGameLevel _ui;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private Jumpment _jumpment;
    private int _coinsNumber = 0;
    private bool _inAir = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpment = GetComponent<Jumpment>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_inAir)
        {
            _inAir = true;
            _jumpment.Jump(_jumpForce);
        }

        StopInertiaMovement();
    }

    private void StopInertiaMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
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
            _coinsNumber++;
            _ui.ChangeCoinsText(_coinsNumber);
        }
    }
}
