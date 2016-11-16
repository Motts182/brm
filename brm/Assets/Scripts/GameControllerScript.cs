﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    //[SerializeField]
    //BrowserLogin loginRef;
    public string userToken;
    public string hashtag;
    string url;
    string maxLength;
    string minLength;
    public JsonData data;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        RequestByHashtag("snow");
    }

    public void RequestByHashtag(string hashtag)
    {
        url = "https://api.instagram.com/v1/tags/" + hashtag + "/media/recent?access_token=" + userToken;
        WWW www = new WWW(url);
        StartCoroutine(WaitforRequest(www));
    }

    public IEnumerator WaitforRequest(WWW www)
    {
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
        data = JsonMapper.ToObject(www.text);
        List<string> listaURLS = new List<string>();
        for (int i = 0; i < data["data"].Count; i++)
        {
            listaURLS.Add(data["data"][i]["images"]["standard_resolution"]["url"].ToString());
        }
        StartCoroutine(cargarListaSprites(listaURLS));
        //WWW imglink = new WWW(data["data"][0]["images"]["standard_resolution"]["url"].ToString());
        //Texture2D texture = new Texture2D(1, 1);
        //imglink.LoadImageIntoTexture(texture);
        //Sprite spr = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        //GameObject.Find("img").GetComponent<Image>().sprite = spr;

    }

    public IEnumerator cargarListaSprites(List<string> urlList)
    {
        
        List<Sprite> spriteList = new List<Sprite>();

        foreach (string url in urlList)
        {
            WWW imglink = new WWW(url);
            yield return imglink;
            Texture2D texture = new Texture2D(1, 1);
            imglink.LoadImageIntoTexture(texture);
            Sprite spr = new Sprite();
            spr = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            spriteList.Add(spr);
        }
        cargarimgs(spriteList);
    }

    public void cargarimgs(List<Sprite> s)
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("Word");
        for (int i = 0; i < s.Count; i++)
        {
            a[i].GetComponent<Image>().sprite = s[i];
        }
    }
}
