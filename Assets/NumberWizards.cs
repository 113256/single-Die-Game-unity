using UnityEngine;
using System.Collections;
using UnityEngine.UI;//for text class etc.
using System.Threading;
using System.Collections.Generic;
using System.Linq; //collection.Last() method

public class NumberWizards : MonoBehaviour {

/*
This is a simple game where you think of a number, and the computer tries to guess it in as
few tries as possible
*/

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
	Queue<Player> queue =new Queue<Player>();
	
	void Start () {
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
			StartCoroutine(opponentTurn());//but this will run every frame
			}//print ("opponent done");
			//StartCoroutine(opponentTurn());
		} else{
			turns.text = "your turn.";
		}
		
		printQueue(queue);
		queueText.text = queueString;
		

		
		
	}
	//roll
	public void roll(){
		int random = Random.Range (1, 6);

		Player finishedTurn = queue.Peek();
		if(queue.Peek().getisBot()==false){
			print (queue.Peek().getisBot());
			actionText.text = "You rolled "+random;
			
		} 
		else if(queue.Peek ().getisBot()==true) {
			
			actionText.text = queue.Peek().getName()+" rolled "+random;
		}
		queue.Dequeue();
		queue.Enqueue (finishedTurn);

		/*switch (random) {
		case 4:
			Four();
			break;
		case 5:
			Five ();
			break;
		case 6:
			Six ();
			break;
		default:
			break;
		
		}*/
	}


	

	

	IEnumerator opponentTurn() {
	
		//since update is calling this function it will run every frame, to avoid that we have to use a condition
		canCallFunction = false;
		yield return new WaitForSeconds(3);
		canCallFunction = true;
		
		/*random = Random.Range(1, 15);
		Player finishedTurn = queue.Peek();
		if(random%3 ==0){ 
			//number = number - 6;
			//actionText.text = "Opponent subtracted 6";
			
			Four ();
		} else if(random%2 ==0) {
			//number = number - 7;
			//actionText.text = "Opponent subtracted 7";
			Five ();
		} else {
			//number = number - 7;
			//actionText.text = "Opponent subtracted 7";
			Six ();
		}*/
		//MyTurn = !MyTurn;
		//queue.Dequeue();
		//queue.Enqueue (finishedTurn);
		roll ();
	}
	
	public static void printQueue(Queue<Player> collection)
	{
		queueString = "";
		foreach(Player player in collection)
		{
			queueString = queueString + "  " + player.getName() + ": "+ player.getChipCount() +"\n"; 
		}
	
	}
	
	
	

}
