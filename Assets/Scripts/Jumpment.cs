using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpment : MonoBehaviour
{
    public float JumpForce => _jumpForce;

    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rb.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
