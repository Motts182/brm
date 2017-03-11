using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using Facebook.Unity;

public class BrowserLogin : MonoBehaviour
{

    string clientID = "78d3e74cb7b646fab70a8e381c2d487a";
    string redirectUri = "http://blank.org/"; //"http://www.brm.com.co/themes/site_themes/brm_site/default_site/Site_brm.group/img/logo.png";
    public string userToken;
    string igPage;
    string preroutedtoken = "1474921476.78d3e74.533f9347905f4746bf2147d151c48049";
    public Text loginMessage;
    public GameObject nextBtn;
    public GameObject profilePic;
    public GameObject videoManagerLogin;
    public GameObject videoManagerContinue;
    public GameObject loadingWidget;
    public GameObject LoginPopUp;
    public GameObject LoginBtn;
    public Sprite GuestImg;
    public FBscript fbscript;

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
        loadingWidget.SetActive(true);
        LoginPopUp.SetActive(false);
        videoManagerLogin.SetActive(false);
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.backButtonText = "Return";
        options.pageTitle = "Instagram Login";
        options.hidesTopBar = true;
        InAppBrowser.OpenURL(igPage, options);
    }

    public IEnumerator GuestLoginIenum()
    {
        LoginPopUp.SetActive(false);
        WWW wwwguest = new WWW("http://www.brm.com.co/appbrm/token.php");
        yield return wwwguest;
        JsonData dataguest = JsonMapper.ToObject(wwwguest.text);
        GameControllerScript gcs = FindObjectOfType<GameControllerScript>();
        gcs.userToken = dataguest["data"]["token"][0].ToString();
        print(dataguest["data"]["token"][0].ToString());
        videoManagerLogin.SetActive(false);
        LoginBtn.SetActive(false);
        loadingWidget.SetActive(false);
        videoManagerContinue.SetActive(true);
        nextBtn.SetActive(true);
        profilePic.SetActive(true);
        profilePic.GetComponent<Image>().sprite = GuestImg;
        loginMessage.text = "Bienvenido !";
    }

    public void GuestLogin()
    {
        StartCoroutine(GuestLoginIenum());
    }

    public IEnumerator FBLoginIenum()
    {
        fbscript.FBlogin();
        yield return null;
    }

    public void FBLogin()
    {
        StartCoroutine(FBLoginIenum());
    }

    public IEnumerator closeBrowserAfterXSec(int x)
    {
        yield return new WaitForSeconds(x);
        InAppBrowser.CloseBrowser();
        WWW www = new WWW("http://www.brm.com.co/appbrm/index.php?acces_token=" + userToken);
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
        //profilePic.GetComponent<GUITexture>().texture = picTexture;
        profilePic.GetComponent<Image>().sprite = picSprite;

        yield return new WaitForSeconds(2);
        loadingWidget.SetActive(false);
        profilePic.SetActive(true);
        loginMessage.text = "Bienvenido, " + data["data"]["full_name"].ToString() + " !";
    }

    public void getpp()
    {
        StartCoroutine(getProfilePicture());
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

    public void enablePopUp()
    {
        if (!LoginPopUp.activeInHierarchy)
        {
            LoginPopUp.SetActive(true);
        }
        else
        {
            LoginPopUp.SetActive(false);
        }
    }
}
