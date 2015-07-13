using UnityEngine;
using System.Collections;

public class CreateCube : MonoBehaviour
{
	static Transform[,,] modelGrid;
	public CreateCube() {
	}

	public void CreateRainbowCube(Vector3 cubeSize, int[,,] cube, Transform Red_CUBE_Prefab, Transform Orange_CUBE_Prefab, Transform Yellow_CUBE_Prefab, Transform Green_CUBE_Prefab, Transform Blue_CUBE_Prefab, Transform Violet_CUBE_Prefab) {
		for (int k = 0; k < cubeSize.z; k++) {
			if (k % 6 == 0)
				CreateCUBE_level (Red_CUBE_Prefab, cube, cubeSize, k, "red_CUBE");
			if (k % 6 == 1)
				CreateCUBE_level (Orange_CUBE_Prefab, cube, cubeSize, k, "orange_CUBE");
			if (k % 6 == 2)
				CreateCUBE_level (Yellow_CUBE_Prefab, cube, cubeSize, k, "yellow_CUBE");
			if (k % 6 == 3)
				CreateCUBE_level (Green_CUBE_Prefab, cube, cubeSize, k, "green_CUBE");
			if (k % 6 == 4)
				CreateCUBE_level (Blue_CUBE_Prefab, cube, cubeSize, k, "blue_CUBE");
			if (k % 6 == 5)
				CreateCUBE_level (Violet_CUBE_Prefab, cube, cubeSize, k, "violet_CUBE");
		}
	}

	public static Transform[,,] CreateNewCube(Vector3 cubeSize, int[,,] cube, Transform CUBE_Prefab) {
		modelGrid = new Transform[(int)cubeSize.x, (int)cubeSize.y, (int)cubeSize.z];
		for (int k = 0; k < cubeSize.z; k++) {
				CreateCUBE_level (CUBE_Prefab, cube, cubeSize, k, "CUBE");
		}
		return modelGrid;
	}
	
	
	public static void CreateCUBE_level(Transform pref, int[,,] cube, Vector3 cubeSize, int z, string s) {
		for (int i = 0; i < cubeSize.x; i++) {
			for (int j = 0; j < cubeSize.y; j++){
				if(cube[i, j, z] == 1)
				{
					Transform Level;
					Level = (Transform)Instantiate (pref, new Vector3(i*2,j*2,z*2), Quaternion.identity);
					Level.name =  s + string.Format("({0},{1},{2})",i,j,z);
					//Level.parent = transform;
					Level.GetComponent<Cell_Script>().Position = new Vector3(i*2,j*2,z*2);
					modelGrid[i,j,z] = Level;
				}
			}
		}
	}
}

