using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testimgscript : MonoBehaviour
{
    private string userToken;
    public GameObject profilePic;
    public Text loginMessage;

    public IEnumerator profilepic()
    {
        WWW request = new WWW("https://api.instagram.com/v1/users/self/?access_token=" + userToken);
        yield return request;
        JsonData data = JsonMapper.ToObject(request.text);
        WWW request2 = new WWW(data["data"]["profile_picture"].ToString());
        yield return request2;
        Texture2D picTexture = new Texture2D(1, 1);
        request2.LoadImageIntoTexture(picTexture);
        //Sprite picSprite = Sprite.Create(picTexture, new Rect(0, 0, picTexture.width, picTexture.height), new Vector2(0.5f, 0.5f));
        profilePic.AddComponent<SpriteRenderer>();
        profilePic.GetComponent<SpriteRenderer>().material.mainTexture = picTexture;
        profilePic.SetActive(true);
        //panelPic.SetActive(true);
        //panelLogin.SetActive(false);
        loginMessage.text = "Welcome, " + data["data"]["full_name"].ToString() + " !";
    }
}
