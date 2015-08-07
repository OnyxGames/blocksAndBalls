using UnityEngine;
using System.Collections;

public class Bottom_Block_Spawner : MonoBehaviour {

	// Public Variables
	public GameObject Bottom_Block;
	public GameObject Bad_Bottom_Block;
	public GameObject Extra_Ball_Block_Bottom;
	public Vector3 spawnLocation = new Vector3 (1, 1, 0);
	public float spawnTime = 2;
	public int good_Or_Bad = 0;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("add_Block", spawnTime, spawnTime);
	}
	
	// Use for adding a block
	void add_Block() {
		good_Or_Bad = Random.Range (1, 50);
	}
	
	// Update is called once per frame
	void Update () {
		if (good_Or_Bad < 25  && good_Or_Bad >= 1) {
			Instantiate (Bottom_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
		
		else if (good_Or_Bad >= 25 && good_Or_Bad <= 48) {
			Instantiate (Bad_Bottom_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}

		else if (good_Or_Bad == 49) {
			Instantiate (Extra_Ball_Block_Bottom, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
	}

	public void SwapBottomBlocks() {
		GameObject tmp = Bottom_Block;
		Bottom_Block = Bad_Bottom_Block;
		Bad_Bottom_Block = tmp;
	}
}
