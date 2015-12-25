using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// A script written by gamesplusjames.
// This script handles where the pause menu
// buttons will lead to.
public class PauseMenu : MonoBehaviour
{
	public string levelSelect;

	public string mainMenu;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	public Controller player;

	public Slider slider;


	// Update is called once per frame
	void Update()
	{
		if(isPaused)
		{
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
			player.enabled = false;
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 0.1f;
			GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().enabled = false;

		}
		else
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
			player.enabled = true;
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 1f;
			GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().enabled = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void LevelSelect()
	{
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(levelSelect);
	}

	public void Quit()
	{
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(mainMenu);
	}

	public void VolumeControl(float volumeControl)
	{
		AudioListener.volume = volumeControl;			
	}

	void Start()
	{
		slider.value = AudioListener.volume;
	}
}
