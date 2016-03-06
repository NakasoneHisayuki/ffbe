using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginManager : TestPHP {

	private string _uuid = "";
	private RegistrationController registrationController;


	// Use this for initialization
	void Start () {

		this.registrationController = GameObject.Find("RegistrationCanvas").GetComponent<RegistrationController>();
		this._uuid = PlayerPrefs.GetString("uuid");
//		PlayerPrefs.DeleteKey("uuid");

		if(this._uuid != ""){

			StartCoroutine("GetUserData",this._uuid);
			return;
		}
		this.SaveUuid();

	}

	private void SaveUuid(){
		System.Guid guid = System.Guid.NewGuid();
		this._uuid = guid.ToString();
		PlayerPrefs.SetString("uuid",_uuid);
		PlayerPrefs.Save();
		StartCoroutine("PostApi");
	}

	IEnumerator PostApi(){

		WWWForm form = new WWWForm();
		form.AddField("uuid", _uuid);

		WWW www = new WWW(baseUrl, form);
		yield return www;

		if (www.error == null) {
			Debug.Log(www.text);
		}
	}

	IEnumerator PostUserData(){
		
		WWWForm form = new WWWForm();

		form.AddField("userName", this.registrationController.userName.text);
		form.AddField("uuid", this._uuid);

		WWW www = new WWW(baseUrl, form);
		yield return www;

		if (www.error == null) {
			Debug.Log(www.text);
		}

		Application.LoadLevel ("main");
	}



}
