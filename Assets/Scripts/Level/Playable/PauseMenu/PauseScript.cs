using UnityEngine;

/*
 * Script for pause button
 */

public class PauseScript : MonoBehaviour {

	public Transform backButton;

	public bool isPaused = false;
	private BackScript backtButtonScript;

	private AudioSource[] allAudioSources;

	void Awake()
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
	}

	void Update ()
	{

		// When Escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;

			// Pause or UnPause the audio
			ChangeStatusAudio();

			// Check if is paused
			if (isPaused) {

				// Stops the time
				Time.timeScale = 0;

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

				// Destroy the backButton object
				backtButtonScript.destroy();
			}
		}
	}

	private void ChangeStatusAudio() {
		for(var i=0; i < allAudioSources.Length; i++)
		{
			if (isPaused)
			{
				allAudioSources[i].Pause();
			}
			else
			{
				allAudioSources[i].UnPause();
			}
		}
	}

}
