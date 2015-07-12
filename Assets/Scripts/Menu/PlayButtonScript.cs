using UnityEngine;

/*
 * Script for play button
 */

public class PlayButtonScript : MonoBehaviour {

	void Update()
	{
		if (InputExtensions.IsObjectClickedDown(gameObject).Input)
		{
			// Load the level
			Application.LoadLevel(Scenes.LEVEL);
		}
	}
}
