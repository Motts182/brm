using UnityEngine;
using System.Collections;

public class ImageMovement : MonoBehaviour {


	public string ImgPath;

	// Use this for initialization
	void Start () {
			

		iTween.MoveTo (gameObject, iTween.Hash("path", iTweenPath.GetPath(ImgPath), "time", 10f, "easetype", iTween.EaseType.easeInOutSine, "looktarget", GameObject.FindGameObjectWithTag("MainCamera").transform));
	}
	

}
