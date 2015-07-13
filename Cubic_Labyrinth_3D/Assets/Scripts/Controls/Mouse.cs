using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	
	Vector3 cube_size;
	Vector3 previous_mouse_position;

	// Use this for initialization
	void Start ()
	{
		cube_size = this.GetComponent<CubeAttributes> ().cubeSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton(0)) {
			transform.RotateAround(cube_size - new Vector3 (1,1,1), Vector3.up, (previous_mouse_position.x - Input.mousePosition.x) * 10 * Time.deltaTime);
			transform.RotateAround(cube_size - new Vector3 (1,1,1), Vector3.left, (previous_mouse_position.y - Input.mousePosition.y)* 10 * Time.deltaTime);
			previous_mouse_position = Input.mousePosition;

		}
		else {
			previous_mouse_position = Input.mousePosition;
			
		}
	}
}

