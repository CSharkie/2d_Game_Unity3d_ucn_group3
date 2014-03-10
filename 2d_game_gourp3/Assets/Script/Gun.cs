using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;
	
	private Player player;

	void Start () {
		player = transform.root.GetComponent<Player> ();
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			audio.Play();
			if(player.facingRight)
			{
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
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
