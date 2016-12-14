﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;

public class BrowserLogin : MonoBehaviour
{

    string clientID = "78d3e74cb7b646fab70a8e381c2d487a";
    string redirectUri = "http://www.brm.com.co/themes/site_themes/brm_site/default_site/Site_brm.group/img/logo.png";
    private string userToken;
    string igPage;
    public Text loginMessage;
    public GameObject loginBtn;
    public GameObject nextBtn;
    public GameObject profilePic;
    public GameObject videoManagerLogin;
    public GameObject videoManagerContinue;

    void Awake()
    {
        igPage = "https://api.instagram.com/oauth/authorize/?client_id=" + clientID + "&redirect_uri=" + redirectUri + "&response_type=token&scope=public_content";
        nextBtn.SetActive(false);
        profilePic.SetActive(false);
        videoManagerLogin.SetActive(true);
        videoManagerContinue.SetActive(false);
    }

    public void InstagramLogin()
    {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.backButtonText = "Return";
        options.pageTitle = "Instagram Login";
        options.hidesTopBar = true;
        InAppBrowser.OpenURL(igPage, options);
    }

    public IEnumerator closeBrowserAfterXSec(int x)
    {
        yield return new WaitForSeconds(x);
        InAppBrowser.CloseBrowser();
    }

    public IEnumerator getProfilePicture()
    {
        WWW request = new WWW("https://api.instagram.com/v1/users/self/?access_token=" + userToken);
        yield return request;
        JsonData data = JsonMapper.ToObject(request.text);
        WWW request2 = new WWW(data["data"]["profile_picture"].ToString());
        yield return request2;
        Texture2D picTexture = new Texture2D(1, 1);
        request2.LoadImageIntoTexture(picTexture);
        Sprite picSprite = Sprite.Create(picTexture, new Rect(0, 0, picTexture.width, picTexture.height), new Vector2(0.5f, 0.5f));
        profilePic.GetComponent<Material>().mainTexture = picTexture;
        //profilePic.SetActive(true);
        videoManagerLogin.SetActive(false);
        videoManagerContinue.SetActive(true);
        loginMessage.text = "Welcome, " + data["data"]["full_name"].ToString() + " !";
    }

    void GetToken()
    {
        if (userToken != null)
        {
            GameControllerScript gcs = FindObjectOfType<GameControllerScript>();
            StartCoroutine(getProfilePicture());
            gcs.userToken = userToken;
        }
    }
    public string UserToken
    {
        set
        {
            userToken = value;
            GetToken();
        }
    }
}
