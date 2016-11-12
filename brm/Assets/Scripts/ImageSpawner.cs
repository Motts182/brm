using UnityEngine;
using System.Collections;

public class ImageSpawner : MonoBehaviour {

	public int cantImg;
	public GameObject[] imgRef;


	void Start (){
	
		for (int i = 0; i < cantImg; i++) {

			GameObject img = Instantiate (imgRef[Random.Range(0,2)], this.transform.position, Quaternion.identity) as GameObject;

			img.GetComponent<ImageMovement> ().ImgPath = "ImagePath" + i;

		}
	}
}
