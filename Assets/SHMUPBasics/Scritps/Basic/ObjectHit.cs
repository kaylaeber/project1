using UnityEngine;
using System.Collections;

public class ObjectHit : MonoBehaviour {


	public GameSystem gameSystem;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {


		if(collision.gameObject.tag == "Bullet")
		{
			if(gameSystem != null)
			{
				gameSystem.HitByBullet();
				Instantiate (explosion, transform.position, transform.rotation);
			}
		}
		
	}
}
