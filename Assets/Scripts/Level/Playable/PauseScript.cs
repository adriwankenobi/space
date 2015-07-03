using UnityEngine;

/// <summary>
/// Script for pause button
/// </summary>

public class PauseScript : MonoBehaviour {

	public bool isPaused = false;
	public Transform backButton;

	private BackScript backtButtonScript;
	
	void Start () {

	}

	void Update () {

		// When Escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;

			// Check if is paused
			if (isPaused) {

				// Stops the time
				Time.timeScale = 0;

				// Stops the sounds
				GetComponent<AudioSource>().Pause();

				// Create backButton object in the center of the camera
				var backButtonTransform = Instantiate(backButton) as Transform;
				backButtonTransform.position = new Vector3(
						Camera.main.transform.position.x,
						Camera.main.transform.position.y,
						transform.position.z
				);

				// Get the script from the button
				backtButtonScript = backButtonTransform.gameObject.GetComponent<BackScript>();

			} else {

				// Sets the time
				Time.timeScale = 1;

				// Continue the sounds
				GetComponent<AudioSource>().Play();

				// Destroy the backButton object
				backtButtonScript.destroy();
			}
		}
	}

	void OnGUI() {

	}

}
