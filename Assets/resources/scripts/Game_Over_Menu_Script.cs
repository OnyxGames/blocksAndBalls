using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Over_Menu_Script : MonoBehaviour {

	public Canvas GameOverMenu;
	public Text HighScoreText;
	public Text ScoreText;

	// Use this for initialization
	void Start () {
		if (Game_Controller.game_Count == 1) {
			Game_Controller.game_Count = 0;

		}
		GetScoresText ();
	}

	// Loads the Main Menu Scene
	public void MainMenu() {
		Application.LoadLevel (1);
	}

	// Exits the game
	public void ExitGame() {
		Application.Quit ();
	}

	void GetScoresText() {
		int tmp = Game_Controller.highScore;
		if (Game_Controller.highScore < Game_Controller.score) {
			tmp = Game_Controller.score;
			HighScoreText.text = "NEW HIGHSCORE! HIGHSCORE: " + tmp;

		}
		else {
			HighScoreText.text = "HIGHSCORE: " + tmp + "\t\tSCORE: " + Game_Controller.score;
		}
		Game_Controller.highScore = tmp;
		Save_Manager.manager.savedHighscore = tmp;
		Save_Manager.manager.Save();
	}

}
