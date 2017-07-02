using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* 
Frame			Storey Level			Column Size (mm)
10-Storey			1-10					700x700

20-Storey			1-7						750x750
					8-14					600x600
					15-20					450x450

30-Storey			1-10					800x800
					11-20					650x650
					21-30					470x470


*/


public class UniverseGenerator : MonoBehaviour {

	public Vector3 sizeOfPilotis = new Vector3 (1, 1, 1);
	public int numOfPilotisX = 1;	//How many pilotis to place on the x.
	public int numOfPilotisY = 1;	//How many pilotis to stack on top to create levels.
	public int numOfPilotisZ = 1;	//How many pilotis to place on the z.
	public int numOfPilotisTotal = 0;

	public Vector3 pilotisSpacing = Vector3.one;

	public Transform pilotis;

	void Start(){


	}


	void Update(){

		//		if (Input.GetButtonDown ("Fire1")) {
		this.gameObject.transform.RotateAround(Vector3.up,Vector3.up,Random.Range (0, 100));
		this.gameObject.transform.RotateAround(Vector3.up,Vector3.left,Random.Range (0, 100));
		this.gameObject.transform.RotateAround(Vector3.up,Vector3.forward,Random.Range(0,100));
		StartCoroutine (CreatePilotis ());
		//		}
	}

	private IEnumerator CreatePilotis(){

		pilotis.transform.localScale = sizeOfPilotis;
		sizeOfPilotis.x = Random.Range (0, 10000);
		sizeOfPilotis.y = Random.Range (0, 10000);
		sizeOfPilotis.z = Random.Range (0, 10000);
		numOfPilotisX = Random.Range (0, 10000);
		numOfPilotisY = Random.Range (0, 10000);
		numOfPilotisZ = Random.Range (0, 10000);
		pilotisSpacing = new Vector3 (sizeOfPilotis.x, sizeOfPilotis.y, sizeOfPilotis.z);

		for(int x = 0; x < numOfPilotisX; x++)
		{
			for(int z = 0; z < numOfPilotisZ; z++)
			{
				for(int y = 0; y < numOfPilotisY; y++)
				{
					Instantiate(pilotis,transform.position+transform.right*x*sizeOfPilotis.x*pilotisSpacing.x+transform.up*y*sizeOfPilotis.y*pilotisSpacing.y+transform.forward*z*sizeOfPilotis.z*pilotisSpacing.z,Quaternion.identity);
					numOfPilotisTotal += 1;
					yield return null;
				}
			}
		}

		yield return null;

	}
}


//	void Update(){
//		this.gameObject.transform.localScale = columnSize;
//		CalculateColumn ();
//	}

//	private void CalculateColumn(){
//
//		if (numberOfStoreys <= 10) {
//			columnSize = new Vector2(700,700);
//		}
//	private IEnumerator CreateFloor(){
//		while (levelNumber < numberOfStoreys) {
//
//			levelNumber += 1;
//
//			politis.transform.localScale = new Vector3 (columnDiameter.x, columnHeight, columnDiameter.y);
//
//			for (int x = 0; x < width; x++) {
//				for (int z = 0; z < length; z++) {
//					for (int y = 0; y < numberOfStoreys; y++) {
//						instantiationVector = new Vector3 (x, y, z);
//						Instantiate (politis, instantiationVector, Quaternion.identity);
//					}
//				}
//			}
//			yield return null;
//		}
//	}
//





