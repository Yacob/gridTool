using UnityEngine;
using System.Collections;

public class cubeScript : MakeGrid {

	// Use this for initialization
	
	// Update is called once per frame
	
	void Update () {
		bool up = Input.GetKey(KeyCode.UpArrow);
		bool down = Input.GetKey(KeyCode.DownArrow);
		bool right = Input.GetKey(KeyCode.RightArrow);
		bool left = Input.GetKey(KeyCode.LeftArrow);
		if(up){
			Vector3 temp = transform.position;
			temp.z += 0.1f;
			transform.position = temp;
		}
		if(down){
			Vector3 temp = transform.position;
			temp.z -= 0.1f;
			transform.position = temp;
		}
		if(right){
			Vector3 temp = transform.position;
			temp.x += 0.1f;
			transform.position = temp;
		}
		if(left){
			Vector3 temp = transform.position;
			temp.x -= 0.1f;
			transform.position = temp;
		}
		if(!up && !down && !left && !right){
			Vector3 pos = transform.position;
			pos = snap(pos);
			transform.position = pos;
		}
	}
}
