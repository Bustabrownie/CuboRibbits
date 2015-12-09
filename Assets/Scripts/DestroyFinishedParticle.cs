using UnityEngine;
using System.Collections;

// A script written by gamesplusjames.
// This script makes sure that when particles are done
// doing their thing, they get deleted.
public class DestroyFinishedParticle : MonoBehaviour
{

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start ()
	{
		thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(thisParticleSystem.isPlaying)
		{
			return;
		}
		Destroy(gameObject);
	}
}
