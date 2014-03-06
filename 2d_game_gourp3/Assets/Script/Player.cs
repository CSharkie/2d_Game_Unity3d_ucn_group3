using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 10f;
	public bool jump = false;
	public bool facingRight = true;

	private bool grounded = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}

	void FixedUpdate()
	{
		float hrizontal = Input.GetAxis ("Horizontal");

		if (hrizontal * rigidbody2D.velocity.x < maxSpeed)
						rigidbody2D.AddForce (Vector2.right * hrizontal * moveForce);
		if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		if (hrizontal > 0 && !facingRight)
						Flip ();
				else if (hrizontal < 0 && facingRight)
						Flip ();
		if (jump) 
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));

			jump = false;
		}
	}

	void Flip()
	{

	}
}
