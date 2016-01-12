using UnityEngine;
using System.Collections;

// This script is used by the disco ball
// in the secon level.  This fires a laser pointer dot
// in a homing trajectory.
public class FireLaserPointer : MonoBehaviour
{
	public GameObject projectile;

	public Controller player;

	public Transform launchPoint;

	private float startTime;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;

		player = FindObjectOfType<Controller>();
	}

	// Update is called once per frame
	void Update()
	{
		if (player.transform.position.y > 1.5f && (Time.time - startTime) < 70f && GameObject.FindGameObjectWithTag("Laser Pointer") == null)
		{
			Instantiate(projectile, launchPoint.position, launchPoint.rotation);
		}
	}
}
