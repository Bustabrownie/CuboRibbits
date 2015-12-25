using UnityEngine;
using System.Collections;

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

		myRigidBody2D.AddForce(angle * speed);

				//transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

			myRigidBody2D.angularVelocity = rotationSpeed;
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
