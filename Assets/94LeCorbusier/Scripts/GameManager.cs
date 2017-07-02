using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject seedplanter;
	[SerializeField] private Camera cam;

	public float camProSize;
	public float camProY;

	public int chapterone = 100;
	public int counter;

	private bool trig;

	[SerializeField] public List<Color> groundColor = new List<Color>(10);
	[SerializeField] public List<Color> detailColor = new List<Color>(10);
	[SerializeField] public List<Color> buildingColor = new List<Color>(10);
	[SerializeField] public List<Color> pilotisColor = new List<Color>(10);
	[SerializeField] public List<Color> glassColor = new List<Color>(10);


	// Use this for initialization
	void Start () {
		

		StartCoroutine (Looper ());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (0);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
		
		}
	}


	private IEnumerator Looper(){


		yield return new WaitForSeconds (0.01f);
		seedplanter.GetComponent<LeCorbGrid> ().CellularAutomata ();
		counter += 1;
		StartCoroutine(Loop ());
//		StartCoroutine (LerpCam ());
		yield return null;
	}

	private IEnumerator Loop(){

		if (counter < chapterone) {
			StartCoroutine (Looper ());
			yield return null;
		} else if (counter == chapterone) {
			seedplanter.SendMessage ("KMeansClusterAnalysis");
			seedplanter.SendMessage ("UnBuild");
			yield return null;
		}
	}



//	private IEnumerator LerpCam(){
//		cam.transform.Translate (new Vector3 (-1, 0, 0), Space.World);
//		if (counter > chapterone) {
//			StartCoroutine (Looper ());
//			if(cam.transform.position.x < -220){
//				SceneManager.LoadScene (0);
//			}
//			yield return null;
//		} 
//		yield return null;
//
//	}

//	void MoveCamera(){
//		cam.orthographicSize = (cam.orthographicSize - camProSize);
//		cam.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y + camProY, cam.transform.position.z);
//	}
}
