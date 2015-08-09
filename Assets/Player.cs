using UnityEngine;
using System.Collections;

public class Player {
	private string name;
	private bool isBot;
	private int chipCount;
	
	public Player (string name, bool isBot, int chipCount)
	{
		this.name = name;
		this.isBot = isBot;
		this.chipCount = chipCount;
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

	public void setChipCount(int value){
		this.chipCount = value;
	}
}
