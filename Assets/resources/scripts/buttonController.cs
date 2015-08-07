using UnityEngine;
using System.Collections;

public class buttonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backScene() {
		Application.LoadLevel(1);
		Debug.Log("PLEASE");
	}
}
