using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x > GM.leftBorder) {
            transform.Translate(GM.LevelSpeed * Vector2.left * Time.deltaTime);
        }
        else {
            Destroy(gameObject);
        }
    }
}
