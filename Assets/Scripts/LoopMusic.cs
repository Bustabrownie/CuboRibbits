using UnityEngine;
using System.Collections;

public class LoopMusic : MonoBehaviour {

	public GameObject music;

	private static LoopMusic instance = null;
	public static LoopMusic Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		//if(this.gameObject != music)
		//{
		//	Destroy (this);
		//}

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


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	//void Awake()
	//{
	//
	//	if(Instance)
	//	{
	//		DestroyImmediate(music);
	//	}
	//	else
	//	{
	//		DontDestroyOnLoad(music);
	//		instance = this;
	//	}
	//}



}