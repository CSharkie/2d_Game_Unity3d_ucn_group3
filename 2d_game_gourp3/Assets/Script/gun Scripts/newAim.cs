using UnityEngine;  
using System.Collections;

public class newAim : MonoBehaviour {
	public float angle=0;
	private newPlayer player;
	private bool fliped=false;
	void Start () {
		
		player = transform.root.GetComponent<newPlayer>();
	}
	
	void Update () 
	{
		Vector3 mouse_pos = Input.mousePosition;
		Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
		
		mouse_pos.x = mouse_pos.x - player_pos.x;
		mouse_pos.y = mouse_pos.y - player_pos.y;
		
		angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		if (mouse_pos.x > 0 && player.facingRight == false)
		{
			// ... flip the player.
			player.Flip ();
			fliped=true;
		}
		else if(mouse_pos.x < 0 && player.facingRight==true)
			
		{// ... flip the player.
			player.Flip();
			fliped=true;
		}
		if (mouse_pos.x>0 && !fliped) 
		{
			if (angle < 90 && angle > -90)
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		}
		else if(mouse_pos.x<0 && !fliped)
		{
			if (angle > 90 || angle < -90)
				this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -angle));
		}
		else if(fliped)
		{
			Flip();
		}
		fliped = false;
	}
	
	public void Flip ()
	{
		// Multiply the guns's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}