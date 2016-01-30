﻿using UnityEngine;
using System.Collections;

public class PlayerIceMovement : MonoBehaviour
{
    private bool IS_FACING_RIGHT = true;
    private bool IS_FACING_LEFT = false;
    private bool IS_ON_GROUND = true;

    private bool didJump = false;
    public const float maxFlapSpeed = 0.3f;
    public const float moveSpeed = 0.2f;
    public float jumpHeight;
    private bool facingRight = true;
    private float lockPos = 0;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Platform")
        {
            IS_ON_GROUND = true;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody2D>();
        var ground = GameObject.FindGameObjectWithTag("Ground").transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            IS_FACING_RIGHT = false;
            if (!IS_FACING_RIGHT)
            {
                
                transform.Translate(new Vector2(-moveSpeed, 0f));
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            IS_FACING_LEFT = false;
            if (!IS_FACING_LEFT)
            {
                
                transform.Translate(new Vector2(moveSpeed, 0f));
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && IS_ON_GROUND == true)
        {

            IS_ON_GROUND = false;
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            if (rb.transform.position == ground)
            {
                IS_ON_GROUND = true;
            }
        }
    }

    void Flip()
    {
        IS_FACING_RIGHT = !IS_FACING_RIGHT;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}