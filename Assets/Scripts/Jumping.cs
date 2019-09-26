using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(float force)
    {
        _rb.AddForce(force * Vector2.up, ForceMode2D.Impulse);
    }
}
