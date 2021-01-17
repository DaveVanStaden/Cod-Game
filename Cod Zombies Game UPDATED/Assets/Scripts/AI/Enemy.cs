using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent zombie;

    GameObject target;
    protected float enemyDmg { get; set;}

    protected float enemyDmgCooldown { get; set;}

    protected float speed {get;set;}

    private bool readyAttack = true;

    private float time;
    protected float maxTime;

    protected virtual void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        FindTarget();
        if (readyAttack == false)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                readyAttack = true;
                time = 0;
            }
        }
    }
    protected virtual void FindTarget()
    {
        zombie.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.tag == "Player" && readyAttack == true)
        {
            var tempPHealth = col.gameObject.GetComponent<PlayerHP>();
            tempPHealth.PlayerHp -= enemyDmg;
            readyAttack = false;
        }
    }
}
