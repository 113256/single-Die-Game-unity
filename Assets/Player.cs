using UnityEngine;
using System.Collections;

public class Player {
	private string name;
	private bool isBot;
	private int chipCount;
	private int score;
	
	public Player (string name, bool isBot, int chipCount, int score)
	{
		this.name = name;
		this.isBot = isBot;
		this.chipCount = chipCount;
		this.score = score;

	}
	
	public string getName() {
		return name;
	}
	
	public bool getisBot() {
		return isBot;
	}

	public int getChipCount(){
		return chipCount;
	}

	public int getScore(){
		return score;
	}

	public void setScore(int score){
		this.score = score;
	}

	public void setChipCount(int value){
		this.chipCount = value;
	}
}
