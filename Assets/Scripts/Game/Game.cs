using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	protected GameManager gameManager;
	protected int[,] map;

	private Match match;

	protected List<Unit> player;
	protected List<Unit> AI;

	void Awake(){
	}

	void Start () {
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();
		map = GameObject.Find ("Map").GetComponent<MapGenerator> ().TileMap ();

		initialize ();
	}

	private void initialize(){
		if (gameManager.gameType.Equals (GameType.AI_vs_AI)) {
			match = new AIvsAI ();
		} 
		else if (gameManager.gameType.Equals (GameType.PLAYER_vs_AI)) {
			match = new PLAYERvsAI ();
		} 
		else {
			match = new TRAINING ();
		}

		placeUnits ();
		buildTurns ();
	}

	private void buildTurns(){
	}

	private void placeUnits(){
		
	}
	
	void Update () {
		
	}
}
