using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameController : MonoBehaviour {

	public GameObject primaryBrick;
	public GameObject secondaryBrick;
	public GameObject primaryBall;
	public GameObject secondaryBall;
	public GameObject primaryBackground;
	public GameObject secondaryBackground;
	public GameObject bonusBrick;
	public Sprite blueBall;
	public Sprite blueBrick;
	public Sprite blueBackground;
	public Sprite redBall;
	public Sprite redBrick;
	public Sprite redBackground;
	public Sprite yellowBall;
	public Sprite yellowBrick;
	public Sprite yellowBackground;
	public Sprite orangeBall;
	public Sprite orangeBrick;
	public Sprite orangeBackground;
	public Sprite tealBall;
	public Sprite tealBrick;
	public Sprite tealBackground;
	public Sprite pinkBall;
	public Sprite pinkBrick;
	public Sprite pinkBackground;
	public Sprite whiteBall;
	public Sprite whiteBrick;
	public Sprite whiteBackground;
	public Sprite blackBall;
	public Sprite blackBrick;
	public Sprite blackBackground;
	public Sprite greyBall;
	public Sprite greyBrick;
	public Sprite greyBackground;
	public Sprite greenBall;
	public Sprite greenBrick;
	public Sprite greenBackground;
	public Text scoreGUI;
	public Text ballCountGUI;
	public static Vector3 ballSpawnLocationTop = new Vector3(0,3,0);
	public static Vector3 ballSpawnLocationBottom = new Vector3(0,-3,0);
	public static bool defaultColors = true;
	public static Sprite currentPrimaryBrick;
	public static Sprite currentSecondaryBrick;
	public static Sprite currentBonusBrick;
	public static Sprite currentPrimaryBall;
	public static Sprite currentSecondaryBall;
	public static Sprite currentPrimaryBackground;
	public static Sprite currentSecondaryBackground;
	public static int score;
	public static int ballCount;
	public static int highScore;
	public static float brickSpeed;
	public static float ballSpeed;
	

	// Use this for initialization
	void Start () {
		score = 0;
		ballCount = 3;
		UpdateScore();
		UpdateBallCount();
		currentPrimaryBrick = redBrick;
		currentSecondaryBrick = whiteBrick;
		currentBonusBrick = redBrick;
		currentPrimaryBall = greenBall;
		currentSecondaryBall = blueBall;

		// Accesses Primary Brick Object
		SpriteRenderer primaryBrickSpriteRenderer = primaryBrick.GetComponent<SpriteRenderer>();
		if (primaryBrickSpriteRenderer != null) {
			primaryBrickSpriteRenderer.sprite = currentPrimaryBrick;
		}

		// Accesses Secondary Brick Object
		SpriteRenderer secondaryBrickSpriteRenderer = secondaryBrick.GetComponent<SpriteRenderer>();
		if (secondaryBrickSpriteRenderer != null) {
			secondaryBrickSpriteRenderer.sprite = currentSecondaryBrick;
		}

		// Accesses Bonus Brick Object
		SpriteRenderer bonusBrickSpriteRenderer = bonusBrick.GetComponent<SpriteRenderer>();
		if (bonusBrickSpriteRenderer != null) {
			bonusBrickSpriteRenderer.sprite = currentBonusBrick;
		}

		// Accesses Primary Ball Object
		SpriteRenderer primaryBallSpriteRenderer = primaryBall.GetComponent<SpriteRenderer>();
		if (primaryBallSpriteRenderer != null) {
			primaryBallSpriteRenderer.sprite = currentPrimaryBall;
		}

		// Accesses Secondary Ball Object
		SpriteRenderer secondaryBallSpriteRenderer = secondaryBall.GetComponent<SpriteRenderer>();
		if (secondaryBallSpriteRenderer != null) {
			secondaryBallSpriteRenderer.sprite = currentSecondaryBall;
		}

		// Accesses Primary Background Object
		SpriteRenderer primaryBackgroundSpriteRenderer = primaryBackground.GetComponent<SpriteRenderer>();
		if (primaryBackgroundSpriteRenderer != null) {
			primaryBackgroundSpriteRenderer.sprite = currentPrimaryBackground;
		}
		
		// Accesses Secondary Background Object
		SpriteRenderer secondaryBackgroundSpriteRenderer = secondaryBackground.GetComponent<SpriteRenderer>();
		if (secondaryBackgroundSpriteRenderer != null) {
			secondaryBackgroundSpriteRenderer.sprite = currentSecondaryBackground;
		}

		Instantiate(primaryBall, new Vector3(0,0,0), Quaternion.identity);
		Instantiate(primaryBrick, new Vector3(0,3,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Update is called a fixed amount of frames
	void FixedUpdate() {

	}

	// Updates Ball Count on screen
	void UpdateBallCount() {
		ballCountGUI.text = "BALLS LEFT: " + ballCount;
	}

	// Updates Score on screen
	void UpdateScore() {
		scoreGUI.text = "SCORE: " + score;
	}

	void ValidateHighScore() {
		if (score > highScore) {
			highScore = score;
		}
	}

	public void ChangePrimarySprites(Sprite ballColor, Sprite brickColor) {
		currentPrimaryBall = ballColor;
		currentPrimaryBrick = brickColor;
	}

	public void ChangeSecondarySprites(Sprite ballColor, Sprite brickColor) {
		currentSecondaryBall = ballColor;
		currentSecondaryBrick = brickColor;
	}
}
