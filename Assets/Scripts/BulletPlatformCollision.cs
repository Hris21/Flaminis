using UnityEngine;
using System.Collections;

public class BulletPlatformCollision : MonoBehaviour {

	void OnColissionEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
