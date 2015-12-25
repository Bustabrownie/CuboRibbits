using UnityEngine;
using System.Collections;

// A script that makes it so the particles do not get
// stuck behind the background.
public class ForegroundParticles : MonoBehaviour
{
	void Start()
	{
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Character";
	}
}
