using UnityEngine;
using System.Collections;

public class CarrotAnimator : MonoBehaviour {

	public float speed = 0;
	public bool fall = false;
	Vector3 prevPos = Vector3.zero;
	Animator anim;
	Animation gunAnim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gunAnim ["gunFireAnim"].wrapMode = WrapMode.Once;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (Input.GetButtonDown ("Fire1")) {
			gunAnim.Play ("gunFireAnim");
				}
		anim.SetFloat ("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		//anim.SetFloat ("speed", speed);

		//if (prevPos > transform.position.y) {
		//	fall = true;
		//} else
		//	fall = false;
		
		anim.SetBool ("falling", fall);
		// TODO Fix the compile error :)
		// prevPos = transform.position.y;


	}
}
