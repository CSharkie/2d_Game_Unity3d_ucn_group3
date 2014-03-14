using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int score = 0;
	private Player player;
	private int previousScore = 0;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}

	void Update () {

		//guiText.text = "Score: " + score;
		if(previousScore != score)
		previousScore = score;
	}

	// This will be probably the part for the faster spawn of mobs
	void FixedUpdate()
	{
		if (score != 0 && score % 1000 == 0) 
		{
			// increase the spawn and number of mobs
			// method will be implemented here :)
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (Screen.width-120,72,100,30), "Score: " + score);
	}
}
