﻿using UnityEngine;
using System.Collections;

public class Main_Scene_Background : MonoBehaviour {

	public Material matOne;
	public Material matTwo;
	public float fade_Speed = 0.05f;
	public MeshRenderer rend;
	public bool firstMat;
	public Material new_Material;
	public float material_Timer;

	// Use this for initialization
	void Start () {
		firstMat = true;
		rend = GetComponent <MeshRenderer> ();
		new_Material = matOne;
		material_Timer = 1.0f;
		InvokeRepeating ("CountUp", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		//rend.material.Lerp (rend.material, new_Material, Time.deltaTime);
		if (material_Timer == 10) {
			new_Material = matTwo;
		}
		if (material_Timer == 20) {
			new_Material = matOne;
			material_Timer = 0;
		}
	}

	void CountUp () {
		material_Timer += 1;
	}

}
