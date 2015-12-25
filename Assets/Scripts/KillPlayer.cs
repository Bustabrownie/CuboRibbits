using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the player being killed.
public class KillPlayer : MonoBehaviour
{

	public LevelManager levelManager;

	void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			Application.LoadLevel(Application.loadedLevel);
			
			// Commented out code.  May use later?
			//levelManager.RespawnPlayer();
		}
	}
}
