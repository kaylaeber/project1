using UnityEngine;
using System.Collections;


public class ShurikenDestroyParticle : MonoBehaviour {
	
	ParticleSystem partSys;


	// Use this for initialization
	void Start () {
		partSys = GetComponent<ParticleSystem>();
		 //audio.PlayOneShot(impact, 0.7F);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!(partSys.IsAlive())) {
    		Destroy(gameObject);
		}
	}
}
