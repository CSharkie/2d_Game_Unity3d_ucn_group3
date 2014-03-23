using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () 
	{
		GUILayout.BeginArea (new Rect (Screen.width/2-150, Screen.height/2-50, 300, 400));
		GUILayout.Label ("Game Paused !");
		if( GUILayout.Button ("Resume"))
			Destroy(this);
		if (GUILayout.Button ("Exit"))
			Application.Quit();
		
		GUILayout.EndArea ();
	}
}
