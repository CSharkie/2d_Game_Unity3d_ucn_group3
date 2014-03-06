using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;
	public float hurtForce = 10f;
	public float damageAmount = 10f;

	private Player playCtr;

	void Awake() {
		playCtr = GetComponent<Player> ();
	}

	void OncollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			if (health  > 0f) {
				TakeDamage(col.transform);
			}
			else {

				GetComponent<Player>().enabled = false;
				Destroy(gameObject);
			}
			
		}
	}

	void TakeDamage (Transform enemy) {
		playCtr.jump = false;
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;
		rigidbody2D.AddForce (hurtForce * hurtVector);
		health -= damageAmount;
		UpdateHealthInfo ();

	}

	public void UpdateHealthInfo () {

	}

	void OnGUI() {
		GUI.Box (new Rect (1200,40,100,30), "Health: " + health);
	}

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
