using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrowserLogin : MonoBehaviour
{

    string clientID = "78d3e74cb7b646fab70a8e381c2d487a";
    string redirectUri = "https://www.google.com.ar/";
    public string userToken;
    string igPage;
    public Text tokenTxt;

    void Awake()
    {
        igPage = "https://api.instagram.com/oauth/authorize/?client_id=" + clientID + "&redirect_uri=" + redirectUri + "&response_type=token";
        tokenTxt.text = userToken;
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
}
