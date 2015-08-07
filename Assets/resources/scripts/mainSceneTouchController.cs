using UnityEngine;
using System.Collections;

public class mainSceneTouchController : MonoBehaviour {

	public float timeBeforePress = 1;
	public bool pressActive = false;
	// Use this for initialization
	void Start () {
		timeBeforePress = 1;
		pressActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBeforePress > 0) {
			timeBeforePress -= Time.deltaTime;
		}
		if (timeBeforePress <= 0) {
			pressActive = true;
		}
		if ( Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				if(hit.transform.gameObject.name == "Button Top") {
				Ball_Spawner.SpawnUp();
				}
				if(hit.transform.gameObject.name == "Button Bottom") {
					Ball_Spawner.SpawnDown();
				}
			}
		}
		if (Input.GetMouseButtonDown (0) && pressActive == true && Input.touchCount == 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				if(hit.transform.gameObject.name == "Button Top") {
					Ball_Spawner.SpawnUp();
				}
				if(hit.transform.gameObject.name == "Button Bottom") {
					Ball_Spawner.SpawnDown();
				}
			}
		}

}

}
