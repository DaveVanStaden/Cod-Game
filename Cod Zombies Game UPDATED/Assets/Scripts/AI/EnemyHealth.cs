using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
