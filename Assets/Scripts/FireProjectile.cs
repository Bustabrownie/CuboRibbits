using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour
{
	public GameObject projectile;

	public Controller player;

	public Transform launchPoint;

	private float shotCounter;

	public float fireDelay;

	private float startTime;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;

		player = FindObjectOfType<Controller>();

		shotCounter = 0.1f;
	}
	
	// Update is called once per frame
	void Update()
	{
		if ((Time.time - startTime) > 20f)
		{
			fireDelay = 2f;
		}

		if ((Time.time - startTime) > 40f)
		{
			fireDelay = 1.66f;
		}

		if ((Time.time - startTime) > 60f)
		{
			fireDelay = 1.33f;
		}
		shotCounter -= Time.deltaTime;

		if (player.transform.position.x > transform.position.x && shotCounter < 0 && (Time.time - startTime) < 70f)
		{
			Instantiate(projectile, launchPoint.position, launchPoint.rotation);
			shotCounter = fireDelay;
		}

		if (player.transform.position.x < transform.position.x && shotCounter < 0 && (Time.time - startTime) < 70f)
		{
			Instantiate(projectile, launchPoint.position, launchPoint.rotation);
			shotCounter = fireDelay;
		}
	}
}
