using UnityEngine;
using System.Collections;

// This script is the banana.  It is a projectile.
public class Projectile : MonoBehaviour
{
	public Controller player;

	public GameObject impactEffect;

	private Rigidbody2D myRigidBody2D;

	public float speed;

	public float rotationSpeed;

	private Transform target;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<Controller>();
	
		myRigidBody2D = GetComponent<Rigidbody2D>();

				target = player.transform;

		if (player.transform.position.x < transform.position.x)
		{
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 angle = (target.position - transform.position).normalized;

		if (Time.timeScale != 0)
		{
			myRigidBody2D.AddForce(angle * speed);
			myRigidBody2D.angularVelocity = rotationSpeed;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name != "Enemy")
		{
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
