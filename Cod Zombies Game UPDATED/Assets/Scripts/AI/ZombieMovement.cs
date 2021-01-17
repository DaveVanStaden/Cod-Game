using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : Enemy
{
    private void Start()
    {
        base.Start();
        enemyDmg = 30;
        maxTime = 3;
    }
}
