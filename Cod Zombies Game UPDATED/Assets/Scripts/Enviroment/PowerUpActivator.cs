using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActivator : MonoBehaviour
{
    public int PowerUpNumber;

    [SerializeField] private Powerups PowerUpManager;
    private Powerups powerups;
    private void Start()
    {
        PowerUpManager = FindObjectOfType<Powerups>();
        powerups = PowerUpManager.GetComponent<Powerups>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            switch (PowerUpNumber)
            {
                case 1:
                    powerups.SpeedUp();
                    Destroy(this.gameObject);
                    return;
                case 2:
                    powerups.FireRateUp();
                    Destroy(this.gameObject);
                    return;
                case 3:
                    powerups.PowerUp();
                    Destroy(this.gameObject);
                    return;
                case 4:
                    powerups.AmmoUp();
                    Destroy(this.gameObject);
                    return;
            }
            
        }
    }
}
