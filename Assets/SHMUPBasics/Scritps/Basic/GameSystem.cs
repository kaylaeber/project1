using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

	public int _PlayerScore;
	private int playerscore;

	public Text playerScoreText;


	// Use this for initialization
	void Start () {
		_PlayerScore = 0;
		if(playerScoreText != null){
			playerScoreText.text = _PlayerScore.ToString();
		}
		else {
			Debug.Log("Null");
		}
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

		playerScoreText.text = _PlayerScore.ToString();
	}


}
