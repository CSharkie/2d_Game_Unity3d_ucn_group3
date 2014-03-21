using UnityEngine;
using System.Collections;

public class CarrotAnimator : MonoBehaviour {

	public float speed = 0;
	Vector3 prevPos = Vector3.zero;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		speed = (transform.position - prevPos).magnitude;
		anim.SetFloat ("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		//anim.SetFloat ("speed", speed);
		prevPos = transform.position;
	}
}
