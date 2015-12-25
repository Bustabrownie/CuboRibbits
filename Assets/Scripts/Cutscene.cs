using UnityEngine;
using System.Collections;

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
		if (Input.GetKey(KeyCode.UpArrow) && (Time.realtimeSinceStartup - startTime) > 2f)
		{
			Destroy(GameObject.FindGameObjectWithTag("Music"));
			Application.LoadLevel (nextLevel);
		}
	}
}
