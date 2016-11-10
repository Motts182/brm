using UnityEngine;
using System.Collections;

public class ImageSpawner : MonoBehaviour {

	public int cantImg;
	public GameObject ImgRef;


	void Start (){
	
		for (int i = 1; i <= cantImg; i++) {

			GameObject img = Instantiate (ImgRef, this.transform.position, Quaternion.identity) as GameObject;

			img.GetComponent<ImageMovement> ().ImgPath =  "ImagePath" + i;

		}
	}
}
