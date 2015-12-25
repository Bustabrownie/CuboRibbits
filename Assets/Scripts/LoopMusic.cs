using UnityEngine;
using System.Collections;

// A script to make sure that the music
// does not get destroyed when restarting
// a level, and it does not duplicate.
public class LoopMusic : MonoBehaviour
{

	private static LoopMusic instance = null;
	public static LoopMusic Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		if( instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

}