using UnityEngine;
using System.Collections;

public class offSceneDelete : MonoBehaviour {

	public GameObject toBeDeleted;



	void OnBecameInvisible() {
		Destroy(toBeDeleted);
	}

}
