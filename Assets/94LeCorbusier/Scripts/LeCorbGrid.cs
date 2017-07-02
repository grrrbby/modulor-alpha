using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeCorbGrid : MonoBehaviour {

	[SerializeField] private GameManager m_GameManager;

	static public int columns = 20;
	static public int rows = 20;

	[SerializeField] public int randcolumns;
	[SerializeField] public int randrows;

	[SerializeField] public int wrapNo;

	[SerializeField] private float kmeansTotalOne;
	[SerializeField] private float kmeansTotalTwo;
	[SerializeField] private float kmeansTotalThree;

	[SerializeField] private int kmeansDivide;


	public int[,] next = new int[columns,rows];
	public int[,] board = new int[columns,rows];

	public float spacing;

	public List<GameObject> seedlings = new List<GameObject>();
	[SerializeField] private GameObject seed;


	void Start(){

		wrapNo = Mathf.RoundToInt (Random.Range (0f, 10f));
		
		randcolumns = Mathf.RoundToInt (Random.Range (0f, columns));
		randrows = Mathf.RoundToInt (Random.Range (0f, rows));
		m_GameManager.chapterone = randcolumns + randrows;

		spacing = Mathf.RoundToInt (Random.Range (0f, 7f));

		for (int x = 1; x < randcolumns - 1; x++) {
			for (int y = 1; y < randrows - 1; y++) {
				Instantiate (seed, this.gameObject.transform);
				seed.GetComponent<LeCorbSeed> ().locationx = x;
				seed.GetComponent<LeCorbSeed> ().locationy = y;
				seed.GetComponent<LeCorbSeed> ().spacing = Mathf.RoundToInt(spacing);
			}
		}
		seedlings.AddRange (GameObject.FindGameObjectsWithTag ("seed"));
		RandomizeStates ();
	}

	void KMeansClusterAnalysis(){
		Debug.Log ("KmeanClusterAnalysis");

		kmeansDivide = (seedlings.Count / 3);
		for (int j = 0; j < kmeansDivide -1; j++) {
			if (seedlings [j].GetComponent<LeCorbSeed> ().state == 1) {
				kmeansTotalOne += seedlings [j].GetComponent<LeCorbSeed> ().life;
			}
		}
		kmeansTotalOne = (kmeansTotalOne / kmeansDivide);

		for (int k = kmeansDivide; k < (kmeansDivide*2)-1; k++) {
			if (seedlings [k].GetComponent<LeCorbSeed> ().state == 1) {
				kmeansTotalTwo += seedlings [k].GetComponent<LeCorbSeed> ().life;
			}
		}
		kmeansTotalTwo = (kmeansTotalTwo / kmeansDivide);

//		for (int l = kmeansDivide*2; l < (kmeansDivide*3)-1; l++) {
//			if (seedlings [l].GetComponent<LeCorbSeed> ().state == 1) {
//				kmeansTotalThree += seedlings [l].GetComponent<LeCorbSeed> ().life;
//			}
//		}
		kmeansTotalThree = (kmeansTotalOne / kmeansTotalTwo);

		if (kmeansTotalOne == 0 | kmeansTotalTwo == 0 | kmeansTotalThree == 0) {
			SceneManager.LoadScene (0);
		}

//		if (kmeansTotalOne > kmeansTotalTwo + kmeansTotalThree) {
//			kmeansTotalOne = kmeansTotalOne / 3;
//		} 
//		if (kmeansTotalTwo > kmeansTotalOne + kmeansTotalThree) {
//			kmeansTotalTwo = kmeansTotalTwo /3;
//		} 
//		if (kmeansTotalThree > kmeansTotalOne + kmeansTotalTwo) {
//			kmeansTotalThree = kmeansTotalThree /3;
//		}

		if (System.Single.IsNaN (kmeansTotalOne) || System.Single.IsNaN (kmeansTotalTwo) || System.Single.IsNaN (kmeansTotalThree)) {
			SceneManager.LoadScene (0);
		}
		SendStates ();
		ClusterHeights ();
	}


	public void CellularAutomata(){
		Debug.Log ("CellularAutomata");

		for (int x = 1; x < columns-1; x++) {
			for (int y = 1; y < rows-1; y++) {
				
				int neighbors = 0;
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {
						
					neighbors += board[x+i,y+j];
					}
				}
				neighbors -= board[x,y];

				if ((board [x, y] == 1) && (neighbors < 2)) {
					next [x, y] = 0;
				} else if ((board [x, y] == 1) && (neighbors > 3)) {
					next [x, y] = 0;
				} else if ((board [x, y] == 0) && (neighbors == 3)) {
					next [x, y] = 1;
				} else {
					next [x, y] = board [x, y];
				}
			}
		}
		board = next;
		SendStates ();

	}
		
	void RandomizeStates(){
		Debug.Log ("RandomizeStates");


		
		foreach (GameObject obj in seedlings) {
			obj.GetComponent<LeCorbSeed> ().state = Mathf.RoundToInt (Random.Range (Random.Range(0f,1f), Random.Range(0f,1f)));
			obj.GetComponent<LeCorbSeed> ().life = Random.Range (Random.Range(0f,1f), Random.Range(0f,1f));
			board [obj.GetComponent<LeCorbSeed> ().locationx, obj.GetComponent<LeCorbSeed> ().locationy] = obj.GetComponent<LeCorbSeed> ().state;
		}

		KMeansClusterAnalysis();
	}


	void SendStates(){
		Debug.Log ("SendStates");


		
		foreach (GameObject obj in seedlings) {
			obj.GetComponent<LeCorbSeed> ().state = next [obj.GetComponent<LeCorbSeed> ().locationx, obj.GetComponent<LeCorbSeed> ().locationy];
			obj.SendMessage ("TranslatePosition");
			obj.SendMessage ("AssessValue");
		}

		BuildGround ();


	}

	void BuildGround(){
		Debug.Log ("BuildGround");


		for(int i = 0; i < seedlings.Count-1; i++) {
			seedlings [i].GetComponent<LeCorbSeed> ().BuildGround ();
			m_GameManager.counter += 1;

		}
	}

	void ClusterHeights(){
		Debug.Log ("ClusterHeights");


		for (int j = 0; j < kmeansDivide-1; j++) {
			if (seedlings [j].GetComponent<LeCorbSeed> ().state == 1) {
				seedlings [j].GetComponent<LeCorbSeed> ().life = kmeansTotalOne;
			}
		}

		for (int k = kmeansDivide; k < (kmeansDivide*2)-1; k++) {
			if (seedlings [k].GetComponent<LeCorbSeed> ().state == 1) {
				seedlings [k].GetComponent<LeCorbSeed> ().life = kmeansTotalTwo;
			}
		}

		for (int l = kmeansDivide*2; l < (kmeansDivide*3)-1; l++) {
			if (seedlings [l].GetComponent<LeCorbSeed> ().state == 1) {
				seedlings [l].GetComponent<LeCorbSeed> ().life = kmeansTotalThree;
			}
		}

	}

	void UnBuild(){

		Debug.Log ("UnBuild");


		foreach (GameObject obj in seedlings) {
			obj.SendMessage ("UnBuildStoreys");
		}
	}

//	void CalulateCamera(){
//
//		int lifenumber = 0;
//
//		if (randcolumns > randrows) {
//			m_GameManager.camProSize = (randcolumns / spacing);
//		} else if (randcolumns < randrows) {
//			m_GameManager.camProSize = (randrows / spacing);
//		}
//		foreach (GameObject obj in seedlings) {
//			m_GameManager.camProY += obj.GetComponent<LeCorbSeed> ().life;
//			lifenumber += 1;
//		}
//		m_GameManager.camProY = (m_GameManager.camProY / lifenumber)* 30;
//		m_GameManager.SendMessage("MoveCamera");
//	}
}