using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpHolder;
    [SerializeField] private List<Material> powerUpMaterials;
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private GameObject Player;

    private Material SelectedMaterial;
    private Vector3 spawnLocation;
    private Renderer render;
    private string materialName;
    private Gun gun;
    private PlayerMovement playerMovement;
    private PowerUpActivator powerUps;

    private bool SpeedUpExpire;
    private bool PowerUpExpire;
    private bool FireRateUpExpire;

    //time for powerup to spawn
    private float SpawnPowerUpMax = 30f;
    private float SpawnPowerUpTime;
    private bool startPowerUpTimer = false;

    private int PowerUpNumber;

    //time for powerup to stop working
    private float PowerUpTimerMax = 20f;
    private float PowerUpCountDown;
    void Start()
    {
        PowerUpCountDown = PowerUpTimerMax;
        SpawnPowerUpTime = SpawnPowerUpMax;
    }

    // Update is called once per frame
    void Update()
    {
        Timers();
    }

    private void SpawnPowerUp()
    {
        SelectedMaterial = powerUpMaterials[Random.Range(0, powerUpMaterials.Count)];
        spawnLocation.x = Random.Range(-60, 60);
        spawnLocation.y = 2;
        spawnLocation.z = Random.Range(-60, 60);

        var tempPowerup = Instantiate(PowerUpHolder,spawnLocation, Quaternion.identity);
        render = tempPowerup.GetComponent<Renderer>();
        render.material = SelectedMaterial;
        materialName = SelectedMaterial.name;
        powerUps = tempPowerup.GetComponent<PowerUpActivator>();
        switch (materialName)
        {
            case "SpeedUp":
                powerUps.PowerUpNumber = 1;
                return;
            case "FireRateUp":
                powerUps.PowerUpNumber = 2;
                return;
            case "PowerUp":
                powerUps.PowerUpNumber = 3;
                return;
            case "MaxAmmo":
                powerUps.PowerUpNumber = 4;
                return;
        }
    }

    public void SpeedUp()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.speed += 8;
        PowerUpNumber = 1;
        startPowerUpTimer = true;
    }
    public void FireRateUp()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            gun = weapons[i].GetComponent<Gun>();
            gun.fireRate += 7;
        }
        PowerUpNumber = 2;
        startPowerUpTimer = true;
    }
    public void PowerUp()
    {
        
        for (int i = 0; i < weapons.Count; i++)
        {
            gun = weapons[i].GetComponent<Gun>();
            gun.damage += 40;
        }
        PowerUpNumber = 3;
        startPowerUpTimer = true;
    }
    public void AmmoUp()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            gun = weapons[i].GetComponent<Gun>();
            gun.ammo = gun.clipSize * gun.maxClips;
        }
        PowerUpNumber = 4;
        startPowerUpTimer = true;
    }

    private void ExpirePowerUp()
    {
        if (SpeedUpExpire == true)
        {
            playerMovement = Player.GetComponent<PlayerMovement>();
            playerMovement.speed -= 8;
            SpeedUpExpire = false;
        } else if (PowerUpExpire == true)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                gun = weapons[i].GetComponent<Gun>();
                gun.damage = gun.baseDmg;
            }
            PowerUpExpire = false;
        } else if (FireRateUpExpire == true)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                gun = weapons[i].GetComponent<Gun>();
                gun.fireRate = gun.baseFireRate;
            }
            FireRateUpExpire = false;
        }
    }
    private void Timers()
    {
        SpawnPowerUpTime -= Time.deltaTime;
        if (startPowerUpTimer == true)
            PowerUpCountDown -= Time.deltaTime;
        if (SpawnPowerUpTime <= 0)
        {
            SpawnPowerUp();
            SpawnPowerUpTime = SpawnPowerUpMax; 
        }
        if (PowerUpCountDown <= 0)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    SpeedUpExpire = true;
                    ExpirePowerUp();
                    PowerUpCountDown = PowerUpTimerMax;
                    return;
                case 2:
                    FireRateUpExpire = true;
                    ExpirePowerUp();
                    PowerUpCountDown = PowerUpTimerMax;
                    return;
                case 3:
                    PowerUpExpire = true;
                    ExpirePowerUp();
                    PowerUpCountDown = PowerUpTimerMax;
                    return;
                case 4:
                    PowerUpCountDown = PowerUpTimerMax;
                    return;
            }
            PowerUpCountDown = PowerUpTimerMax;
        }

    }
}
