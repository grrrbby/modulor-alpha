using UnityEngine;
using System.Collections;

public class LeCorbRoof : MonoBehaviour {

	[SerializeField] private LeCorbPilotis m_LeCorbPilotis;
	[SerializeField] private GameObject roof;


	// Use this for initialization
	void Start () {
		Instantiate (roof, m_LeCorbPilotis.roofTransform.position, m_LeCorbPilotis.roofTransform.rotation, m_LeCorbPilotis.roofTransform.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
