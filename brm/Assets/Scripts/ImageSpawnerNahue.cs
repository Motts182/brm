using UnityEngine;
using System.Collections;

public class ImageSpawnerNahue : MonoBehaviour {

	public int cantImg;
	public GameObject[] imgRef;


	void Start (){

		for (int i = 0; i < cantImg; i++) {

			GameObject img = Instantiate (imgRef[Random.Range(0,imgRef.Length)], this.transform.position, Quaternion.identity) as GameObject;

			img.GetComponent<ImageMovement> ().ImgPath = "ImagePath" + i;

		}
	}
}
