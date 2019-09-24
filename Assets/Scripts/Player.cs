using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void OnCollisionEnter2D(Collision2D coll){
        _inAir = false;
    }
}
