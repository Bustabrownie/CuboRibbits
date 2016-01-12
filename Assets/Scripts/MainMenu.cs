using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// A script written by gamesplusjames.
// This script handles where the main menu
// buttons will lead to.
public class MainMenu : MonoBehaviour
{
	public string startLevel;

	public string levelSelect;

	public string credits;

	public Slider slider;

	public static int levels = 4;

	private int levelIndex;

	public void NewGame()
	{
		PlayerPrefs.DeleteAll();
		LockLevels();
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(startLevel);
	}

	public void LevelSelect()
	{
		LockLevels();
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(levelSelect);
	}

	public void Credits()
	{
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.LoadLevel(credits);
	}

	public void QuitGame()
	{
		Destroy(GameObject.FindGameObjectWithTag("Music"));
		Application.Quit();
	}
				
	public void VolumeControl(float volumeControl)
	{
		AudioListener.volume = volumeControl;			
	}

	void Start()
	{
		slider.value = AudioListener.volume;
	}

	void LockLevels()
	{
		for (int i = 1; i < levels; i++)
		{
			levelIndex = (i + 1);
								
			if (!PlayerPrefs.HasKey ("Level " + levelIndex.ToString()))
			{
				PlayerPrefs.SetInt("Level " + levelIndex.ToString (),0);
			}
		}
	}
}