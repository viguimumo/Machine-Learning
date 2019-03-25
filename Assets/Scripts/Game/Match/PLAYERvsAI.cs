using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERvsAI : Game, Match
{
		public PLAYERvsAI ()
		{
		}

	public void buildEnemyTeam(){
		string gameMode = gameManager.gameMode.Mode;

		if (gameMode.Equals ("Easy")) {
			// Modo de actuar random
		} 
		else if (gameMode.Equals ("Normal")) {
			// Cargar matrices Q entrenadas -> opción random
		} 
		else {
			// Cargar matrices Q entrenadas -> mejor opción
		}
	}

	public void buildPlayerTeam(){
		player = new List<Unit> ();
		string[] playerTeam = gameManager.teamConfig.Team;

		foreach (string unit in playerTeam) {
			switch (unit) {
			case "Healer":
				player.Add (new Healer ());
				break;
			case "Tank":
				player.Add (new Tank ());
				break;
			case "Mele":
				player.Add (new Mele ());
				break;
			case "Distance":
				player.Add (new Distance ());
				break;
			}
		}
	}
	public void nextTurn(){}

}