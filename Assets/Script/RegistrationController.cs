using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegistrationController : LoginManager {

	public InputField userName;


	void CtateUserDate(){

	}

	public void OnClickButton(){

//		Debug.Log(this.userName.text);

		StartCoroutine("PostUserData");
	}


}
