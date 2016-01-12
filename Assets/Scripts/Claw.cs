using UnityEngine;
using System.Collections;

// This script makes it so the claws do not hurt the player
// after 71 seconds.
public class Claw : MonoBehaviour
{
	private float startTime;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Time.time - startTime) > 71f)
		{
			GetComponent<BoxCollider2D>().isTrigger = false;
		}
	}
}
