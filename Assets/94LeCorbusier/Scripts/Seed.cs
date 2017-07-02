using UnityEngine;
using System.Collections;

public class Seed : MonoBehaviour {

	[SerializeField] private Material black;
	[SerializeField] private Material white;

	private Renderer goRenderer;
	public float life;
	public int value;

	// Use this for initialization
	void Start () {

		goRenderer = this.gameObject.GetComponent<Renderer> ();
		life = Random.Range (0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

		if (life > 0.5f) {
			goRenderer.material = black;	
		} else {
			goRenderer.material = white;
		}
	
	}
}
