using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	
	Vector3 cube_size;
	Vector3 previous_mouse_position;
	float xd, yd, zd;
	float ball_xd, ball_yd, ball_zd;

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
			foreach (Transform child in transform)
			{
				if (string.Equals(child.name, "BALL(Clone)")) {
					ball_xd=Camera.main.transform.position.x - child.position.x;
					ball_yd=Camera.main.transform.position.y - child.position.y;
					ball_zd=Camera.main.transform.position.z - child.position.z;
				}

				if (!string.Equals(child.name, "BALL(Clone)") && !string.Equals(child.name, "CUBE(Clone)")) {
					xd=Camera.main.transform.position.x - child.position.x;
					yd=Camera.main.transform.position.y - child.position.y;
					zd=Camera.main.transform.position.z - child.position.z;
					float i = Mathf.Sqrt(xd*xd+yd*yd+zd*zd);
					float j = Mathf.Sqrt(ball_xd*ball_xd+ball_yd*ball_yd+ball_zd*ball_zd);
					if (i > j - 3 && i < j + 5)
						child.GetComponent<Renderer>().enabled = true;
					else
						child.GetComponent<Renderer>().enabled = false;
				}
			}
		}
		else {
			previous_mouse_position = Input.mousePosition;
		}
	}
}

