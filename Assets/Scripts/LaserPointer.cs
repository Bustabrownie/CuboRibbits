using UnityEngine;
using System.Collections;

// This script is used by the disco ball
// in the secon level.  This is the laser pointer dot.
public class LaserPointer : MonoBehaviour
{
	public Controller player;

	public GameObject impactEffect;

	public float speed;

	private Transform target;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<Controller>();

		target = player.transform;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.timeScale != 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != "Disco Ball" && other.name != "Enemy")
		{
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
