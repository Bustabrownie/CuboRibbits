using UnityEngine;
using System.Collections;

public class SpawnLevelLoader : MonoBehaviour {

	private float startTime;

	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		if ((Time.time - startTime) > 70f)
		{
			GetComponent<BoxCollider2D>().enabled = true;
			GetComponentInChildren<SpriteRenderer>().enabled = true;
		}
	}
}
