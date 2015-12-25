using UnityEngine;
using System.Collections;

public class UnlockLevel : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		for (int i = 1; i < MainMenu.levels; i++)
		{
			if((PlayerPrefs.GetInt("Level " + (i + 1).ToString())) == 1)
			{
				GameObject.Find("LockedLevel" + (i + 1)).GetComponentInParent<CircleCollider2D>().enabled = false;
				GameObject.Find("LockedLevel" + (i + 1)).active = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
