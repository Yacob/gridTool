using UnityEngine;
using System.Collections;

public class MakeGrid : MonoBehaviour {

	public Transform squarePrefab;
	public int width;
	public int length;
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
				newSquare = (Transform)Instantiate(squarePrefab, new Vector3 (x, 0, z), Quaternion.identity);
				newSquare.parent = transform;	//puts grid as parent of gameSquare
				newSquare.name = "(" + x + ", " + z + ")";	//names square
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

}
