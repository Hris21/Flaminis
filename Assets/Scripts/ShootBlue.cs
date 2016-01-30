using UnityEngine;
using System.Collections;

public class ShootBlue : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Rigidbody2D bulletInstance;
            if (GlobalManager.facingRightIce)
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce(bulletSpawnPoint.right * bulletSpeed);

            }
            else
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce(-bulletSpawnPoint.right * bulletSpeed);
            }
        }
    }
}
