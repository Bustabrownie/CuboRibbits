using UnityEngine;
using System.Collections;

// This is the cutscene, and how to continue through one.
public class Cutscene : MonoBehaviour
{
	public string nextLevel;

	private float startTime;

	// Use this for initialization
	void Start()
	{
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update()
	{
		if ((Input.GetAxisRaw("Vertical") > 0.8 || Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire3")) && (Time.realtimeSinceStartup - startTime) > 2f)
		{
			Destroy(GameObject.FindGameObjectWithTag("Music"));
			Application.LoadLevel (nextLevel);
		}
	}
}
