using UnityEngine;

/*
 * Script for play button
 */

public class PlayButtonScript : MonoBehaviour {

	#if UNITY_WEBPLAYER || UNITY_EDITOR
	
	void OnMouseUpAsButton()
	{
		LoadLevel();
	}

	#endif

	#if UNITY_ANDROID

	void Update()
	{
		if (Input.touchCount > 0)
		{
			LoadLevel();
		}
	}
	
	#endif

	private void LoadLevel()
	{
		// Load the level
		Application.LoadLevel(Scenes.LEVEL);
	}
}
