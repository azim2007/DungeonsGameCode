using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OnClickScript : MonoBehaviour {

	int DialogIndex = 0, RollingStonesDialodIndex = -1;
	public string[] dialogs, TextsOfAllLetters, RollingStonesDialog;
	public Text[] InventarButtonsText;
	public GameObject[] InventarButtons, LetterButtons;
	public GameObject DialogObj, torch, mainMenu, secondMenu, otm, RoomImageWithOpenedShkaf, RoomImage, ShkafImage, ExitButton, Player, ButtonObj, inventar, InventarButtonObj, AllPictures, RightScrollWiew, LetterText, CutRollingStones;
	public int NumberOfScene;
	public Text ButtonText, ExitButtonText, DialogText, LetterTextText;
	public static bool IsShkafOpen = false, IsPlayerNotStatic = true;

	void Start(){
		if (NumberOfScene == 0) {
			secondMenu.SetActive (false);
		} 
		else if (NumberOfScene == 1) {
			DialogText.text = dialogs [DialogIndex];
			RoomImageWithOpenedShkaf.SetActive (false);
			RoomImage.SetActive (false);
			ShkafImage.SetActive (false);
			inventar.SetActive (false);
			CutRollingStones.SetActive (false);
			PlayerPrefs.SetInt ("NumberScene", 0);
			for(int i = 0; i < INVENTER.letters.Length; i++){
				INVENTER.letters [i] = false;
			}
		} 
		else if (NumberOfScene == 2) {
			DialogText.text = dialogs [DialogIndex];
			RoomImage.SetActive (false);
			inventar.SetActive (false);
			PlayerPrefs.SetInt ("NumberScene", 1);
			INVENTER.gun = PlayerPrefs.GetInt ("gun");
			INVENTER.torch = PlayerPrefs.GetInt ("torch");
			INVENTER.key = PlayerPrefs.GetInt ("key");
			INVENTER.otm = PlayerPrefs.GetInt ("otm");
			INVENTER.letter = PlayerPrefs.GetInt("letter");
			if(PlayerPrefs.GetInt("NumberScene") > 0){
				for(int i = 0; i < INVENTER.letters.Length; i++){
					if(PlayerPrefs.GetString("letters")[i] == 't'){
						INVENTER.letters [i] = true;
					}
					else if(PlayerPrefs.GetString("letters")[i] == 'f'){
						INVENTER.letters [i] = false;
					}
				}
			}
		}
	}
	public void ToScene1(){
		SceneManager.LoadScene (PlayerPrefs.GetInt("NumberScene") + 1);
		INVENTER.gun = PlayerPrefs.GetInt ("gun");
		INVENTER.torch = PlayerPrefs.GetInt ("torch");
		INVENTER.key = PlayerPrefs.GetInt ("key");
		INVENTER.otm = PlayerPrefs.GetInt ("otm");
		INVENTER.letter = PlayerPrefs.GetInt("letter");
		if(PlayerPrefs.GetInt("NumberScene") > 0){
			for(int i = 0; i < INVENTER.letters.Length; i++){
				if(PlayerPrefs.GetString("letters")[i] == 't'){
					INVENTER.letters [i] = true;
				}
				else if(PlayerPrefs.GetString("letters")[i] == 'f'){
					INVENTER.letters [i] = false;
				}
			}
		}
	}

	public void DialogButton(){
		if (ButtonText.text == "Далее") {
			if (dialogs.Length >= (DialogIndex + 2)) {
				DialogIndex++;
				DialogText.text = dialogs [DialogIndex];
				//Debug.Log ("" + dialogs.Length);
				//Debug.Log ("" + DialogIndex);
			} else {
				//Debug.Log ("dfjghwrtfgjgh");
				DialogObj.SetActive (false);
				ButtonText.text = "";
			}
		} 
		else if (ButtonText.text == "Далее ") {
			if (RollingStonesDialog.Length >= (RollingStonesDialodIndex + 2)) {
				RollingStonesDialodIndex++;
				DialogText.text = RollingStonesDialog[RollingStonesDialodIndex];
				if(RollingStonesDialodIndex == 2){
					ButtonText.text = "Порвать";
				}
			} 
			else {
				//Debug.Log ("dfjghwrtfgjgh");
				DialogObj.SetActive (false);
				ButtonText.text = "";
				INVENTER.key++;
			}
		}
		else if (ButtonText.text == "Порвать") {
			RollingStonesDialodIndex++;
			DialogText.text = RollingStonesDialog[RollingStonesDialodIndex];
			ButtonText.text = "Далее ";
			CutRollingStones.SetActive (true);
		}
		else if (ButtonText.text == "Взять фонарик") {
			//Debug.Log ("Ajrthghtut");
			torch.SetActive(false);
			INVENTER.torch++;
			ButtonText.text = "Ладно";
			DialogText.text = "Чтобы влючить или выключить фонарик нажмите F";
			DialogObj.SetActive (true);
		}
		else if (ButtonText.text == "Ладно" || ButtonText.text == "Ладно ") {
			DialogObj.SetActive (false);
			ButtonText.text = "";
		}
		else if (ButtonText.text == "Отрыть дверь") {
			//Debug.Log ("Ajrthghtut");
			SceneManager.LoadScene(2);
			SaveGame (1);
			INVENTER.key--;
			DialogObj.SetActive (false);
		}
		else if (ButtonText.text == "Взять отмычку") {
			//Debug.Log ("Ajrthghtut");
			otm.SetActive(false);
			INVENTER.otm++;
			DialogObj.SetActive (false);
		}
		else if (ButtonText.text == "Отрыть шкаф") {
			Debug.Log ("Шкаф открыт");
			RoomImageWithOpenedShkaf.SetActive (true);
			//RoomImage.SetActive (false);
			INVENTER.otm--;
			IsShkafOpen = true;
			DialogText.text = "Шкаф открыт";
			ButtonText.text = "Посмотреть содержимое";
			DialogObj.SetActive (true);
		}
		else if (ButtonText.text == "Посмотреть содержимое") {
			AllPictures.SetActive (false);
			ShkafImage.SetActive (true);
			transform.position = new Vector3 (0f, 0f, -10f);
			ExitButtonText.text = "Обратно в комнату";
			//RoomImageWithOpenedShkaf.SetActive (false);
			//RoomImage.SetActive (false);
			DialogObj.SetActive (false);
			Player.SetActive (false);
		}
	}

	public void ExitButtonFunc(){
		if (ExitButtonText.text == "В меню") {
			SceneManager.LoadScene (0);
		} 
		else if (ExitButtonText.text == "Обратно в комнату") {
			AllPictures.SetActive (true);
			ShkafImage.SetActive (false);
			ExitButtonText.text = "В меню";
			RoomImageWithOpenedShkaf.SetActive (true);
			RoomImage.SetActive (false);
			DialogObj.SetActive (false);
			Player.SetActive (true);
			ButtonObj.SetActive (true);
		}
		else if (ExitButtonText.text == "Выйти из инвентаря") {
			AllPictures.SetActive (true);
			ExitButtonText.text = "В меню";
			inventar.SetActive (false);
			//DialogObj.SetActive (false);
			Player.SetActive (true);
			InventarButtonObj.SetActive (true);
			ShkafImage.SetActive (false);
			ButtonObj.SetActive (true);
		}
	}
	public void SecondMenuButton(){
		secondMenu.SetActive (true);
		mainMenu.SetActive (false);
		DialogText.text = "D - направо\nA - налево\nS - присесть(спрятаться за объектом)\nо назначении других кнопок вы узнаете в процессе игры";
	}
	public void MainMenuButton(){
		secondMenu.SetActive (false);
		mainMenu.SetActive (true);
	}
	public void InventarButton(){
		int i = 0;
		RightScrollWiew.SetActive (false);
		LetterText.SetActive (false);
		AllPictures.SetActive (false);
		Player.SetActive (false);
		inventar.SetActive (true);
		InventarButtonObj.SetActive (false);
		transform.position = new Vector3 (0f, 0f, -10f);
		ExitButtonText.text = "Выйти из инвентаря";
		for(i = 0; i < InventarButtons.Length; i++){
			InventarButtons [i].SetActive (true);
		}
		i = 0;
		if(INVENTER.key > 0){
			InventarButtonsText [i].text = "ключ - " + INVENTER.key + " шт.";
			i++;
		}
		if (INVENTER.gun > 0) {
			InventarButtonsText [i].text = "пистолет - " + INVENTER.gun + " шт.";
			i++;
		}
		if (INVENTER.torch > 0) {
			InventarButtonsText [i].text = "фонарик - " + INVENTER.torch + " шт.";
			i++;
		}
		if (INVENTER.otm > 0) {
			InventarButtonsText [i].text = "отмычка - " + INVENTER.otm + " шт.";
			i++;
		}
		if (INVENTER.letter > 0) {
			InventarButtonsText [i].text = "записка - " + INVENTER.letter + " шт.";
			i++;
		}
		for (i = i; i < InventarButtons.Length; i++) {
			InventarButtons [i].SetActive (false);
		}
	}
	public void LetterButtonsFunc(int NameInt){
		LetterText.SetActive (true);
		if (INVENTER.letters [NameInt]) {
			LetterTextText.text = TextsOfAllLetters [NameInt];
		} 
		else {
			LetterTextText.text = "У вас еще нет этой записки";
		}
	}
	public void ToCloseLetter(){
		LetterText.SetActive (false);
	}
	public void AboutGameButton(){
		secondMenu.SetActive (true);
		mainMenu.SetActive (false);
		DialogText.text = "Короче, выходя из каждой комнаты в нее вы вернуться не сможете. Сохранения происходят только автоматически тогда, когда вы переходите в новую комнату, иначе никак, ибо разраб ленивый. Короче если у вас был какой-то прогресс в комнате, но вы вышли из игры, то комнату придется проходить заново. Кнопка \"В меню\" в игре ведет в это меню, когда вы нажмете кнопку \"играть\" в этом меню игра начнется с комнаты, последней в сохранениях.";
	}
	public void SaveGame(int NumSc){
		PlayerPrefs.SetInt ("NumberScene", NumSc);
		PlayerPrefs.SetInt ("gun", INVENTER.gun);
		PlayerPrefs.SetInt ("torch", INVENTER.torch);
		PlayerPrefs.SetInt ("key", INVENTER.key);
		PlayerPrefs.SetInt ("otm", INVENTER.otm);
		PlayerPrefs.SetInt ("letter", INVENTER.letter);
		for (int i = 0; i < INVENTER.letters.Length; i++) {
			if (INVENTER.letters [i]) {
				PlayerPrefs.SetString ("letters", PlayerPrefs.GetString ("letters") + "t");
			} 
			else {
				PlayerPrefs.SetString ("letters", PlayerPrefs.GetString ("letters") + "f");
			}
		}
		Debug.Log (PlayerPrefs.GetString("letters"));
	}
	public void DeleteProgress(){
		PlayerPrefs.DeleteAll ();
	}
}
