using UnityEngine;
using System.Collections;

// This script makes the voice play at the end of the level.
public class Voice : MonoBehaviour
{
	private float startTime;

	public AudioClip voiceSound;			// Makes the voice sound!
	private AudioSource voiceAudio;			// Makes the above possible.

	private bool hasPlayed = false;

	void Awake()
	{
		// Initializes the audio.
		voiceAudio = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Time.time - startTime) > 71f)
		{
			if (!hasPlayed)
			{
				voiceAudio.PlayOneShot(voiceSound);
				hasPlayed = true;
			}
		}
	}
}
