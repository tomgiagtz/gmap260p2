using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private int extraJumps;
    public int extraJumpValue;
    private Rigidbody2D rb;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    // Start is called before the first frame update
    void Start(){
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        var jumpPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if (facingRight == false && input > 0)
        {
            flip();
        }

        else if (facingRight == true && input < 0)
        {
            flip();
        }

        if (isGrounded == true){
            extraJumps = extraJumpValue;
        }

        if (jumpPressed && extraJumps >0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (jumpPressed && extraJumps > 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsWall);

        if (isTouchingFront== true && isGrounded == false && input != 0){
            wallSliding = true;
        }
        else{
            wallSliding = false;
        }

        if (wallSliding){
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (jumpPressed && wallSliding == true){
            wallJumping = true;
            Invoke("setWallJumpFalse", wallJumpTime);
        }

        if (wallJumping == true){
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }

    }

    void flip(){

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void setWallJumpFalse() { 
        wallJumping = false;
    }

}
