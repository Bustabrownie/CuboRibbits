using UnityEngine;
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

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
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
		player.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(respawnDelay);

		Application.LoadLevel(Application.loadedLevel); 
		
		// Commented out code. May use later?
		//player.transform.position = currentCheckpoint.transform.position;
		//player.enabled = true;
		//player.GetComponent<Renderer>().enabled = true;
		//Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
