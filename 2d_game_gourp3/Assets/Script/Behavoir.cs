			using UnityEngine;
			using System.Collections;

			public class Behavoir : MonoBehaviour {
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
				public int delay;
				GameObject[] enemies=new GameObject[10];
				float speed=500f;
				public int type;
				public GameObject bullet=null;
				public int distance;

				void Start () {
					delay = 5;
					type =1;
					distance = 10;
				}
				

				// Update is called once per frame
				void Update ()
				{
					var own_x = gameObject.transform.position.x;
					var own_y = gameObject.transform.position.y;
					Vector2 own;
					own.x = own_x;
					own.y = own_y;
					switch(type)
					{
						case 0:
			{
				if (target.transform.position.y < own_y + 0.3 && target.transform.position.y > own_y - 0.3) 
				{  //if we are at same level
					if (target.transform.position.x > own_x)
					{
						walkingDirection = 1.0f;
					}
					else      
					{
						walkingDirection = -1.0f;
					}
					walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
					
					if (target.transform.position.x < own_x - distance || target.transform.position.x > own_x + distance)
					{
						gameObject.transform.Translate (walkAmount, Space.Self);
					}
					else
					{
						if (delay == 0)
						{
							GameObject shot = GameObject.Instantiate (bullet, transform.position, transform.rotation) as GameObject;
									if (target.transform.position.x < own_x) 
									{
										shot.rigidbody.AddForce (new Vector3 (-speed, 0, 0));
										delay=50;
									}
									else
									{
										shot.rigidbody.AddForce (new Vector3 (speed, 0, 0));
										delay = 50;
									} 
								}
								else
									delay--;
							}
					}
			break;
		}
							case 1:
							{
								if (target.transform.position.y < own_y + 0.3 && target.transform.position.y > own_y - 0.3) 
								{  //if we are at same level
									if (target.transform.position.x > own_x)
										{
										walkingDirection = 1.0f;
										}
									else      
										{
											walkingDirection = -1.0f;
										}
									walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
									
									if (target.transform.position.x < own_x - distance || target.transform.position.x > own_x + distance)
										{
											gameObject.transform.Translate (walkAmount, Space.Self);
										}
									else
										{
											if (delay == 0)
										{
											if (target.transform.position.x < own_x) 
											{
												this.rigidbody2D.AddForce (new Vector3 (-700f, 0, 0));
												delay =50;
											}
											else
											{
												this.rigidbody2D.AddForce (new Vector3 (700f, 0, 0));
												delay = 50;
											} 
										}
										else
										{
											delay--;
										}
									}
								}
							break;
							}
							case 2:
							{
								enemies= new GameObject[10];
								int count = 0;
								foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy")) {  //lets get the enemy objects
										enemies [count] = fooObj.gameObject;
										count++;
								}
								bool done=false;
								while(!done)
								{
					for(int i=0;i<count;i++)
						for(int j=0;j<count;j++)
					{
					done=true;
					if(enemies[i].transform.position.x<enemies[j].transform.position.x){
						GameObject temp=enemies[i].gameObject;
						enemies[i]=enemies[j];
						enemies[j]=temp;
						done=false;
						}
					}
									}
								if (count++ >= 3) {
									target=enemies[0].transform;
								}
								if (target.transform.position.y < own_y + 0.3 && target.transform.position.y > own_y - 0.3) {  //if we are at same level
									if (target.transform.position.x > own_x)
										walkingDirection = 1.0f;
									else      
										walkingDirection = -1.0f;
									
									walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
									if (target.transform.position.x < own_x || target.transform.position.x > own_x) {
										gameObject.transform.Translate (walkAmount, Space.Self);
									}
							}
						break;
						}
					}
				}
			}