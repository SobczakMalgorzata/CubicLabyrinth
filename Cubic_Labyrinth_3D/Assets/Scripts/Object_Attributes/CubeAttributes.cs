using UnityEngine;
using System.Collections;

public class CubeAttributes : MonoBehaviour {
	
	public Vector3 cubeSize = new Vector3 (5, 5, 5);
	
	//CubesColors
	public Transform Ball;
	
	public Transform CUBE_Prefab;
	
	public Transform Red_CUBE_Prefab;
	public Transform Yellow_CUBE_Prefab;
	public Transform Orange_CUBE_Prefab;
	public Transform Green_CUBE_Prefab;
	public Transform Blue_CUBE_Prefab;
	public Transform Violet_CUBE_Prefab;
	
	//public List<Vector3> Set;
	//public List<List<Vector3>> AdjSet;
	
	//Cube reference
	public Transform[,,] modelGrid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
