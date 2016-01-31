using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool IS_FACING_RIGHT = true;
    private bool IS_FACING_LEFT = false;
    private bool IS_ON_GROUND = true;

    private bool didJump = false;
    public const float maxFlapSpeed = 0.3f;
    public const float moveSpeed = 10f;
    public float jumpHeight;
    private bool facingRight = true;
    private float lockPos = 0;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Platform")
        {
            IS_ON_GROUND = true;
        }
    }

    // Update is called once per frame
    private void Update()
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
                rb.velocity = new Vector2(-7, rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            IS_FACING_LEFT = false;
            if (!IS_FACING_LEFT)
            {
                Flip();
                rb.velocity = new Vector2(7, rb.velocity.y);
                //rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Force);
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

    private void Flip()
    {
        IS_FACING_RIGHT = !IS_FACING_RIGHT;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void MoveCamera()
    {
        var otherPlayer = GameObject.Find("PlayerIce");

        if (this.transform.position.x > Camera.main.transform.position.x && this.transform.position.x < otherPlayer.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, -10);
        }
    }
}