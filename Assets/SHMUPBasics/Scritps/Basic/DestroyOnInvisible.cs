using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour
{
	public bool destroySelf = true;
	public GameObject[] destroyObjects;
	public GameObject explosion;
	
	void OnBecameInvisible()
	{
		//Debug.Log("NOT VISABLE");
		if(destroySelf)
		{
			Destroy(transform.parent.gameObject);
			Destroy(gameObject);
		}
		foreach(GameObject obj in destroyObjects)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy(obj);
		}
	}
}
