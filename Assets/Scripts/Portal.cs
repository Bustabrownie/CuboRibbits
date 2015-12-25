using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script originally was meant to kill
// the player, however, I figured I may use
// it for portals.
public class Portal : MonoBehaviour
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
