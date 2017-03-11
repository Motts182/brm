using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Facebook.Unity;

public class FBscript : MonoBehaviour
{

    void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("logged in");
        }
        else
        {
            Debug.Log("Not Logged In");
        }
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FBlogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
        //FB.API("/oauth/access_token ? client_id =1719113398405346&client_secret=86f53708256bb6de904746895b69afd3&grant_type = client_credentials", HttpMethod.GET, HandleToken);
    }

    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("logged in");
            }
            else
            {
                Debug.Log("Not Logged In");
            }
        }
    }

    void HandleToken(IResult result)
    {
        string token = result.ResultDictionary["access_token"].ToString();
    }
}
