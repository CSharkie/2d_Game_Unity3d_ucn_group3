using UnityEngine;
using System.Collections;

public class TestAI : MonoBehaviour {

	public Transform target;
	[HideInInspector]
	public Vector2 targetLocation;
	[HideInInspector]
	public float walkSpeed = 2.0f;
	[HideInInspector]
	public float runSpeed=4.0f;
	[HideInInspector]
	float walkingDirection = 1.0f;
	[HideInInspector]
	Vector2 walkAmount;
	[HideInInspector]
	Vector2 jumpAmount;
	[HideInInspector]
	float jumpHeight=10.0f;

	private GameObject nextJump;
	private Transform groundCheck;
	private bool grounded = false;

	private Score score;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheckEnemy");
	}

	void Awake()
	{
		score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		var own_x = gameObject.transform.position.x;
		var own_y = gameObject.transform.position.y;
		Vector2 own;
		own.x = own_x;
		own.y = own_y;
		GameObject[] jumps = GameObject.FindGameObjectsWithTag ("Jump");

		bool madeChanges;
		int itemCount = jumps.Length;
		do
		{
			madeChanges = false;
			itemCount--;
			for (int i = 0; i < jumps.Length-1; i++)
			{
				if (jumps[i].transform.position.y>(jumps[i + 1].transform.position.y))
				{
					GameObject temp = jumps[i + 1];
					jumps[i + 1] = jumps[i];
					jumps[i] = temp;
					madeChanges = true;
				}
			}
		} while (madeChanges);

		for (int i=0; i<jumps.Length; i++) {
			if(jumps[i].transform.position.y - 0.3 < own_y && jumps[i].transform.position.y + 0.3 > own_y)
			{
				nextJump=jumps[i+1];
			}
				}

		if (target.transform.position.y > own_y + 0.6) {  //the player is at higher ground

		foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Jump")) {  //lets get the jump objects
			if (fooObj.transform.position.y - 0.3 < own_y && fooObj.transform.position.y + 0.3 > own_y) {  //if we have one on our "level", decide where to go
				if (fooObj.transform.position.x > own_x)
					walkingDirection = 1.0f;
				else      
					walkingDirection = -1.0f;
				//if we are there, time to JUUUUUUMP
				if (fooObj.transform.position.x - 1 < own_x && fooObj.transform.position.x + 1 > own_x) {  //if we are close enough

					if(grounded)
					//rigidbody2D.AddForce (new Vector2 (0f, 180));
					if(nextJump.transform.position.x>own_x)
							walkingDirection=1.0f;
					else
						walkingDirection =-1.0f;
					gameObject.transform.Translate(new Vector2(walkingDirection,1.75f)*Time.deltaTime*62);
					/*
					walkAmount.x = walkingDirection * 23 * Time.deltaTime;
					gameObject.transform.Translate (walkAmount, Space.World);*/
				}
				else{
				walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
				gameObject.transform.Translate (walkAmount, Space.Self);
				}
			}					
		}  //End of foreach

		}
		if (target.transform.position.y < own_y) {    //the player is under me
			if (target.transform.position.x > own_x)
				walkingDirection = 1.0f;
			else      
				walkingDirection = -1.0f;
			walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
			gameObject.transform.Translate (walkAmount, Space.Self);
				}
		if (target.transform.position.y < own_y + 0.3 && target.transform.position.y > own_y - 0.3) {  //if we are at same level
						if (target.transform.position.x > own_x)
								walkingDirection = 1.0f;
						else      
								walkingDirection = -1.0f;

			walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
			gameObject.transform.Translate (walkAmount, Space.Self);

				}
	}

	IEnumerator WaitMethod()
	{
		yield return new WaitForSeconds (1);
	}

}
