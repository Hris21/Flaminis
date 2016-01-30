using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 4f;
    private float moveHorizontal;
    private float moveVertical;
    public float jumpHeight;
    private bool facingRight = true;

	// Update is called once per frame
	void Update ()
    {
        //float h = Input.GetAxis("Horizontal");

        //transform.Translate(new Vector3(h * moveSpeed * Time.deltaTime, 0f, 0f));

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1;
            if (facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;
            if (!facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            moveVertical = 1;
        }

        transform.Translate(new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0f, 0f));
        transform.Translate(new Vector3(0f, moveVertical * jumpHeight * Time.deltaTime, 0f));
        transform.Rotate(new Vector3(0f, 0f, 0f));
        moveVertical = 0;
        moveHorizontal = 0;
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
