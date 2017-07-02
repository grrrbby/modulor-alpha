using UnityEngine;
using System.Collections;
/* 
Choose GameObject > 3D Object > Cube
Choose Component > Physics > Rigidbody
Choose Assets > Create > Prefab
In the Project View, change the name of your new Prefab to “Brick”
Drag the cube you created in the Hierarchy onto the “Brick” Prefab in the Project View
With the Prefab created, you can safely delete the Cube from the Hierarchy (Delete on Windows, Command-Backspace on Mac)
*/

public class Instantiation : MonoBehaviour {
//
//	[SerializeField] private Transform scope;
//	[SerializeField] private Grid m_Grid;
//	private int scopeWidth;
//	private int scopeLength;
//	private int lengthMax = 100;
//	private int widthMax = 100;
//	private int placeX;
//	private int placeY;
//
//	void Start(){
//
//
//		m_Grid = scope.GetComponent<Grid> ();
//		scopeLength = m_Grid.pilotisLength;
//		scopeWidth = m_Grid.pilotisWidth;
//
//		StartCoroutine (GenerateScope ());
//	}
//
//	private IEnumerator GenerateScope(){
//
//		for (int x = placeX; x < lengthMax; x++) {
//			for (int z = placeY; z < widthMax; z++) {
//				Instantiate (scope, new Vector3 (m_Grid.pilotisLength*m_Grid.spacing, 0, m_Grid.pilotisWidth*m_Grid.spacing), Quaternion.identity);
//				yield return null;
//			}
//		}
//
//		yield return null;
//	}
//
////	void Start() {
////		for (int y = 0; y < 5; y++) {
////			for (int x = 0; x < 5; x++) {
////				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
////				cube.AddComponent<Rigidbody>();
////				cube.transform.position = new Vector3(x, y, 0);
////			}
////		}
////	}
////}
//
////public Transform brick;
////
////void Start() {
////	for (int y = 0; y < 5; y++) {
////		for (int x = 0; x < 5; x++) {
////			Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);
////		}
////	}
////}
}