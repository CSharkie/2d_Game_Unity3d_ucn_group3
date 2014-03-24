using UnityEngine;
using System.Collections;

public class newGun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed;				// The speed the rocket will fire at.
	public float angle;
	public int delay;
	public int type;
	public float velocity_X=0;
	public float velocity_Y=0;
	private Player player;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	
	
	void Awake()
	{
		// Setting up the references.
		type = 2;
		delay = 0;
		speed = 20f;
		anim = transform.root.gameObject.GetComponent<Animator>();
		player = transform.root.GetComponent<Player>();
	}
	
	public int getGunType()
	{
		return type;
	}
	
	public void setGunType(int type)
	{
		this.type = type;
	}
	
	void Update ()
	{
		
		// If the fire button is pressed...
		if(Input.GetButtonDown("Fire1"))
		{
			switch(type)
			{	
			case 0:
			{// ... set the animator Shoot trigger parameter and play the audioclip.
				Vector3 mouse_pos = Input.mousePosition;
				Vector3 gun_pos = Camera.main.WorldToScreenPoint(this.transform.position);	
				mouse_pos.x = mouse_pos.x - gun_pos.x;
				mouse_pos.y = mouse_pos.y - gun_pos.y;
				angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position,Quaternion.Euler (new Vector3(0, 0, angle))) as Rigidbody2D;
				velocity_X = Mathf.Cos( Mathf.Atan2 (mouse_pos.y, mouse_pos.x))*speed;
				velocity_Y = Mathf.Sin( Mathf.Atan2 (mouse_pos.y, mouse_pos.x))*speed;
				bulletInstance.velocity = new Vector3(velocity_X, velocity_Y, 0);
				break;
			}
			case 1:
			{
				if(delay==0)
				{
					delay=50;
					Vector3 mouse_pos = Input.mousePosition;
					Vector3 gun_pos = Camera.main.WorldToScreenPoint(this.transform.position);
					mouse_pos.x = mouse_pos.x - gun_pos.x;
					mouse_pos.y = mouse_pos.y - gun_pos.y;
					angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
					for(int i=0;i<7;i++)
					{
						Rigidbody2D bulletInstance = Instantiate(rocket, transform.position,Quaternion.Euler (new Vector3(0, 0, angle))) as Rigidbody2D;
						velocity_X = Mathf.Cos(Mathf.Atan2 (mouse_pos.y, mouse_pos.x)-((i-4)*0.05f))*10f;
						velocity_Y = Mathf.Sin(Mathf.Atan2 (mouse_pos.y, mouse_pos.x)-((i-4)*0.05f))*10f;
						bulletInstance.velocity = new Vector3(velocity_X, velocity_Y, 0);
						//M
					}
				}
				break;
			}
			case 2:
			{
				Vector3 mouse_pos = Input.mousePosition;
				Vector3 gun_pos = Camera.main.WorldToScreenPoint(this.transform.position);	
				mouse_pos.x = mouse_pos.x - gun_pos.x;
				mouse_pos.y = mouse_pos.y - gun_pos.y;
				angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position,Quaternion.Euler (new Vector3(0, 0, angle))) as Rigidbody2D;
				velocity_X = Mathf.Cos( Mathf.Atan2 (mouse_pos.y, mouse_pos.x))*15;
				velocity_Y = Mathf.Sin( Mathf.Atan2 (mouse_pos.y, mouse_pos.x))*15;
				bulletInstance.velocity = new Vector3(velocity_X, velocity_Y, 0);
				Rigidbody2D bulletInstance2 = Instantiate(rocket, transform.position,Quaternion.Euler (new Vector3(0, 0, 180f-angle))) as Rigidbody2D;
				bulletInstance2.velocity = new Vector3(-velocity_X, velocity_Y, 0);
				break;
			}
			}
		}
		if(delay>0)
			delay--;
	}
}
