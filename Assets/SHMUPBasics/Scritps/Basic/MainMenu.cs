using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Button Play;

	// Use this for initialization
	void Start () {
	
		Play = Play.GetComponent<Button> ();
	}
	
	public void StartLevel()
	{
		Application.LoadLevel (1);
	}
}
