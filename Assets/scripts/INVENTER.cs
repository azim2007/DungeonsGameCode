using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVENTER : MonoBehaviour {

	public static int torch = PlayerPrefs.GetInt("torch"), key = PlayerPrefs.GetInt("key"), otm = PlayerPrefs.GetInt("otm"), gun = PlayerPrefs.GetInt("gun"), letter = PlayerPrefs.GetInt("letter");
	public static bool[] letters = new bool[10];

}
