using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : Spawner
{
    protected override Vector2 GetNextPosition() => transform.position;
}
