using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent zombie;

    GameObject target;

    private void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        FindTarget();
    }
    private void FindTarget()
    {
        zombie.SetDestination(target.transform.position);
    }
}
