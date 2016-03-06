using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using MiniJSON;
using System.Text.RegularExpressions;

public class TestPHP : MonoBehaviour {

	public readonly string baseUrl = "http://192.168.33.10/mvctest/";


	IEnumerator GetUserData(string uuid){
		string url = baseUrl + "?uuid=" + uuid;

		WWW www = new WWW(url);

		yield return www;

		if(string.IsNullOrEmpty(www.error)){
			JSONObject rdbUserGet = new JSONObject(www.text);
//			Debug.Log(rdbUserGet);
			for(int i = 0; i < rdbUserGet.Count; ++i) {
			
				JSONObject jsonPos = rdbUserGet[i];
				string jsonUid = jsonPos.GetField("user_id").str;
//				Debug.Log(jsonUid);
				if(jsonUid != ""){
					Application.LoadLevel ("main");
				}
			}




		}

	}

}
