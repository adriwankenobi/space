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

	#if UNITY_ANDROID

	void Update()
	{
		MobileExtensions.WhenTouched(gameObject, () => {Exit();});
	}
	
	#endif
	
	private void Exit()
	{
		// Exit from app
		Application.Quit();
	}

}
