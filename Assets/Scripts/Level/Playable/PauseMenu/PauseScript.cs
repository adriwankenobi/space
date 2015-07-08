using UnityEngine;

/*
 * Script for pause button
 */

public class PauseScript : MonoBehaviour {

	public Transform backButton;

	public bool isPaused = false;
	private Transform currentBackButton;

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
				currentBackButton = Instantiate(backButton) as Transform;
				backButton.position = new Vector3(
						Camera.main.transform.position.x,
						Camera.main.transform.position.y,
						transform.position.z
				);

			} else {

				// Sets the time
				Time.timeScale = 1;

				// Destroy the backButton object
				if (currentBackButton != null)
				{
					Destroy(currentBackButton.gameObject);
				}
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
