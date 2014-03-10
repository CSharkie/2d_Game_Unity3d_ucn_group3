using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;
	
	private Player player;
	// Use this for initialization
	void Start () {
		player = transform.root.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			audio.Play();
			
			// If the player is facing right...
			if(player.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				//Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				//bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
