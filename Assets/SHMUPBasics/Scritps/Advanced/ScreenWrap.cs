using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {
	
	public Vector2 wrap;
	public Vector2 wrapMax;
	public Vector2 nudgeMin;
	public Vector2 nudgeMax;
	
	public bool nudgeIfHidden;
	public float screenBufferSize;
	public float nudgeBufferSize;
	public float nudgeStrength;
	public float nudgeThreshold;
	
	// Use this for initialization
	void Awake () {
		
	}
	
	void Start () {
		Vector3 screenMin = Camera.main.ScreenToWorldPoint( new Vector3(0, 0, Camera.main.transform.position.y));
		wrap = new Vector2(screenMin.x-screenBufferSize, screenMin.z-screenBufferSize);
		nudgeMin = new Vector2(screenMin.x+nudgeBufferSize, screenMin.z+nudgeBufferSize );
		
		Vector3 screenMax = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
		wrapMax = new Vector2(screenMax.x+screenBufferSize, screenMax.z+screenBufferSize);
		nudgeMax = new Vector2(screenMax.x+nudgeBufferSize, screenMax.z+nudgeBufferSize );
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > nudgeMax.x || transform.position.z > nudgeMax.y || transform.position.x < nudgeMin.x || transform.position.z < nudgeMin.y )
		{
			// Debug.Log(rigidbody.velocity.magnitude);
			Nudge();
		}
		if(transform.position.x > wrapMax.x) {
			Vector3 tmpPosition = transform.position;
			tmpPosition.x = wrap.x;
			transform.position = tmpPosition;
		}
		
		if(transform.position.x < wrap.x) {
			Vector3 tmpPosition = transform.position;
			tmpPosition.x = wrapMax.x;
			transform.position = tmpPosition;
		}
		
		if(transform.position.z > wrapMax.y) {
			Vector3 tmpPosition = transform.position;
			tmpPosition.z = wrap.y;
			transform.position = tmpPosition;
			
		}
		
		if(transform.position.z < wrap.y) {
			Vector3 tmpPosition = transform.position;
			tmpPosition.z = wrapMax.y;
			transform.position = tmpPosition;
		}
	}

	private void Nudge()
	{
			if( nudgeIfHidden && GetComponent<Rigidbody>().velocity.magnitude < nudgeThreshold )
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity *  nudgeStrength;
			}
	}
}
