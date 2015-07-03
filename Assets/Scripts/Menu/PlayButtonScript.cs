using UnityEngine;

/// <summary>
/// Script for play button
/// </summary>

public class PlayButtonScript : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	// When clicked
	void OnMouseUpAsButton() {   

		// Load the level
		Application.LoadLevel("Level");
	}
}
