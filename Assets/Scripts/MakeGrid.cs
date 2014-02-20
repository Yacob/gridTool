using UnityEngine;
using System.Collections;

public class MakeGrid : MonoBehaviour {

	public Transform squarePrefab;
	public int width;
	public int length;
	public float heightPos = 0;
	public float xPos = 0;
	public float zPos = 0;
	public bool checkered = true;
	

	void Start () {
		SetUpBoard();
		if(checkered){
			SetColor();
		}
	}
	
	void SetUpBoard(){
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < length; z++) {
				Transform newSquare;
				newSquare = (Transform)Instantiate(squarePrefab, new Vector3 (x + xPos, heightPos, z + zPos), Quaternion.identity);
				newSquare.parent = transform;	//puts grid as parent of gameSquare
				newSquare.name = "(" + x + ", " + heightPos + ", " + z + ")";	//names square
			}
		}
	}
	
	void SetColor() {
		foreach(Transform square in transform){
			if(((int)square.position.x + (int)square.position.z) % 2 == 0){
				Debug.Log((int)square.position.x + " " + (int)square.position.z);
				square.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
			}
			else {
				Debug.Log((int)square.position.x + " " + (int)square.position.z);
				square.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
			}
		}
	}
	
	public Vector3 snapHeight(Vector3 temp){
		temp.y = heightPos + 1;
		return temp;
	}
	public Vector3 snap(Vector3 temp){
		temp = snapHeight(temp);
		if(temp.x < xPos){
			temp.x = xPos;
		}
		else if(temp.x > xPos + width){
			temp.x = xPos + width - 1;
		}
		if(temp.z < zPos){
			temp.z = zPos;
		}
		else if(temp.z > zPos + length){
			temp.z = zPos + length - 1;
		}
		float offset = temp.x - xPos;
		offset = Mathf.Round(offset);
		temp.x = offset + xPos;
		Debug.Log("offset after rounding for x " + offset);
		
		offset = temp.z - zPos;
		offset = Mathf.Round(offset);
		temp.z = offset + zPos;
		Debug.Log("offset after rounding for z " + offset);
		return temp;
		
	}

}
