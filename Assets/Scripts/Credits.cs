using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
	public GameObject credits;

	public float speed;

	public string level;
	
	// Update is called once per frame
	void Update()
	{
		credits.transform.Translate (Vector3.up * speed);
	}
}
