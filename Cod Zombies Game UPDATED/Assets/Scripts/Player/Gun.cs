﻿
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public float baseDmg = 10f;
    public float damage = 10f;
    public float baseFireRate = 15f;
    public float fireRate = 15f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float impactForce = 1200f;

    public int clips;
    public int maxClips;
    public int clipSize;
    [SerializeField] private int _ammoInUse => ammoInUse;
    [SerializeField] private Text AmmoText;

    public int ammo;
    private int ammoInUse;
    private bool _isReloading = false;

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject impactEffect;

    [SerializeField] private ParticleSystem muzzleFlash;

    private EnemyHealth enemyHealth;

    private float NextTimeToFire = 0f;

    private bool exec = false;

    private void Start()
    {
        ammo = clips * clipSize;
        ammoInUse = clipSize;
    }
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        AmmoText.text = ammoInUse.ToString()+ "/" + ammo.ToString();
    }
    void Shoot()
    {
        if (ammo + ammoInUse <= 0)
            return;
        if (ammoInUse > 0)
        {
            ammoInUse--;
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.transform.tag == "Enemy")
                {
                    var tempEnemy = hit.transform.gameObject;
                    enemyHealth = tempEnemy.GetComponent<EnemyHealth>();
                    enemyHealth.Health -= damage;
                }
                Destroy(impact, 2f);

            }
        
        } else
        {
            Reload();
        }
    }

    
    private void Reload()
    {
        if (!exec)
        {
            ammo -= clipSize;
            clips--;
            exec = true;
        }
        _isReloading = true;
        ammoInUse = clipSize;
        exec = false;
        _isReloading = false;
    }
}
