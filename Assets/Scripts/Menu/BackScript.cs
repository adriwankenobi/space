using UnityEngine;
using System.Collections;

/// <summary>
/// Script for back button
/// </summary>

public class BackScript : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnMouseUpAsButton() {
		// Set the time
		Time.timeScale = 1;

		// Launch the menu
		Application.LoadLevel("Menu");
	}

	public void destroy() {
		Destroy(gameObject);
	}
}
