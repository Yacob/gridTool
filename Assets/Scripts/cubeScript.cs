using UnityEngine;
using System.Collections;

public class cubeScript : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	public MakeGrid grid;
	
	void Update () {
		//modify to only move selected object using mousedown and/or raycasting
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
			pos = grid.snap(pos);
			transform.position = pos;
		}
	}
}
