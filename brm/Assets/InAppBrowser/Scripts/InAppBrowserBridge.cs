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
        string pattern = "http://blank.org/#access_token="; //"http://www.brm.com.co/themes/site_themes/brm_site/default_site/Site_brm.group/img/logo.png#access_token=";
        string token = url;
        token = System.Text.RegularExpressions.Regex.Replace(token, pattern, string.Empty);
        var browser = FindObjectOfType<BrowserLogin>();
        browser.UserToken = token;
        bool matchEndPoint = System.Text.RegularExpressions.Regex.IsMatch(url, pattern);
        if (matchEndPoint == true)
        {
            browser.StartCoroutine(browser.closeBrowserAfterXSec(1));
            browser.nextBtn.SetActive(true);
            browser.videoManagerContinue.SetActive(true);
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
