﻿using UnityEngine;
using System.Collections;

public class rotateBug : MonoBehaviour {

	public float bugRotation = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(Vector3.right * Time.deltaTime * bugRotation);
	
	}
}
