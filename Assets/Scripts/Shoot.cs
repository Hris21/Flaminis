using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody2D bulletInstance;
            bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
            bulletInstance.AddForce(bulletSpawnPoint.right * bulletSpeed); // TODO shoot direction sync with facing direction
        }
	}
}
