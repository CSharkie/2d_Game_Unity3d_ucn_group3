using UnityEngine;
using System.Collections;

public class gunFireAnimator : MonoBehaviour {
	Animator gunAnim;
	bool fire = false;
	// Use this for initialization
	void Start () {
		gunAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
						fire = true;
		} else { fire = false; 
				}
			gunAnim.SetBool ("shoot", fire);
	}
}
