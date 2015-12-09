using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the switching levels.
public class LevelLoader : MonoBehaviour
{

	private bool playerInZone;

	public string levelToLoad;

	// Use this for initialization
	void Start()
	{
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		// When the player is in the zone and
		// press the up arrow key, the will
		// be taken to a new level.
		if(Input.GetKeyDown(KeyCode.UpArrow) && playerInZone)
		{
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


}
