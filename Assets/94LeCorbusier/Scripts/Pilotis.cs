using UnityEngine;
using System.Collections;

/* 
Frame			Storey Level			Column Size (mm)
10-Storey			1-10					700x700

20-Storey			1-7						750x750
					8-14					600x600
					15-20					450x450

30-Storey			1-10					800x800
					11-20					650x650
					21-30					470x470

*/
public class Pilotis : MonoBehaviour {
//
//	private float storeys;
//	private Vector3 one = new Vector3(3,3,3);
//	private Vector3 two = new Vector3(2.25f,3,2.25f);
//	private Vector3 thirty = new Vector3(1.5f,3,1.5f);
//	private Vector3 forty = new Vector3 (1, 3, 1);
//
//	private float yPosition;
//
//	[SerializeField] private Grid m_Grid;
//	[SerializeField] private float[] colors = new float[4]{255,255,255,255};// R0 G1 B2 A3
//	[SerializeField] private Color colorRGB;
//	[SerializeField] private int zeroR = 0;
//	[SerializeField] private int oneG = 1;
//	[SerializeField] private int twoB = 2;
//	[SerializeField] private int threeA = 3;
//	[SerializeField] private int pilotisSeed;
//
//	void Start(){
//		pilotisSeed = m_Grid.pilotisHash;		
//		StartCoroutine (ChooseColor ());
//		colorRGB = new Color (colors[zeroR], colors[oneG], colors[twoB], colors[threeA]);
//	}
//
//	private IEnumerator ChooseColor(){
//	
//		for (int i = 0; i < colors.Length; i++) {
//			colors [i] = Random.Range (100, 255);
//			if (colors [i] > 177) {
//				colors [i] = Mathf.Lerp (colors [i], 255, 0.5f);
//				colors [i] = colors [i] / 255;
//			} else {
//				colors [i] = Mathf.Lerp (colors [i], 100, 0.5f);
//				colors [i] = colors [i] / 255;
//				}
//			
//			colorRGB = new Color (colors[zeroR], colors[oneG], colors[twoB], colors[threeA]);
//			this.gameObject.GetComponentInChildren<Renderer> ().material.color = colorRGB;
//			yield return null;
//		}
//
//	}
//
//	void Update(){
//		if (m_Grid.scaleDecision) {
//			StartCoroutine (ScaleDecision ());
//		}
//	}
//
//
//
//	private IEnumerator ScaleDecision(){
//
//		yPosition = this.gameObject.transform.position.y;
//		storeys = this.gameObject.transform.position.y;
//
//
//			if (yPosition >= 0*m_Grid.pilotisHeightSpacing && yPosition < 8*m_Grid.pilotisHeightSpacing) {
//			this.gameObject.transform.localScale = one;
//
//			}
//			if (yPosition > 7*m_Grid.pilotisHeightSpacing && yPosition < 15*m_Grid.pilotisHeightSpacing) {
//			this.gameObject.transform.localScale = two;
//
//			}
//			if (yPosition > 14*m_Grid.pilotisHeightSpacing && yPosition < 21*m_Grid.pilotisHeightSpacing) {
//				this.gameObject.transform.localScale = thirty;
//
//			}	
//		if (yPosition > 20*m_Grid.pilotisHeightSpacing && yPosition < 31*m_Grid.pilotisHeightSpacing) {
//			this.gameObject.transform.localScale = forty;
//
//		}	
//
//
//		yield return null;
//	}

}

