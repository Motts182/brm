using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMovement : MonoBehaviour
{
    public string ImgPath;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(ImgPath), "time", 10f,"loopType", "loop", "easetype", iTween.EaseType.easeInOutSine, "looktarget", GameObject.FindGameObjectWithTag("MainCamera").transform));
    }

    private void FixedUpdate()
    {
        if(GameObject.Find("MainCamera") != null)
        {
            if (Vector3.Distance(this.gameObject.transform.position, GameObject.Find("MainCamera").transform.position) >= 5)
            {
                GetComponentInChildren<Image>().enabled = false;
            }
            else
            {
                GetComponentInChildren<Image>().enabled = true;
            }
        }
    }
}
