using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	//can also try to make one big string of scores so we just need 1 method in playerprefs to store that string

	const string P1_SCORE_KEY = "player one score";
	const string P2_SCORE_KEY = "player two score";
	const string P3_SCORE_KEY = "player three score";
	const string P4_SCORE_KEY = "player four score";
	const string P5_SCORE_KEY = "player five score";

	public static void SetScore1(int score){
		PlayerPrefs.SetInt (P1_SCORE_KEY, score);
	}

	public static int GetScore1(){
		return PlayerPrefs.GetInt (P1_SCORE_KEY);
	}

	public static void SetScore2(int score){
		PlayerPrefs.SetInt (P2_SCORE_KEY, score);
	}
	
	public static int GetScore2(){
		return PlayerPrefs.GetInt (P2_SCORE_KEY);
	}

	public static void SetScore3(int score){
		PlayerPrefs.SetInt (P3_SCORE_KEY, score);
	}
	
	public static int GetScore3(){
		return PlayerPrefs.GetInt (P3_SCORE_KEY);
	}

	public static void SetScore4(int score){
		PlayerPrefs.SetInt (P4_SCORE_KEY, score);
	}
	
	public static int GetScore4(){
		return PlayerPrefs.GetInt (P4_SCORE_KEY);
	}

	public static void SetScore5(int score){
		PlayerPrefs.SetInt (P5_SCORE_KEY, score);
	}
	
	public static int GetScore5(){
		return PlayerPrefs.GetInt (P5_SCORE_KEY);
	}
}
