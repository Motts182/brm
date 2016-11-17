using UnityEngine;
using System.Collections;

public class ImageMovement : MonoBehaviour
{
    public string ImgPath;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(ImgPath), "time", 10f, "easetype", iTween.EaseType.easeInOutSine, "looktarget", GameObject.FindGameObjectWithTag("MainCamera").transform));
    }

    //void Update()
    //{
    //    if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.position) <= 2)
    //    {
    //        this.GetComponentInChildren<MeshRenderer>().enabled = false;
    //    }
    //    else
    //    {
    //        this.GetComponentInChildren<MeshRenderer>().enabled = true;
    //    }

    //}

}
