using UnityEngine;
using System.Collections;

// This is the falling rocks in the fourth level.
public class FallingRock : MonoBehaviour
{
	public float speed;

	private float startTime;

	void Start()
	{
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		// Increase falling speed over time.
		if ((Time.time - startTime) > 20f)
		{
			speed = 3f;
		}

		if ((Time.time - startTime) > 40f)
		{
			speed = 4f;
		}

		if ((Time.time - startTime) > 60f)
		{
			speed = 5f;
		}

		if ((Time.time - startTime) > 71f)
		{
			Destroy(gameObject);
		}

		transform.position -= transform.up * Time.deltaTime * speed;
	}
}
