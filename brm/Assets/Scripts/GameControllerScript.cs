using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public string userToken;
    public string hashtag;
    string url;
    string maxLength;
    string minLength;
    public JsonData data;
    List<string> imgLinkList = new List<string>();
    public string videoLink;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("ImageSpawner") != null)
        {
            hashtag = "innovation";
            RequestByHashtag(hashtag);
        }
    }

    public void RequestByHashtag(string hashtag)
    {
        Debug.LogError("requestbyhashtag");
        url = "https://api.instagram.com/v1/tags/" + hashtag + "/media/recent?access_token=" + userToken;
        WWW www = new WWW(url);
        StartCoroutine(WaitforRequest(www));
    }

    public IEnumerator WaitforRequest(WWW www)
    {
        Debug.LogError("WaitforRequest");
        yield return www;
        if (www.error == null)
        {
            JSONParse(www);
        }
        else
        {
            Debug.Log("WWW ERROR !" + www.error);
        }
    }

    public void JSONParse(WWW www)
    {
        Debug.LogError("JSONPARSE");
        data = JsonMapper.ToObject(www.text);
        List<string> listaURLS = new List<string>();
        for (int i = 0; i < 10/*data["data"].Count*/; i++)
        {
            listaURLS.Add(data["data"][i]["images"]["standard_resolution"]["url"].ToString());
            imgLinkList.Add(data["data"][i]["link"].ToString());
        }
        StartCoroutine(cargarListaSprites(listaURLS));
    }

    public IEnumerator cargarListaSprites(List<string> urlList)
    {
        Debug.LogError("cargarlistaSprites");
        List<Sprite> spriteList = new List<Sprite>();
        Sprite spr;
        foreach (string url in urlList)
        {
            WWW imglink = new WWW(url);
            yield return imglink;
            Texture2D texture = new Texture2D(1, 1);
            imglink.LoadImageIntoTexture(texture);
            spr = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            spriteList.Add(spr);
        }
        cargarimgs(spriteList, imgLinkList);
    }

    public void cargarimgs(List<Sprite> spriteList, List<string> imgLinkList)
    {
        Debug.LogError("cargarImgs");
        var imgspawner = GameObject.Find("ImageSpawner").GetComponent<ImgSpawner>();
        imgspawner.spriteList = spriteList;
        imgspawner.imgLinkList = imgLinkList;
        StartCoroutine(imgspawner.Spawn());
    }
}