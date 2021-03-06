﻿using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the respawning.
public class LevelManager : MonoBehaviour
{
	public GameObject currentCheckpoint;

	private Controller player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;		// The amount of time it takes to respawn.

	void Start()
	{
		player = FindObjectOfType<Controller>();
	}
		
	public void RespawnPlayer()
	{
		StartCoroutine("RespawnPlayerCo");
	}
	
	// This function respawns the player.
	// It also shows the death particles.
	public IEnumerator RespawnPlayerCo()
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = false;
		yield return new WaitForSeconds(respawnDelay);

		Application.LoadLevel(Application.loadedLevel);
	}
}
