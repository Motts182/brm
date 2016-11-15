using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrowserLogin : MonoBehaviour
{

    string clientID = "e2b157c42b814567a3fd7d4d133f2890";
    string redirectUri = "http://www.brm.com.co/themes/site_themes/brm_site/default_site/Site_brm.group/img/logo.png";
    private string userToken;
    string igPage;
    public Text tokenTxt;
    public GameObject loginBtn;
    public GameObject nextBtn;



    void Awake()
    {
        igPage = "https://api.instagram.com/oauth/authorize/?client_id=" + clientID + "&redirect_uri=" + redirectUri + "&response_type=token";
        tokenTxt.text = userToken;
        nextBtn.SetActive(false);
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

    public IEnumerator getprofilepic()
    {
        WWW request = new WWW("https://api.instagram.com/v1/users/self/?access_token=" + userToken);
        yield return request;

    }

    void GetToken()
    {
        if (userToken != null)
        {
            GameControllerScript gcs = FindObjectOfType<GameControllerScript>();
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
