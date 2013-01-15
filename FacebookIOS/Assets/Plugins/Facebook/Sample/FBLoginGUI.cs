using UnityEngine;
using System.Collections;

public class FBLoginGUI : MonoBehaviour
{
	private const string FB_APP_ID = "136228806535961";
	private bool hasSession;

	// Use this for initialization
	void Start ()
	{
		Facebook.CreateListener();
		FacebookListener.onSessionStatusChanged +=OnFbSessionStatusChanged;
		hasSession = false;
	}
	
	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		if(hasSession) {
			if(GUILayout.Button("Logout", GUILayout.MinWidth(200), GUILayout.MinHeight(50))) {
				Facebook.CloseSession();
				hasSession = false;
			}
		}else{
			if(GUILayout.Button("Login", GUILayout.MinWidth(200), GUILayout.MinHeight(50))) {
				Facebook.OpenSession(FB_APP_ID);
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
	}
	
	void OnFbSessionStatusChanged(FacebookSessionStatus status, string errorMessage) {
		if(status == FacebookSessionStatus.Open || status == FacebookSessionStatus.OpenTokenExtended) {
			hasSession = true;
		}else{
			hasSession = false;
			Debug.LogWarning("[FBLoginGUI] Login failed. " + errorMessage);
		}
	}
}

