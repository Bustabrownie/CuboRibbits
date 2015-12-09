using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles where the main menu
// buttons will lead to.
public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string levelSelect;

	public void NewGame()
	{
		Application.LoadLevel(startLevel);
	}

	public void LevelSelect()
	{
		Application.LoadLevel(levelSelect);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}