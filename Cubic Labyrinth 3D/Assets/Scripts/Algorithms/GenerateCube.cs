﻿using UnityEngine;
using System.Collections;

public class GenerateCube : MonoBehaviour {

	Transform outer_cube;
	Transform inner_cube;
	Transform my_ball;
	Vector3 cube_size;

	// Use this for initialization
	void Start () {
		Transform Level;

		outer_cube = this.GetComponent<CubeAttributes>().CUBE_Prefab;
		my_ball = this.GetComponent<CubeAttributes>().Ball;
		cube_size = this.GetComponent<CubeAttributes> ().cubeSize;

		Level = (Transform)Instantiate (outer_cube, new Vector3(0,0,0), Quaternion.identity);
		Level.localScale = cube_size + new Vector3 (0.0001f,0.0001f,0.0001f);
		Level.parent = transform;
		Level.position = cube_size - new Vector3 (1,1,1);

		Level = (Transform)Instantiate (my_ball, new Vector3(0,0,0), Quaternion.identity);
		Level.parent = transform;

		this.GetComponent<CubeAttributes>().modelGrid = new Transform[(int)cube_size.x, (int)cube_size.y, (int)cube_size.z];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}