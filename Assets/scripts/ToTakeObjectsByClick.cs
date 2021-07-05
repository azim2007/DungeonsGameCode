using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToTakeObjectsByClick : MonoBehaviour {

	public string name, firstReplic = "Вы: Хммм... В записке, что я нашел в шкафу говорилось:";
	public Text DialogText, DialogButtonText;
	public GameObject Dialog, DialogButton, ItSelf;
	// Use this for initialization
	void OnMouseEnter(){
		Dialog.SetActive (true);
		DialogButton.SetActive (false);
		if (name == "записка 1" || name == "пистолет") {
			DialogText.text = "Это " + name + ". Чтобы взять, кликните на объект";
		} 
		else {
			DialogText.text = "Это " + name;
		}

		Debug.Log (name);
	}
	void OnMouseExit(){
		DialogButton.SetActive (true);
		Dialog.SetActive (false);
		Debug.Log ("exit" + name);
	}
	void OnMouseUpAsButton(){
		DialogButton.SetActive (true);
		Dialog.SetActive (false);
		if (name == "пистолет") {
			INVENTER.gun++;
			GameObject.Destroy (ItSelf);
		}
		else if (name == "записка 1") {
			INVENTER.letter++;
			INVENTER.letters [0] = true;
			GameObject.Destroy (ItSelf);
		}
		else if (name == "группа \"The Rolling Stones\"" && INVENTER.letters[0]) {
			DialogButton.SetActive (true);
			ItSelf.SetActive (false);
			Dialog.SetActive (true);
			DialogButtonText.text = "Далее ";
			DialogText.text = firstReplic;
		}


	}
}
