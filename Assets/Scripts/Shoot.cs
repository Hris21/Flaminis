using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireDelay = 0.5f;
    public float bulletSpeed = 20f;
    float cooldown;

    public AudioClip shootSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

	void Update ()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && cooldown <= 0)
        {
            source.PlayOneShot(shootSound);

            Rigidbody2D bulletInstance;
            if (GlobalManager.IS_FACING_RIGHT)
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.AddForce(-bulletSpawnPoint.right * bulletSpeed);

            }
            else
            {
                bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody2D;
                bulletInstance.velocity = new Vector2((float)bulletSpawnPoint.right.x * bulletSpeed,this.transform.position.y);
            }
            cooldown = fireDelay;
        }
	}
}
