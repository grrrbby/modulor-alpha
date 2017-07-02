using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour {

	private int num = 100;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < num; i++) {
			Instantiate (this.gameObject.transform, new Vector3 (0, 0, i), Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
