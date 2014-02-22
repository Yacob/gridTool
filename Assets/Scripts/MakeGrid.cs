using UnityEngine;
using System.Collections;

public class MakeGrid : MonoBehaviour {

	public Transform squarePrefab;
	public int width = 8;
	public int length = 8;
	public float heightPos = 0;
	public float xPos = 0;
	public float zPos = 0;
	public bool checkered = true;
	public bool intersections = false;
	public Transform[,] squares;

	void Start () {
		SetUpBoard();
		if(checkered){
			SetColor();
		}
	}
	
	void SetUpBoard(){
		if(intersections){
			squares = new Transform[width + 1, length + 1];
		}
		else{
			squares = new Transform[width, length];
		}
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < length; z++) {
				Transform newSquare;
				newSquare = (Transform)Instantiate(squarePrefab, new Vector3 (x + xPos, heightPos, z + zPos), Quaternion.identity);
				newSquare.parent = transform;	//puts grid as parent of gameSquare
				newSquare.name = "(" + x + ", " + heightPos + ", " + z + ")";	//names square
				squares[x, z] = newSquare;		//note that this array is x by z so layout (column, row) instead of (row, column)
			}
		}
	}
	
	void SetColor() {
		//Applies checkered pattern to board
		foreach(Transform square in transform){
			if(((int)square.position.x + (int)square.position.z) % 2 == 0){
				square.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
			}
			else {
				square.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
			}
		}
	}
	
	public Vector3 snapHeight(Vector3 temp){
		temp.y = heightPos + 1;
		return temp;
	}
	public Vector3 snap(Vector3 temp){
		float intersectionOffset = 0.0f;
		if(intersections){
			//Changes piece snapping to have snapping to corners of squares instead of the middle of squares.
			intersectionOffset = 0.5f;
		}
		temp = snapHeight(temp);
		if(temp.x < xPos - intersectionOffset){
			temp.x = xPos - intersectionOffset;
		}
		else if(temp.x > xPos + width - 1 + intersectionOffset){
			temp.x = xPos + width - 1 + intersectionOffset;
		}
		if(temp.z < zPos - intersectionOffset){
			temp.z = zPos - intersectionOffset;
		}
		else if(temp.z > zPos + length - 1 + intersectionOffset){
			temp.z = zPos + length - 1 + intersectionOffset;
		}
		float offset = temp.x - xPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.x = offset + xPos + intersectionOffset;
		
		offset = temp.z - zPos - intersectionOffset;
		offset = Mathf.Round(offset);
		temp.z = offset + zPos + intersectionOffset;
		
		return temp;
		
	}

}
