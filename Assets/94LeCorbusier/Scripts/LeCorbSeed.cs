using UnityEngine;
using System.Collections;

public class LeCorbSeed : MonoBehaviour {

	public float storeyHeight = 6.5f;

	[SerializeField] private LeCorbGrid m_LeCorbGrid;
	[SerializeField] public Renderer m_renderer;
	[SerializeField] public Material black;
	[SerializeField] public Material white;
	[SerializeField] private GameObject pilotis;
	[SerializeField] private GameObject level1;
	[SerializeField] private GameObject roof;
	[SerializeField]public int spacing;

	public int invariance;
	public int variance;

	private bool builtq;
	private float randomtime;

	public int locationx;
	public int locationy;

	public int state;
	public float life;


	// Use this for initialization
	void Start () {

		invariance = Mathf.RoundToInt (Random.Range (0f, 13f));
		variance = m_LeCorbGrid.wrapNo;
		randomtime = Random.Range (0f, 1f);
	}
		
	// Update is called once per frame
	void Update () {

	}

	void AssessValue(){
		
		if (life > 0.5f) {
			state = 1;
			m_renderer.material = black;

		} else {
			state = 0;
			m_renderer.material = white;
		}
	}

	void TranslatePosition(){

		this.transform.position = new Vector3 (locationx*spacing, 0, locationy*spacing);
	}

	public void BuildGround (){
		StartCoroutine (coBuildGround ());
	}

	private IEnumerator coBuildGround (){
		
		if (state == 1) {

			int storeylife = Mathf.RoundToInt (life * 30 - 1);
			int storeywrap = Mathf.RoundToInt(storeylife / 2);
//			Debug.Log (storeylife);
//			Debug.Log (storeywrap);
			for (int y = 0; y < storeylife ; y++) {

				if (y == 0) {
					
					Instantiate (level1, new Vector3 (locationx * spacing, storeyHeight * y, locationy * spacing), Quaternion.identity, this.gameObject.transform);
					yield return null;
				} else if (y > 0 && y < storeylife - 1) {
					
					Instantiate (pilotis, new Vector3 (locationx * spacing, storeyHeight * y, locationy * spacing), Quaternion.identity, this.gameObject.transform);
					if (y == storeywrap||y==storeywrap+2) {
						pilotis.GetComponent<LeCorbPilotis> ().invariantlevel = true;

					} else {
						pilotis.GetComponent<LeCorbPilotis> ().invariantlevel = false;
					}

				} else if(y == storeylife - 1) {
					Instantiate (roof, new Vector3 (locationx * spacing, storeyHeight * y, locationy * spacing), Quaternion.identity, this.gameObject.transform);
					Debug.Log ("roof");
				}
				yield return new WaitForSeconds(0.1f);
			}
			yield return null;
		}
		yield return null;
	}

	void UnBuildStoreys(){
		StartCoroutine (coUnBuildStoreys ());
	}
	private IEnumerator coUnBuildStoreys(){
		
		yield return new WaitForSeconds (randomtime);
		m_renderer.enabled = false;
		yield return null;
	
	}
}