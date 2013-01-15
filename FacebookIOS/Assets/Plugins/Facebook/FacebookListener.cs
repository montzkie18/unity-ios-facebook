using UnityEngine;
using System;
using System.Collections;

public enum FacebookSessionStatus {
		Created 			= 0,
		CreatedTokenLoaded 	= 1,
		CreatedOpening 		= 2,
		Open 				= 1 | FacebookListener.FB_SESSIONSTATEOPENBIT,
		OpenTokenExtended 	= 2 | FacebookListener.FB_SESSIONSTATEOPENBIT,
		ClosedLoginFailed 	= 1 | FacebookListener.FB_SESSIONSTATETERMINALBIT,
		Closed 				= 2 | FacebookListener.FB_SESSIONSTATETERMINALBIT
	}

public class FacebookListener : MonoBehaviour {
	
	public const int FB_SESSIONSTATETERMINALBIT = 1 << 8;
	public const int FB_SESSIONSTATEOPENBIT = 1 << 9;
	
	public delegate void FacebookSessionStatusChange(FacebookSessionStatus status, string error);
	public static event FacebookSessionStatusChange onSessionStatusChanged;
	
	public void OnFbSessionStateChanged(string message) {
		string[] messageParts = message.Split('|');
		if(messageParts.Length >= 2) {
			FacebookSessionStatus status = (FacebookSessionStatus)Convert.ToInt32(messageParts[0]);
			string errorMessage = messageParts[1];
			if(onSessionStatusChanged != null)
				onSessionStatusChanged(status, errorMessage);
		}else{
			Debug.LogWarning("[FacebookListener] Received incomplete message from Obj-C : " + message);
		}
	}
}
