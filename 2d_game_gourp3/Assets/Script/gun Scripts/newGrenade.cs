﻿using UnityEngine;
using System.Collections;

public class newGrenade : MonoBehaviour 
{
	public bool asda;
	public int type;
	void Start () 
	{
		type = 0;
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 1);
	}
	
	
//	void OnExplode()
//	{
//		// Create a quaternion with a random rotation in the z-axis.
//		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
//		
//		// Instantiate the explosion where the rocket is with the random rotation.
//		Instantiate(explosion, transform.position, randomRotation);
//	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			if(type==0)
			{
				//col.gameObject.GetComponent<Enemy>().impale(rigidbody2D.velocity);
				//col.gameObject.GetComponent<Enemy>().Hurt();
				//OnExplode();
				Destroy (gameObject);
			}
			else
			{
				// ... find the Enemy script and call the Hurt function.
				//col.gameObject.GetComponent<Enemy>().Hurt();
				// Call the explosion instantiation.
				//OnExplode();
				// Destroy the rocket.
				Destroy (gameObject);
			}
		}
		// Otherwise if it hits a bomb crate...
		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag != "Player" && col.tag!="Bullet")
		{
			//Instantiate the explosion and destroy the rocket.
			//OnExplode();
			Destroy (gameObject);
		}
	}
}
