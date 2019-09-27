using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;

    private float _timeFromLevelStart = 0;

    private void Update()
    {
        _timeFromLevelStart += Time.deltaTime;
    }

    public float Get()
    {
        return _baseSpeed + 0.2f * _timeFromLevelStart;
    }
}
