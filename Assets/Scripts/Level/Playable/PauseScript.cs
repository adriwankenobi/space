using UnityEngine;

/// <summary>
/// Script for pause button
/// </summary>

public class PauseScript : MonoBehaviour {

	public bool isPaused = false;
	public Transform backButton;
	private BackScript backtButtonScript;

	private AudioSource[] allAudioSources;

	void Awake()
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
	}

	void Start ()
	{

	}

	void Update ()
	{

		// When Escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;

			// Pause or UnPause the audio
			SetAllAudio();

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

	void OnGUI()
	{

	}

	private void SetAllAudio() {
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
