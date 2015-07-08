using UnityEngine;
using System.Collections;

/*
 * Script for back button
 */

public class BackScript : MonoBehaviour {


	#if UNITY_WEBPLAYER || UNITY_EDITOR

	void OnMouseUpAsButton() {
		LoadMenu ();
	}

	#endif

	#if UNITY_ANDROID

	void Update()
	{
		if (Input.touchCount > 0)
		{
			LoadMenu();
		}
	}
	
	#endif

	private void LoadMenu()
	{
		// Set the time
		Time.timeScale = 1;
		
		// Launch the menu
		Application.LoadLevel(Scenes.MENU);
	}
}
