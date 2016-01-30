using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
    
    // not working

    void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D otherRb2d = GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "Player2")
        {
            otherRb2d.AddForce(new Vector2(2f, 0f));
        }

    }
}
