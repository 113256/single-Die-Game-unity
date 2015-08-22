using UnityEngine;
using System.Collections;
using UnityEngine.UI;//for text class etc.
using System.Threading;
using System.Collections.Generic;
using System.Linq; //collection.Last() method

public class NumberWizards : MonoBehaviour {

/*
roll 
1. put 1 chip
2. put 2 chips
3. eveybody puts in a chip
4. take 1 chip
5. take 2 chips
6. take all chips, start over
*/

	public bool testMode;

	// Use this for initialization
	//instance variables
	//int max;
	//int min;
	int tableChips;
	bool MyTurn;
	int random;
	static string queueString;
	
	static bool canCallFunction = true;
	//int maxGuessesAllowed = 10;
	
	//guess textbox
	public Text numberText;
	public Text turns;
	public Text actionText;
	public Text queueText;
	
	Player playerOne = new Player("player1", false, 5);
	Player playerTwo = new Player("player2", true, 5);
	Player playerThree = new Player("player3", true, 5);
	Player playerFour = new Player("player4", true, 5);
	Player playerFive = new Player("player5", true, 5);
	
	//MyQueue queue = new MyQueue();
	OwnQueue queue =new OwnQueue();

	private LevelManager levelManager;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		StartGame();
	}
	
	void StartGame () {
		
		tableChips = 0;
		queueString="";
		//MyTurn = true;
		
		queue.Enqueue(playerOne);
		queue.Enqueue(playerTwo);
		queue.Enqueue(playerThree);
		queue.Enqueue(playerFour);
		queue.Enqueue(playerFive);
	}
	
	// Update is called once per frame
	void Update () {
		numberText.text = tableChips.ToString();
		//turn.text = MyTurn ? playerOne.getName() +"Your turn" : "Opponent's turn, please wait";
		if(queue.Peek().getisBot()==true)
		{
			turns.text = queue.Peek().getName()+" turn, please wait";

			if(canCallFunction){//so that it wont run every frame
			StartCoroutine(opponentTurn());//but this will run every frame so we need the if statement above
			}
		} else{
			turns.text = "your turn.";
		}
		
		queueString = queue.printQueue();
		//checkPlayerChips ();

		queueText.text = queueString;
		
		if (tableChips < 0) {
			tableChips = 0;
		}
		
		
	}
	//roll
	public void roll(){
		int random = 0;

		if (testMode) {
			int a = Random.Range (1, 4);
			if (a == 1)
				random = -1;
			else if (a == 2)
				random = -2;
			else random = 1;
		} else {
			 random = Random.Range(1,6);
		}

		//current player
		Player finishedTurn = queue.Peek();
		int currentPlayerChipCount = finishedTurn.getChipCount ();

		if(queue.Peek().getisBot()==false){
			//print (queue.Peek().getisBot());
			actionText.text = "You rolled "+random;
			
		} 
		else if(queue.Peek ().getisBot()==true) {
			
			actionText.text = queue.Peek().getName()+" rolled "+random;
		}
		/*
roll 
1. put 1 chip
2. put 2 chips
3. eveybody puts in a chip
4. take 1 chip
5. take 2 chips
6. take all chips, start over
*/
		switch (random) {
		//test cases
		case -1:
			playerThree.setChipCount(-6);
			break;
		case -2:
			finishedTurn.setChipCount(currentPlayerChipCount-10);
			break;


		case 1:
			finishedTurn.setChipCount(currentPlayerChipCount-1);
			tableChips++;
			break;
		case 2:
			finishedTurn.setChipCount(currentPlayerChipCount-2);
			tableChips+=2;
			break;
		case 3:
			foreach(Player player in queue)
			{
				player.setChipCount(player.getChipCount()-1); 
			}
			tableChips+=5;
			break;
		case 4:
			finishedTurn.setChipCount(currentPlayerChipCount+1);
			tableChips--;
			break;
		case 5:
			finishedTurn.setChipCount(currentPlayerChipCount+2);
			tableChips-=2;
			break;
		case 6:
			levelManager.loadLevel("Start");
			break;
		default:
			break;
		
		}


		//if someome wasn't removed  
		/*if (!checkPlayerChips ()) {

		} else {

		}
		checkPlayerChips ();*/

		//if person removed isnt at the front
		if (checkPlayerChips () != 1) {
			queue.Dequeue();
			queue.Enqueue(finishedTurn);
		}
	}


	

	

	IEnumerator opponentTurn() {
	
		//since update is calling this function it will run every frame, to avoid that we have to use a condition
		canCallFunction = false;
		yield return new WaitForSeconds(2);
		canCallFunction = true;
		
	
		roll ();
	}
	
	/*public void printQueue()
	{
		queueString = "";
		foreach(Player player in queue)
		{

			queueString = queueString + "  " + player.getName() + ": "+ player.getChipCount() +"\n"; 
		}
	
	}*/

	public int checkPlayerChips(){
		//bool playerRemoved = false;
		int position = 0;

		print ("\nchecking");
		foreach(Player player in queue)
		{
			//print (player.getName() + " has"+ player.getChipCount());
			if(player.getChipCount()<=0){
				print ("remove "+player.getName() + " with " + player.getChipCount());
				position = queue.removePlayer(player);
				//playerRemoved = true;
			} 
		}
		queue.checkQueue ();
		//return playerRemoved;
		return position;
		
	}



	
	
	

}
