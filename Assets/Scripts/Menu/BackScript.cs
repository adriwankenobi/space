using UnityEngine;
using System.Collections;

/*
 * Script for back button
 */

public class BackScript : MonoBehaviour {

	void Update()
	{
		if (InputExtensions.IsObjectClickedDown(gameObject).Input)
		{
			// Set the time
			Time.timeScale = 1;
			
			// Launch the menu
			Application.LoadLevel(Scenes.MENU);
		}
	}
}
