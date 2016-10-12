using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour
{
	public bool destroySelf = true;
	public GameObject[] destroyObjects;
	
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
			Destroy(obj);
		}
	}
}
