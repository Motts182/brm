using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    //[SerializeField]
    //BrowserLogin loginRef;
    public string userToken;
    string hashtag;
    string url;
    string maxLength;
    string minLength;
    public JsonData data;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        RequestByHashtag("snow");
    }

    public IEnumerator WaitforRequest(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            Debug.Log("WWW OK!");
            JSONParse(www);
        }
        else
        {
            Debug.Log("WWW ERROR !");
        }
    }

    public void RequestByHashtag(string hashtag)
    {
        url = "https://api.instagram.com/v1/tags/" + hashtag + "/media/recent?access_token=" + userToken;
        WWW www = new WWW(url);
        StartCoroutine(WaitforRequest(www));
    }

    void JSONParse(WWW www)
    {
        //print(www.text);
        data = JsonMapper.ToObject(www.text);
        WWW imglink = new WWW(data["data"][0]["images"]["standard_resolution"]["url"].ToString());
        
    }

}
