using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class Facebook {
	
	private const string LISTENER_GAMEOBJECT_NAME = "FacebookListener";
	
	public static void CreateListener() {
		GameObject fbListener = GameObject.Find(LISTENER_GAMEOBJECT_NAME);
		if(fbListener == null) {
			fbListener = new GameObject(LISTENER_GAMEOBJECT_NAME);
			fbListener.AddComponent<FacebookListener>();
			GameObject.DontDestroyOnLoad(fbListener);
		}
	}
	
	[DllImport("__Internal")]
	private static extern void _fbOpenSession();
	
	public static void OpenSession(string fbAppId) {
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			PlayerPrefs.SetString("fbAppId", fbAppId);
			_fbOpenSession();
		}
	}
	
	[DllImport("__Internal")]
	private static extern void _fbCloseSession();
	
	public static void CloseSession() {
		if(Application.platform == RuntimePlatform.IPhonePlayer)
			_fbCloseSession();
	}
	
	[DllImport("__Internal")]
	private static extern bool _fbHasOpenSession();
	
	public static bool HasOpenSession() {
		if(Application.platform == RuntimePlatform.IPhonePlayer)
			return _fbHasOpenSession();
		return false;
	}
	
	[DllImport("__Internal")]
	private static extern void _fbShowDialog();
	
	public static void ShowDialog() {
		if(Application.platform == RuntimePlatform.IPhonePlayer)
			_fbShowDialog();
	}
	
}
