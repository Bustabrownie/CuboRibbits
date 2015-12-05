using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;

	public string levelToLoad;

	//public GameObject music;


	GameObject[] music;

	void DestroyMusic()
	{
		music = GameObject.FindGameObjectsWithTag ("Music");
		
		for(var i=0; i<music.Length; i++)
		{
			Destroy(music[i]);
		}
	}


	// Use this for initialization
	void Start ()
	{
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && playerInZone)
		{
			DestroyMusic();
			Application.LoadLevel(levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			playerInZone = false;
		}
	}


}
