using UnityEngine;
using System.Collections;

public class BulletShootController : MonoBehaviour {

	
	public Transform shipObject;
	
	public Rigidbody bullet;
	public float velocity = 50.0f;
	
	public float reloadTime = 0.5f; 
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		shipObject = transform.root;
	}
	
	// Update is called once per frame
	void Update () {

		bool shootButtonPress = false;

		if (Input.GetKeyDown("space"))
		{
			shootButtonPress = true;
		}
		shootWeapon(shootButtonPress);
	}


	// SCRIPT API //

	void shootWeapon (bool shoot) {
		timer += Time.deltaTime;
		if(shoot && timer > reloadTime)
		{
			Rigidbody shipBody = shipObject.GetComponent<Rigidbody>();
			Vector3 shipVelocity = shipBody.velocity;
			//Debug.Log("SHOOTING");

			GetComponent<AudioSource>().Play();

			Rigidbody newBullet = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody;

			newBullet.AddForce((transform.forward * velocity + shipVelocity),ForceMode.VelocityChange);

			timer = 0.0f;
			
		}
	}
}
