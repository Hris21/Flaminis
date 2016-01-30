using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
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
    void Update()
    {
        this.MoveCamera();

        var rb = GetComponent<Rigidbody2D>();
        var ground = GameObject.FindGameObjectWithTag("Ground").transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

        if (Input.GetKey(KeyCode.A))
        {
            IS_FACING_RIGHT = false;
            if (!IS_FACING_RIGHT)
            {
                Flip();
                transform.Translate(new Vector2(-moveSpeed, 0f));
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            IS_FACING_LEFT = false;
            if (!IS_FACING_LEFT)
            {
                Flip();
                transform.Translate(new Vector2(moveSpeed, 0f));
            }
        }

        if (Input.GetKey(KeyCode.Space) && IS_ON_GROUND == true)
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

    void MoveCamera()
    {
        var otherPlayer = GameObject.Find("PlayerIce");

        if (this.transform.position.x > Camera.main.transform.position.x && this.transform.position.x > otherPlayer.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, -10);
        }

    }
}
