using UnityEngine;

/*
 * Script for exit button
 */

public class ExitButtonScript : MonoBehaviour {

	#if UNITY_WEBPLAYER || UNITY_EDITOR
	
	void Awake()
	{
		Destroy(gameObject);
	}
	
	#endif

	void Update()
	{
		if (InputExtensions.IsObjectClickedDown(gameObject))
		{
			// Exit from app
			Application.Quit();
		}
	}
}
