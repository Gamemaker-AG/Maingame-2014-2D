using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    new private Transform transform;
    private Transform groundedChecker;
    private Rigidbody2D rb;
    public float speed = 10;
    public float jumpPower = 6;
    public float airControl = 10;
    public float maxAirSpeed = 10;
    public int jumpCount = 2;
    private int jumpsLeft;
    public bool isGrounded { private set; get; }

	void Awake()
    {
        transform = base.transform;
        rb = rigidbody2D;
        groundedChecker = transform.Find("Grounded Checker");
	}

    private BufferedBoolean jumping = new BufferedBoolean();
	void FixedUpdate()
    {
        PerformGroundedCheck();

        var movement = Mathf.Round(Input.GetAxisRaw("Horizontal")) * speed;
        jumping.Update(Input.GetButton("Jump"));

        var v = rb.velocity;

        if(isGrounded)
        {
            v.x = movement;
            if(jumping.hasBecomeTrue)
            {
                v.y = jumpPower;
                jumpsLeft = jumpCount - 1;
            }
        }
        else
        {
            if(jumpsLeft > 0 && jumping.hasBecomeTrue)
            {
                v.y = jumpPower;
                --jumpsLeft;
            }
            
            v.x += movement * speed * Time.deltaTime;
            v.x = Mathf.Clamp(v.x, -maxAirSpeed, maxAirSpeed);
        }

		//fix stuck
		if(v.y == 0)
			v.y += 0.09f;

        rb.velocity = v;

        if(v.x != 0)
        {
            transform.localScale = new Vector3(v.x >= 0 ? 1 : -1, 1, 1);
        }
	}

    private void PerformGroundedCheck()
    {
        var halfscale = new Vector2(groundedChecker.localScale.x, groundedChecker.localScale.y) / 2;
        var center = new Vector2(groundedChecker.position.x, groundedChecker.position.y);
        var pointA = center - halfscale;
        var pointB = center + halfscale;

        isGrounded = Physics2D.OverlapArea(pointA, pointB, ~LayerMask.GetMask("Player"));
    }
}
