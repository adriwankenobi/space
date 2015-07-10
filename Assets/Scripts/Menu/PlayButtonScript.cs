using UnityEngine;

/*
 * Script for play button
 */

public class PlayButtonScript : MonoBehaviour {

	#if UNITY_WEBPLAYER || UNITY_EDITOR
	
	void OnMouseDown()
	{
		LoadLevel();
	}

	#endif

	#if UNITY_ANDROID

	void Update()
	{
		MobileExtensions.WhenTouched(gameObject, () => {LoadLevel();});
	}
	
	#endif

	private void LoadLevel()
	{
		// Load the level
		Application.LoadLevel(Scenes.LEVEL);
	}
}
