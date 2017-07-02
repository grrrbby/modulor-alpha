using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeCorbPilotis : MonoBehaviour {

	[SerializeField] List<GameObject> grammar = new List<GameObject> (10);
	[SerializeField] private List<GameObject> compass = new List<GameObject> (4);
	[SerializeField] private GameObject wallgrammar;
	[SerializeField] public Transform roofTransform;

	public bool rooflevel;
	public bool invariantlevel;

	//All these values inherit from the parent seed.
	private int invariance;

	// Use this for initialization
	void Start () {

		if (!invariantlevel & wallgrammar != null) {
			invariance = GetComponentInParent<LeCorbSeed> ().invariance;
			wallgrammar = grammar [invariance];
		} else {
			wallgrammar = grammar [0];
		}
			
		StartCoroutine (BuildStorey ());
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private IEnumerator BuildStorey (){

			foreach(GameObject bearing in compass){
				Instantiate (wallgrammar, bearing.transform.position, bearing.transform.rotation, bearing.transform);
				yield return null;
			}
			
		yield return new WaitForSeconds(0.5f);
//		SceneManager.LoadScene (0);
	}
		
}
