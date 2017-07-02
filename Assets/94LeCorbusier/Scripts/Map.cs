using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	static public int columns = 30;
	static public int rows = 30;
	public int[,] board = new int[columns,rows];
	public int[,] next = new int[columns,rows];

	[SerializeField] private GameObject seed;

	private Transform self;
	private int neighbours;

	// Use this for initialization
	void Start () {
		self = this.transform;
		StartCoroutine (GenerateMap ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator GenerateMap(){

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1) {
					Instantiate (seed, new Vector3 (x,0,y), Quaternion.identity, self);
				} else {

				}

				yield return null;
			}
		}
		yield return null;
	}



	private IEnumerator GenerateNextMap(){

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1) {
					Instantiate (seed, new Vector3 (x, 0, y), Quaternion.identity, self);
				} else {
					Instantiate (seed, new Vector3 (x, 0, y), Quaternion.identity, self);
				}
			}
		}
		
		yield return null;
	}
}
