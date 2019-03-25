using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public GameType gameType;
	public KGameMode gameMode;
	public KTeamConfig teamConfig;

	void Awake(){
		if (gameManager == null) {
			gameManager = this;
			DontDestroyOnLoad (transform.gameObject);

			gameMode = new KGameMode ();
			teamConfig = new KTeamConfig ();

			reinitialize ();
		} else 
		{
			Destroy (gameObject);
		}
	}

	void Start () {
	}
	
	void Update () {

	}

	private void reinitialize(){
		gameMode.Mode = "";
		teamConfig.Team = new string[6];
	}

	public void StartGame(){
		SceneManager.LoadScene ("Game");
	}
}

public enum GameType{ AI_vs_AI, PLAYER_vs_AI, TRAINING }