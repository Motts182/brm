using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class InAppBrowser : System.Object {

	public struct DisplayOptions {
		public string pageTitle;
		public string backButtonText;
		public string barBackgroundColor;
		public string textColor;
		[MarshalAs(UnmanagedType.U1)]
		public bool displayURLAsPageTitle;
		[MarshalAs(UnmanagedType.U1)]
		public bool hidesTopBar;
	}

	public static void OpenURL(string URL) {
		DisplayOptions displayOptions = new DisplayOptions();
		displayOptions.displayURLAsPageTitle = true;
		OpenURL(URL, displayOptions);
	}

	public static void OpenURL(string URL, DisplayOptions displayOptions) {
		#if UNITY_IOS && !UNITY_EDITOR
			iOSInAppBrowser.OpenURL(URL, displayOptions);
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AndroidInAppBrowser.OpenURL(URL, displayOptions); 
		#endif
	}

	public static void CloseBrowser() {
		#if UNITY_IOS && !UNITY_EDITOR 
			iOSInAppBrowser.CloseBrowser();
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AndroidInAppBrowser.CloseBrowser();
		#endif
	}

	public static void ExecuteJS(string JSCommand) {
		#if UNITY_IOS && !UNITY_EDITOR 
			iOSInAppBrowser.ExecuteJS(JSCommand);
		#elif UNITY_ANDROID && !UNITY_EDITOR
			AndroidInAppBrowser.ExecuteJS(JSCommand);
		#endif
	}

	#if UNITY_ANDROID && !UNITY_EDITOR
	private class AndroidInAppBrowser {
		public static void OpenURL(string URL, DisplayOptions displayOptions) {
			var currentActivity = GetCurrentUnityActivity();
			GetInAppBrowserHelper().CallStatic("OpenInAppBrowser", currentActivity, URL, CreateJavaDisplayOptions(displayOptions));                                 
		}

		public static void CloseBrowser() {
			var currentActivity = GetCurrentUnityActivity();
			GetInAppBrowserHelper().CallStatic("CloseInAppBrowser", currentActivity);
		}

		public static void ExecuteJS(string JSCommand) {
			var currentActivity = GetCurrentUnityActivity();
			GetInAppBrowserHelper().CallStatic("SendJSMessage", currentActivity, JSCommand);      
		}

		private static AndroidJavaObject GetCurrentUnityActivity() {
			var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			return currentActivity;
		}

		private static AndroidJavaObject GetInAppBrowserHelper() {
			var helper = new AndroidJavaClass("inappbrowser.kokosoft.com.Helper");
			return helper;
		}

		private static AndroidJavaObject CreateJavaDisplayOptions(DisplayOptions displayOptions) {
			var ajc = new AndroidJavaObject("inappbrowser.kokosoft.com.DisplayOptions");
			if (displayOptions.pageTitle != null) {
				ajc.Set<string>("pageTitle", displayOptions.pageTitle);
			}

			if (displayOptions.backButtonText != null) {
				ajc.Set<string>("backButtonText", displayOptions.backButtonText);
			}

			if (displayOptions.barBackgroundColor != null) {
				ajc.Set<string>("barBackgroundColor", displayOptions.barBackgroundColor);
			}

			if (displayOptions.textColor != null) {
				ajc.Set<string>("textColor", displayOptions.textColor);
			}

			ajc.Set<bool>("displayURLAsPageTitle", displayOptions.displayURLAsPageTitle);
			ajc.Set<bool>("hidesTopBar", displayOptions.hidesTopBar);
			return ajc;
		}

	}
	#endif

	#if UNITY_IPHONE && !UNITY_EDITOR
	private class iOSInAppBrowser {

		[DllImport ("__Internal")]
		private static extern void _OpenInAppBrowser(string URL, DisplayOptions displayOptions);

		[DllImport ("__Internal")]
		private static extern void _CloseInAppBrowser();

		[DllImport ("__Internal")]
		private static extern void _SendJSMessage(string message);

		public static void OpenURL(string URL, DisplayOptions displayOptions) {
			_OpenInAppBrowser(URL, displayOptions);
		}

		public static void CloseBrowser() {
			_CloseInAppBrowser();
		}

		public static void ExecuteJS(string JSCommand) {
			_SendJSMessage(JSCommand);
		}
	}
	#endif
}
