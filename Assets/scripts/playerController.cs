using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    // movement variables
    public float maxSpeed;
    Rigidbody2D myRb;
    Animator myAnim;
    bool facingRight;

    // jumping variables
    bool grounded = false;
    float groundcheckRadius = 0.5f;
    public float groundcheckDistance = 0.5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpheight;

    // Use this for initialization
    void Start () {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (grounded && Input.GetAxis("Jump")>0)
        {
            myAnim.SetBool("isGrounded", grounded);
            myRb.AddForce(new Vector2(0, jumpheight));
        }
	}

    private void FixedUpdate()
    {
        // check if we are grounded
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundLayer);
        grounded = Physics2D.OverlapPoint(new Vector2(groundCheck.position.x, groundCheck.position.y-groundcheckDistance), groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", -myRb.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRb.velocity = new Vector2(move * maxSpeed, myRb.velocity.y);

        if(move > 0 && !facingRight)
        {
            flip();
        }else if (move < 0 && facingRight)
        {
            flip();
        }
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
