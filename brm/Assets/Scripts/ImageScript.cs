using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour
{

    public string imglink;

    public void imagePausePath()
    {
        //iTween.Pause();
    }

    public void imageResumePath()
    {
        //iTween.Resume();
    }

    public IEnumerator likethatshit()
    {
        WWWForm form = new WWWForm();
        form.AddField("access_token", GameObject.Find("GameController").GetComponent<GameControllerScript>().userToken);
        form.headers["Method"] = "POST";
        form.headers["Accept"] = "applicaton/json";
        form.headers["Date"] = System.DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss zzz");
        WWW www = new WWW("https://api.instagram.com/v1/media/"+ imglink +"/likes", form);
        yield return null;
    }
}
