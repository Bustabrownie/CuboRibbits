using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script kills the player.
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
			levelManager.RespawnPlayer();
		}
	}
}
