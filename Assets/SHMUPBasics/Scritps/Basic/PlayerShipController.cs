using UnityEngine;
using System.Collections;

public class PlayerShipController : MonoBehaviour {

	public  ParticleEmitter thrustEmitter;

	public float palyerSpeed;

	// Use this for initialization
	void Start () {
		thrustEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();

		//transform.Translate(Vector3.back * Time.deltaTime * palyerSpeed, Space.World);
		//transform.Rotate (new Vector3 (1.0f, 0, 0));
		// Rotate the object around its local X axis at 1 degree per second
	
	}

	// SCRIP API //

	void MovePlayer()
	{
		bool thrustButtonPress = false;

		transform.Translate(Vector3.right * (Input.GetAxis("Horizontal") * palyerSpeed));
		transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * palyerSpeed));

		if(Input.GetAxis("Horizontal") != 0.0f ) 
		{
			thrustButtonPress = true;
		}

		if(Input.GetAxis("Vertical") != 0.0f ) 
		{
			thrustButtonPress = true;
		}


		if(thrustButtonPress) 
		{
			thrustEmitter.emit = true;
			GetComponent<AudioSource>().enabled = true;
		}
		else
		{
			thrustEmitter.emit = false;
			GetComponent<AudioSource>().enabled = false;
		}


	}
}
