using UnityEngine;
using System.Collections;

public class PlayerIceMovement : MonoBehaviour
{
    private bool IS_ON_GROUND = true;
    
    private sbyte AXIS_X_LEFT = -1;
    private sbyte AXIS_X_RIGHT = 1;
    private sbyte MOVING_AXIS_X;

    private float jumpHeight;
    private float lockPos = 0;
    private const float maxFlapSpeed = 0.3f;
    private const float moveSpeed = 0.2f;

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

        if (Input.GetKey(KeyCode.LeftArrow))
        {   
            if (MOVING_AXIS_X == AXIS_X_RIGHT)
            {
                Flip();
            }
            MOVING_AXIS_X = AXIS_X_LEFT;

            rb.velocity = new Vector2(-7, rb.velocity.y);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (MOVING_AXIS_X == AXIS_X_LEFT)
            {
                Flip();
            }
            MOVING_AXIS_X = AXIS_X_RIGHT;

            rb.velocity = new Vector2(7, rb.velocity.y);
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
        GlobalManager.IS_FACING_RIGHT_ICE = !GlobalManager.IS_FACING_RIGHT_ICE;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void MoveCamera()
    {
        var otherPlayer = GameObject.Find("PlayerFlame");

        if (otherPlayer == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameBlue");
        }

        if (this.transform.position.x < Camera.main.transform.position.x && this.transform.position.x > otherPlayer.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, -10);
        }
    }
}
