using UnityEngine;
using System.Collections;

// This gets rid of the lava at about 70 seconds.
public class DestroyLava : MonoBehaviour
{
	private float startTime;

	public float endTime;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Time.time - startTime) > endTime)
		{
			Destroy(gameObject);
		}
	}
}
