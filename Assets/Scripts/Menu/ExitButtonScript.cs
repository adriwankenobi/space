using UnityEngine;

/*
 * Script for exit button
 */

public class ExitButtonScript : MonoBehaviour {

	#if UNITY_WEBPLAYER || UNITY_EDITOR
	
	void Awake()
	{
		SpaceObjects.Hide(transform);
	}
	
	#endif

	void Update()
	{
		if (InputExtensions.IsObjectClickedDown(gameObject).Input)
		{
			// Exit from app
			Application.Quit();
		}
	}
}
