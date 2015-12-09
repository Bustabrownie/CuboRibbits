using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script handles the "checkpoints."
public class Checkpoint : MonoBehaviour
{

	public LevelManager levelManager;
	
	// Use this for initialization
	void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			levelManager.currentCheckpoint = gameObject;
		}
	}
}
