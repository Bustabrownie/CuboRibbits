using UnityEngine;
using System.Collections;

// A script that makes it so the particles do not get
// stuck behind the background.
public class ForegroundParticles : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
