using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggers : MonoBehaviour {

	public GameObject DialogObj;
	public Text DialogText, ButtonText;

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("adfh");
		if (other.tag == "torch") {
			Debug.Log ("torch");
			DialogObj.SetActive (true);
			DialogText.text = "Это фонарик!";
			ButtonText.text = "Взять фонарик";
		}
		else if (other.tag == "otm") {
			Debug.Log ("otm");
			DialogObj.SetActive (true);
			DialogText.text = "Это отмычка!";
			ButtonText.text = "Взять отмычку";
		}


		else if (other.tag == "door") {
			if (INVENTER.key < 1) {
				Debug.Log ("door1");
				DialogObj.SetActive (true);
				DialogText.text = "Чтобы открыть дверь, надо найти ключ";
				ButtonText.text = "Ладно ";
			} 
			else {
				Debug.Log ("door2");
				DialogObj.SetActive (true);
				DialogText.text = "О, а у меня уже есть ключ от двери!";
				ButtonText.text = "Отрыть дверь";
			}
		}
		else if (other.tag == "shkaf") {
			if(OnClickScript.IsShkafOpen){
				Debug.Log ("skaf3");
				DialogObj.SetActive (true);
				DialogText.text = "Шкаф открыт";
				ButtonText.text = "Посмотреть содержимое";
			}
			else if (INVENTER.otm < 1) {
				Debug.Log ("skaf1");
				DialogObj.SetActive (true);
				DialogText.text = "Чтобы открыть шкаф, нужна отмычка";
				ButtonText.text = "Ладно ";
			} 
			else {
				Debug.Log ("skaf2");
				DialogObj.SetActive (true);
				DialogText.text = "О, а у меня уже есть отмычка!";
				ButtonText.text = "Отрыть шкаф";
			}
		}
	}


	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "torch") {
			DialogObj.SetActive (false);
			DialogText.text = "Это фонарик!";
			ButtonText.text = "Взять фонарик";
		}
		else if (other.tag == "otm") {
			Debug.Log ("otm");
			DialogObj.SetActive (false);
			DialogText.text = "Это отмычка!";
			ButtonText.text = "Взять отмычку";
		}


		else if (other.tag == "door") {
			if (INVENTER.key == 0) {
				Debug.Log ("door1");
				DialogObj.SetActive (false);
				DialogText.text = "Чтобы открыть дверь, надо найти ключ";
				ButtonText.text = "";
			} 
			else {
				Debug.Log ("door2");
				DialogObj.SetActive (false);
				DialogText.text = "О, а у меня уже есть ключ от двери!";
				ButtonText.text = "Отрыть дверь";
			}
		}
		else if (other.tag == "shkaf") {
			if(OnClickScript.IsShkafOpen){
				Debug.Log ("skaf3");
				DialogObj.SetActive (false);
				DialogText.text = "Шкаф открыт";
				ButtonText.text = "Посмотреть содержимое";
			}
			else if (INVENTER.otm == 0) {
				Debug.Log ("skaf1");
				DialogObj.SetActive (false);
				DialogText.text = "Чтобы открыть шкаф, нужна отмычка";
				ButtonText.text = "";
			} 
			else {
				Debug.Log ("skaf2");
				DialogObj.SetActive (false);
				DialogText.text = "О, а у меня уже есть отмычка!";
				ButtonText.text = "Отрыть шкаф";
			}
		}
	}
}
