using UnityEngine;
using System.Collections;

// A script for the fourth Boss, Patty Drake.
// This allows Patty's claws to gradually change color and do damage.
public class BossFour : MonoBehaviour
{
	public Color startColor;

	public Color endColor;

	public float speed = 10f;		// The speed in which the colors change.

	private float startTime;

	void Start()
	{
		startTime = Time.time;
	}

	void Update()
	{
		if ((Time.time - startTime) > 20f)
		{
			speed = 10f;
		}

		// Speed increases at 40 seconds.
		if ((Time.time - startTime) > 40f)
		{
			speed = 5f;
		}

		if ((Time.time - startTime) > 60f)
		{
			speed = 5f;
		}

		// The color goes to normal at 71 seconds.
		if ((Time.time - startTime) > 71f)
		{
			GetComponentInChildren<SpriteRenderer>().color = Color.white;
		}

		// The color gradually changes from normal to red.
		if((Time.time - startTime) < 71f)
		{
			GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(startColor, endColor, Mathf.SmoothStep(0f,1f,Mathf.PingPong((Time.time - startTime) / speed, 1f)) );
		}
	
		// When the color is red, it will kill the player if he touches it.
		if (GetComponentInChildren<SpriteRenderer>().color.g < 0.2f)
		{
			GetComponent<BoxCollider2D>().isTrigger = enabled;
		}
		else
		{
			GetComponent<BoxCollider2D>().isTrigger = !enabled;
		}
	}
}