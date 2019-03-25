using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	private GameManager gameManager;

	public AudioSource audioSource;
	public AudioClip startMatchClip;
	public AudioClip pressClip;
	public AudioClip correctClip;
	public AudioClip errorClip;

	private GameObject menu;
	private Button back2MenuButton;

	private GameObject mainPanel;

	private GameObject DiffSelctPanel;
	public Button nextButton;

	private GameObject TeamSelctPanel;
	public GameObject unitButtonsGrid;
	public Text defaultText;
	private List<string> team;
	private int cont;
	private Text actualInfo;

	private GameObject actualPanel;
	private Button actualButton;

	void Awake(){
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();

		actualButton = null;
		team = new List<string> ();
		cont = 0;
		actualInfo = defaultText;
		nextButton.interactable = false;
	}

	public void StartMatch(){
		if (cont == 6) {
			audioSource.PlayOneShot (startMatchClip);

			gameManager.teamConfig.Team = team.ToArray();
			gameManager.gameMode.Mode = actualButton.transform.GetChild (0).GetComponent<Text> ().text;

			gameManager.StartGame ();
		} else {
			audioSource.PlayOneShot (errorClip);
		}
	}

	public void Back(){
		if (actualButton != null) {
			actualButton.GetComponent<Image> ().color = Color.white;
			actualButton = null;
			team = new List<string> ();
			cont = 0;

			if (actualInfo != defaultText) {
				actualInfo.gameObject.SetActive (false);
				actualInfo = defaultText;
				actualInfo.gameObject.SetActive (true);
			}
		}

		for (int i = 0; i < unitButtonsGrid.transform.childCount; i++) {
			unitButtonsGrid.transform.GetChild (i).GetComponent<Button> ().interactable = false;
			unitButtonsGrid.transform.GetChild (i).GetComponent<Button> ().image.color = Color.white;
		}

		nextButton.interactable = false;
	}

	public void ButtonPressed(Button b){
		if (actualButton == null) {
			nextButton.interactable = true;
		} else {
			actualButton.GetComponent<Image> ().color = Color.white;
		}

		b.GetComponent<Image> ().color = Color.blue;
		actualButton = b;

		audioSource.PlayOneShot (pressClip);
	}

	public void QuitGame(){
		Application.Quit ();
	}
	
	void Update () {
		
	}

	public void AddUnit(GameObject rol){
		if (cont < 6) {
			team.Add (rol.tag);
			unitButtonsGrid.transform.GetChild (cont).GetComponent<Button> ().image.color = GetRolColor (rol.tag);
			unitButtonsGrid.transform.GetChild (cont).GetComponent<Button> ().interactable = true;
			cont++;
			audioSource.PlayOneShot (correctClip);

		} else {
			audioSource.PlayOneShot (errorClip);
		}
	}

	public void RemoveUnit(Button b){
		team.RemoveAt (b.transform.GetSiblingIndex ());
		for (int i = 0; i < team.Count; i++) {
			unitButtonsGrid.transform.GetChild (i).GetComponent<Button> ().image.color = GetRolColor (team [i]);
		}
		for (int i = team.Count; i < 6; i++) {			
			unitButtonsGrid.transform.GetChild (i).GetComponent<Button> ().image.color = Color.white;
			unitButtonsGrid.transform.GetChild (i).GetComponent<Button> ().interactable = false;
		}
		cont--;
	}

	public void ChangeInfo(Text info){
		actualInfo.gameObject.SetActive (false);
		actualInfo = info;
		actualInfo.gameObject.SetActive (true);
	}

	private Color GetRolColor(string name){
		switch (name) {
		case "Healer":
			return Color.green;
		case "Tank":
			return Color.blue;
		case "Mele":
			return Color.red;
		case "Distance":
			return Color.yellow;
		}
		return Color.white;
	}

}
