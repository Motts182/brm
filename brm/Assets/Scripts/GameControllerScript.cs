﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public string userToken;
    public string hashtag;
    string url;
    public JsonData data;
    JsonData data2;
    JsonData data3;
    List<string> listaLinkImgs = new List<string>();
    List<string> listaURLS = new List<string>();
    public string videoLink;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("ImageSpawner") != null)
        {
            print("start");
            //hashtag = "innovation";
            RequestByHashtag(hashtag);
        }
        /*if (userToken != null || userToken != "")
        {
            if (SceneManager.GetActiveScene().name == "login")
            {
                SceneManager.LoadScene("SphereScene");
            }
        }*/

        if (listaLinkImgs.Count != 0)
        {
            listaLinkImgs.Clear();
            listaURLS.Clear();
        }
    }

    public void RequestByHashtag(string hashtag)
    {
        print("Request by hashtag: " + hashtag);
        url = "https://api.instagram.com/v1/tags/" + hashtag + "/media/recent?access_token=" + userToken;
        WWW www = new WWW(url);
        StartCoroutine(WaitforRequest(www));
    }

    public IEnumerator WaitforRequest(WWW www)
    {
        print("WAITFORREQUEST");

        yield return www;
        if (www.error == null)
        {
            StartCoroutine(JSONParse(www));
        }
        else
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
    }

    public IEnumerator JSONParse(WWW www)
    {
        print("JSONPARSE");

        data = JsonMapper.ToObject(www.text);
        if (SceneManager.GetActiveScene().name == "ImageRiver3")
        {
            WWW www2 = new WWW(data["pagination"]["next_url"].ToString());
            yield return www2;
            if (www2.error == null)
            {
                data2 = JsonMapper.ToObject(www2.text);
            }
            else
            {
                print("Error en WWW2: " + www2.error);
            }
            for (int i = 0; i < data2["data"].Count; i++)
            {
                listaURLS.Add(data2["data"][i]["images"]["low_resolution"]["url"].ToString());
                listaLinkImgs.Add(data2["data"][i]["link"].ToString());
            }
        }
        for (int i = 0; i < data["data"].Count; i++)
        {
            listaURLS.Add(data["data"][i]["images"]["low_resolution"]["url"].ToString());
            listaLinkImgs.Add(data["data"][i]["link"].ToString());
        }
        StartCoroutine(cargarListaSprites(listaURLS));
    }

    public IEnumerator cargarListaSprites(List<string> urlList)
    {
        print("CARGARLISTA");

        List<Sprite> spriteList = new List<Sprite>();
        Sprite spr;
        int i = 1;
        foreach (string url in urlList)
        {
            WWW imglink = new WWW(url);
            yield return imglink;
            print("Progreso de carga de imagenes: " + (i + "/" + urlList.Count));
            i++;
            Texture2D texture = new Texture2D(1, 1);
            imglink.LoadImageIntoTexture(texture);
            spr = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            spriteList.Add(spr);
        }
        cargarimgs(spriteList, listaLinkImgs);
    }

    public void cargarimgs(List<Sprite> spriteList, List<string> imgLinkList)
    {
        print("CARGARIMGS");

        var imgspawner = GameObject.Find("ImageSpawner").GetComponent<ImgSpawner>();
        imgspawner.spriteList = spriteList;
        imgspawner.imgLinkList = imgLinkList;
        StartCoroutine(imgspawner.Spawn());
    }

}