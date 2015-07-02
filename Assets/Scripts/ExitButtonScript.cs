using UnityEngine;

/// <summary>
/// Script for exit button
/// </summary>

public class ExitButtonScript : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnMouseUpAsButton() {
		// Exit from app
		Application.Quit();
	}

}
