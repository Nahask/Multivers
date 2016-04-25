using UnityEngine;
using System.Collections;

public class mouvement_character : MonoBehaviour {
	public float maxSpeed = 10f;
	public bool facingRight = true;

	bool grounded = false;
	public Transform groundCheck;
	float groudRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	bool doubleJump = false;

	Animator anim;

	
	private GameObject fire_pow;

	void Start () {

		anim = GetComponent<Animator> ();
	}
		void FixedUpdate () {
	
		grounded = Physics2D.OverlapCircle (groundCheck.position, groudRadius, whatIsGround);

		if (grounded)
			doubleJump = false;

			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat("Speed", Mathf.Abs (move));
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		}
		else if (move < 0 && facingRight)
		{
				Flip();
		}
		}

	void Update()
	{
		if ((grounded || !doubleJump)  && Input.GetButtonDown("Jump")) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			if (!doubleJump && !grounded)
			{
				doubleJump = true;
			}
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
