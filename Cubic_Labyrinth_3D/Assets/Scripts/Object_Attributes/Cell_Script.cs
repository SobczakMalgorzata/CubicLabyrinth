﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cell_Script : MonoBehaviour {

	public List<Transform> Adjacents;
	public Vector3 Position;
	public int Weight;
	
	public int AdjacentsOpened = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
