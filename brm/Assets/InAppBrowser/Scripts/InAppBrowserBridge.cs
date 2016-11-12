using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class InAppBrowserBridge : MonoBehaviour
{

    [System.Serializable]
    public class BrowserLoadingCallback : UnityEvent<string>
    {

    }

    [System.Serializable]
    public class BrowserLoadingWithErrorCallback : UnityEvent<string, string>
    {

    }

    public BrowserLoadingCallback onJSCallback = new BrowserLoadingCallback();

    public BrowserLoadingCallback onBrowserFinishedLoading = new BrowserLoadingCallback();

    public BrowserLoadingWithErrorCallback onBrowserFinishedLoadingWithError = new BrowserLoadingWithErrorCallback();

    public UnityEvent onBrowserClosed = new UnityEvent();

    void OnBrowserJSCallback(string callback)
    {
        Debug.Log("InAppBrowser: JS Message: " + callback);
        onJSCallback.Invoke(callback);
    }

    void OnBrowserFinishedLoading(string url)
    {
        string pattern = "https://www.google.com.ar/#access_token=";
        string token = url;
        token = System.Text.RegularExpressions.Regex.Replace(token, pattern, string.Empty);
        var browser = FindObjectOfType<BrowserLogin>();
        browser.userToken = token;
        browser.tokenTxt.text = "Estas logueado con Instagram! :D";
        bool matchEndPoint = System.Text.RegularExpressions.Regex.IsMatch(url, pattern);
        if (matchEndPoint == true)
        {
            browser.StartCoroutine(browser.closeBrowserAfterXSec(1));
            browser.loginBtn.SetActive(false);
            browser.nextBtn.SetActive(true);

        }
        onBrowserFinishedLoading.Invoke(url);
    }

    void OnBrowserFinishedLoadingWithError(string urlAndError)
    {
        Debug.Log("InAppBrowser: FinishedLoading With Error " + urlAndError);
        string[] parts = urlAndError.Split(',');
        Debug.Log("URL:" + parts[0]);
        Debug.Log("ERROR:" + parts[1]);
        onBrowserFinishedLoadingWithError.Invoke(parts[0], parts[1]);
    }

    void OnBrowserClosed()
    {
        Debug.Log("InAppBrowser: Closed");
        onBrowserClosed.Invoke();
    }
}
