using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnInvetarButtonsScript : MonoBehaviour {

	public Text ButtonText, Information;
	public GameObject RightScrollWiew;
	string NameOfObjectOnButton;

	public void OnClickInventarButton(){
		NameOfObjectOnButton = "" + ButtonText.text [0] + ButtonText.text [1] + ButtonText.text [2] + ButtonText.text [3];
		Debug.Log (NameOfObjectOnButton);
		RightScrollWiew.SetActive (false);
		if(NameOfObjectOnButton == "фона"){
			Information.text = "Чтобы влючить или выключить фонарик нажмите F";
		}
		else if(NameOfObjectOnButton == "пист"){
			Information.text = "Это пистолет. Использовать вы его не можете, да это и не нужно. В дальнейшем вы сможете его обменять на что-нибудь";
		}
		else if(NameOfObjectOnButton == "запи"){
			Debug.Log ("ну типо нажатие");
			Information.text = "Чтобы посмотреть текст записки, нажмите на соответствующие кнопки в правой части инвентаря";
			RightScrollWiew.SetActive (true);
		}
		else if(NameOfObjectOnButton == "ключ"){
			Information.text = "Каждый ключ подходит только к одной двери. После использования из инвентаря исчезнет из-за ненадобности";
		}
		else if(NameOfObjectOnButton == "отмы"){
			Information.text = "Отмычкой можно отрывать легкие замки. Использовать отмычку можно только 1 раз";
		}
	}
}
