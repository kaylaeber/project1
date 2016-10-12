using UnityEngine;
using System.Collections;

public class BugController : MonoBehaviour {

	public float bugSpeed = 1f;
	public float bugRotation = 20f;

	public GameSystem gameSystem;

	public GameObject somePrefab;

	// Use this for initialization
	void Start () {
		GameObject tempGameObject = GameObject.Find ("GameSystemManager");
		gameSystem = tempGameObject.GetComponent (typeof(GameSystem)) as GameSystem;
		RandomHSB randomHSB = gameSystem.gameObject.GetComponent<RandomHSB> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * bugSpeed);

		// Rotate the object around its local X axis at 1 degree per second
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);

		Debug.Log("TRIGGER WORKING");
		if(other.gameObject.tag == "bull")
		{
			Debug.Log ("BUG HIT");
			if (gameSystem != null) {
				gameSystem.HitByBullet ();
			}

			Destroy(gameObject);			
		}


	}
}
