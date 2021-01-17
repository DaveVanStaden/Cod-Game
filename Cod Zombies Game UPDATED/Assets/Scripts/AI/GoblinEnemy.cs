using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinEnemy : Enemy
{
    [SerializeField]private NavMeshAgent navAgent;
    void Start()
    {
        base.Start();
        navAgent.speed = 6;
        navAgent.acceleration = 4;
        enemyDmg = 10;
        maxTime = 2;
    }
}
