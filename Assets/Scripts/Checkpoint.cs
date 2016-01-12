using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the "checkpoints."
public class Checkpoint : MonoBehaviour
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
			levelManager.currentCheckpoint = gameObject;
		}
	}
}
