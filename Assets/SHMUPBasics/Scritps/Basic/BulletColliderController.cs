using UnityEngine;
using System.Collections;

public class BulletColliderController : MonoBehaviour {
	
	public GameObject bulletExplodePaticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnCollisionEnter (Collision collision) {
		Instantiate(bulletExplodePaticle, transform.position, bulletExplodePaticle.transform.rotation);
		Destroy(gameObject);
	}
}
