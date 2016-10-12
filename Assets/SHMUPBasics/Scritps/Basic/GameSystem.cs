using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

	public int _PlayerScore;
	private int playerscore;
	// Use this for initialization
	void Start () {
		_PlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// SCRIPT API //

	public void HitByBullet()
	{
		AddToPlayerScore (10);
		//Debug.Log("I GOT HIT BY A BULLET!");
	}

	public void AddToPlayerScore(int addSCore)
	{
		_PlayerScore = _PlayerScore + addSCore;
		Debug.Log ("SCORE IS NOW: " + _PlayerScore);
	}
}
