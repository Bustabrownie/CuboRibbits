using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the switching levels.
public class LevelLoader : MonoBehaviour
{
	private bool playerInZone;

	public string levelToLoad;

	protected string currentLevel;

	// Use this for initialization
	void Start()
	{
		currentLevel = Application.loadedLevelName;

		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		// When the player is in the zone and
		// press the up arrow key, the will
		// be taken to a new level.
		if((Input.GetAxisRaw("Vertical") > 0.8 || Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Submit")) && playerInZone && !GetComponent<CircleCollider2D>().enabled)
		{
			UnlockLevels();
			Destroy(GameObject.FindGameObjectWithTag("Music"));
			Application.LoadLevel(levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			playerInZone = false;
		}
	}

	protected void UnlockLevels()
	{
		for(int i=1; i<MainMenu.levels; i++)
		{
			if(currentLevel == "Level " + i.ToString())
			{
				PlayerPrefs.SetInt ("Level " + (i + 1).ToString(),1);
			}
		}
	}
				
}
