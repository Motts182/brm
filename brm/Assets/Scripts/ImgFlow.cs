using UnityEngine;
using System.Collections;

public class ImgFlow : MonoBehaviour {

    public string pathName;
    
	void Start () {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 10f, "looktarget", GameObject.FindGameObjectWithTag("MainCamera").transform, "easetype", iTween.EaseType.easeInOutSine));
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.position) <= 2)
        {
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        else
        {
            this.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

    }
	
	
}
