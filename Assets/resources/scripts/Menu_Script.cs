using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Loads the Main Game Scene
	public void PlayGame() {
		Application.LoadLevel (2);
	}

	// Loads the Options Scene
	public void Unblockables() {
		Application.LoadLevel (4);
	}

	// Exits the game
	public void ExitGame() {
		Application.Quit ();
	}
}