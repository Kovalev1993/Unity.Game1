using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LevelSpeed _levelSpeed;

    private void Update()
    {
        if(_levelSpeed != null)
            transform.Translate(_levelSpeed.Get() * Vector2.right * Time.deltaTime);
    }
}
