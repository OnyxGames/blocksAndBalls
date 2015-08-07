using UnityEngine;
using System.Collections;

public class Ball_Script : MonoBehaviour {

	// Private Scripts
	private Game_Controller gameController;

	// Public Variables 
	public Rigidbody rb;
	public bool destroy_Balls;
	public Texture blackball;
	public Texture whiteball;

	// Private Variables
	private bool launched = false;
	private bool up = false;
	private bool down = false;

	// Use this for initialization
	void Start () {
		launched = false;
		// Gets this GameObjects Rigidbody
		rb = GetComponent<Rigidbody> ();
		if (Game_Controller.Whiteness) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
		} else if (!(Game_Controller.Whiteness)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
		}


		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Game_Controller>();
		}

	}

	// Function called on-collision 
	void OnCollisionEnter (Collision col) {

		// Gamecontroller;
		int normal_Block_Points = 1;
		if (Game_Controller.Whiteness) {
			if (col.gameObject.tag == "Normal_Block" || col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block" || col.gameObject.tag == "Extra_Ball_Block") {
				Destroy (this.gameObject);
			}
			if (col.gameObject.tag == "Normal_Block") {
				gameController.AddScore (normal_Block_Points);
			}
			if (col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block") {
				gameController.DecrementBall ();
			}
			if (col.gameObject.tag == "Bad_Block") {
				gameController.SubtractScore (normal_Block_Points);
			}
		}

		if (!(Game_Controller.Whiteness)) {
			if (col.gameObject.tag == "Normal_Block" || col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block" || col.gameObject.tag == "Extra_Ball_Block") {
				Destroy (this.gameObject);
			}
			if (col.gameObject.tag == "Bad_Block") {
				gameController.AddScore (normal_Block_Points);
			}
			if (col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Normal_Block") {
				gameController.DecrementBall ();
			}
			if (col.gameObject.tag == "Normal_Block") {
				gameController.SubtractScore (normal_Block_Points);
			}
		}

		if (col.gameObject.tag == "Extra_Ball_Block") {
			gameController.IncrementBall ();
			gameController.AddScore(normal_Block_Points);
		}

	}

	// Update is called once per frame
	void Update () {
		// Controls Fire Up
	if (Ball_Spawner.sendItUp && launched == false) {
				rb.velocity = new Vector3 (0, 12, 0);
			Ball_Spawner.sendItUp = false;
			Ball_Spawner.new_Ball_Check = false;
			launched = true;

		}

		// Controls Fire Down
		if (Ball_Spawner.sendItDown && launched == false) {
				rb.velocity = new Vector3 (0, -12, 0);
			Ball_Spawner.sendItDown = false;
			Ball_Spawner.new_Ball_Check = false;
			launched = true;
		}

		// Makes ball proper color
		if (Game_Controller.Whiteness) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
		} else if (!(Game_Controller.Whiteness)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
		}
	}

	public void ChangeBallColor () {

		if (Game_Controller.light_Ball) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
			Debug.Log("made it light!");
		}

		if (!(Game_Controller.light_Ball)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
			Debug.Log("made it dark!");
		}
	} 

	public void GoUp() {
		if (!up) {
			Debug.Log ("Go up");
			up = true;
		}
	}
	public void GoDown() {
		if (!down) {
			Debug.Log ("Go down");
			down = true;
		}
	}
}