using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

//	private GameObject object = new GameObject.RequireComponent()
	private List <Transform> childList = new List<Transform>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Transform child in childList) {
		
			child.parent = transform;
		}
	
	}
}
