using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	float[] y = new float[15];
	float[] x = new float[15];
	bool IsPlayerState = true, RoomImageActivity = false;
	public float scaleX, scaleY, DeadLineLeft, DeadLineRight;
	public GameObject PlayerDefault, PlayerSit, cam, DialogObj, RoomImage, PlayerSprite, RoomImageWithOpenedShkaf, ShkafImage;
	int i = 0, ForRoom = 0;
	public Text DialogText, ButtonTxt;

	void Start () {
		x[0] = transform.localPosition.x;
		y[0] = transform.localPosition.y;
		PlayerSit.SetActive (false);

	}

	void Update () {
		if(ForRoom > 0){
			ForRoom--;
		}
		for(i = 14; i > 0; i--){
			x [i] = x [i - 1];
			y [i] = y [i - 1];
		}
		cam.transform.position = new Vector3 (x[14], y[14], -10f);
		x[0] = transform.localPosition.x;
		y[0] = PlayerSprite.transform.localPosition.y + 2.0035f - 0.8534995f;
		if(transform.localPosition.x < DeadLineLeft){
			transform.position = new Vector3 (DeadLineLeft, y[0], 0f);
			x[0] = DeadLineLeft;
			y[0] = transform.localPosition.y;
		}
		if(transform.localPosition.x > DeadLineRight){
			transform.position = new Vector3 (DeadLineRight, y[0], 0f);
			x[0] = DeadLineRight;
			y[0] = transform.localPosition.y;
		}
		if(ButtonTxt.text != "Далее" && ButtonTxt.text != "Ладно" && OnClickScript.IsPlayerNotStatic && ButtonTxt.text != "Далее "){
			if (Input.GetKey (KeyCode.D)) {
				if(IsPlayerState){
					transform.localScale = new Vector3 (scaleX, scaleY, 1f);
					transform.position = new Vector3 (x[0] + 0.1f, y[0], 0f);
					x[0] = transform.localPosition.x;
					y[0] = transform.localPosition.y;
				}
				else {
					transform.localScale = new Vector3 (scaleX, scaleY, 1f);
					transform.position = new Vector3 (x[0] + 0.06f, y[0], 0f);
					x[0] = transform.localPosition.x;
					y[0] = transform.localPosition.y;
				}
			}

			if (Input.GetKey (KeyCode.A)) {
				if (IsPlayerState) {
					transform.localScale = new Vector3 (-scaleX, scaleY, 1f);
					transform.position = new Vector3 (x[0] - 0.1f, y[0], 0f);
					x[0] = transform.localPosition.x;
					y[0] = transform.localPosition.y;
				} 
				else {
					transform.localScale = new Vector3 (-scaleX, scaleY, 1f);
					transform.position = new Vector3 (x[0] - 0.06f, y[0], 0f);
					x[0] = transform.localPosition.x;
					y[0] = transform.localPosition.y;
				}

			}
			if (Input.GetKey (KeyCode.S)) {
				IsPlayerState = false;
				PlayerSit.SetActive (true);
				PlayerDefault.SetActive (false);
			} 
			else {
				IsPlayerState = true;
				PlayerSit.SetActive (false);
				PlayerDefault.SetActive (true);
			}

			if (Input.GetKey (KeyCode.F) && INVENTER.torch > 0 && ForRoom == 0) {
				RoomImageActivity = !RoomImageActivity;
				RoomImage.SetActive (RoomImageActivity);
				if (OnClickScript.IsShkafOpen) {
					RoomImageWithOpenedShkaf.SetActive (RoomImageActivity);
				} 
				else {
					RoomImageWithOpenedShkaf.SetActive (false);
				}
				ForRoom = 25;
			}
		}
		cam.transform.position = new Vector3 (x[14], y[14], -10f);
	}

}
