using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour {
//
//	//Here we declare the scope of our world.
//	public static int lengthMax = 100;
//	public static int heightMax = 100;
//	public static int widthMax = 100;
//	public static int[,,] field = new int[lengthMax,heightMax,widthMax];
//
//	//Here we declare the variables for laying structural columns.
//	public int pilotisLength;
//	public int pilotisWidth;
//	public int pilotisHeight;
//	public int pilotisHeightSpacing;
//	public int pilotisHash;
//
//	[SerializeField] public int storeys;
//	public int spacing;
//
//	//Here we declare the variable for laying slabs atop our stuctural columns.
//	public int slabLength = 10;
//	public int slabWidth = 10;
//
//	public Transform gridMarker;
//	public Transform slab;
//	public Transform pilotis;
//
//	public bool scaleDecision = false;
//
//	private int fibonaci;
//	private float fibonaciLate;
//	private int sequence = 0;
//
//
//	// Use this for initialization
//	void Start () {
//
//		pilotisLength = Random.Range(1,12);
//		pilotisWidth = Random.Range(1,12);
//		pilotisHeight = Random.Range(1,30);
//		pilotisHeightSpacing = 6;
//		spacing = Random.Range(3,30);
//
//		StartCoroutine (GeneratePilotis ());
//	}
//
//
////	private IEnumerator GenerateScope(){	//	Here we generate our scope using the variables declared.
////		for (int x = 0; x < lengthMax; x++) {
////				for (int y = 0; y < heightMax; y++) {
////					for (int z = 0; z < heightMax; z++) {
////						Instantiate (gridMarker, new Vector3 (x, y, z), Quaternion.identity);
////						yield return null;
////					}
////				}
////			}
////
////			yield return null;
////
////
////	}
//
//
//
//	private IEnumerator GeneratePilotis(){
//		scaleDecision = true;
//		for (int y = 0; y < pilotisHeight; y++) {
//			storeys += 1;
//			for (int x = 0; x < pilotisLength; x++) {
//				for (int z = 0; z < pilotisWidth; z++) {
//					if (x == 0 || x == pilotisLength - 1 || z == 0 || z == pilotisWidth - 1) {
//						pilotisHash = Random.Range (0, 1);
//						Instantiate (pilotis, new Vector3 (x * spacing, y *pilotisHeightSpacing, z * spacing), Quaternion.identity);
//						yield return new WaitForSeconds (0.01f);
//					}
//					yield return null;
//				}
//			}
//		}
//
//		yield return null;
//	
//	}
//		
//
//
//	private IEnumerator GenerateSlab(){
//
//		for (int x = 0; x < slabLength; x++) {
//			for (int z = 0; z < slabWidth; z++) {
//					Instantiate (slab, new Vector3 (x, 0, z), Quaternion.identity);
//					yield return null;
//			}
//		}
//
//		yield return null;
//	}
//
//	private IEnumerator LoadScene(){
//		yield return new WaitForSeconds (3f);
//		SceneManager.LoadScene (0);
//		yield return null;
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//		sequence += 1;
//
//		if (storeys == pilotisHeight) {
//			StartCoroutine (LoadScene ());
//		}
//
//		if (Input.GetButtonDown ("Fire1")) {
//			SceneManager.LoadScene (0);
//		}
//	
//	}
//
//	void LateUpdate(){
//
//		fibonaci += (sequence + fibonaci);
//		Debug.Log (fibonaci);
//
//	}
}
