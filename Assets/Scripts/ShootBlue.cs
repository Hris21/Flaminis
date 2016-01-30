﻿using UnityEngine;
using System.Collections;

public class ShootBlue : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireDelay = 0.5f;
    public float bulletSpeed;
    float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G) &&  cooldown <=0 )
        {
            Rigidbody2D bulletInstance;
            if (GlobalManager.IS_FACING_RIGHT_ICE)
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce(-bulletSpawnPoint.right * bulletSpeed);

            }
            else
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce(bulletSpawnPoint.right * bulletSpeed);
            }
            cooldown = fireDelay;
        }
    }
}
