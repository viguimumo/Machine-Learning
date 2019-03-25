using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class KTeamConfig
{
	public string[] team;
	private String teamPath;

	public KTeamConfig ()
	{
		charge ();
		teamPath = Application.persistentDataPath + "/teamConfig.text.bytes";
	}

	public string[] Team{
		get{ 
			charge ();
			return team;
		}
		set{ 
			team = value;
			save ();
		}
	}

	private void charge(){
		if (File.Exists (teamPath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (teamPath, FileMode.Open);

			KeepData info = (KeepData)bf.Deserialize (file);
			team = getTeamNames (info.team);

			file.Close ();
		} else {
			team = new string[6];
		}
	}

	private void save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (teamPath);

		KeepData info = new KeepData (getTeamValues());
		bf.Serialize (file, info);

		file.Close ();
	}

	private int[] getTeamValues(){
		int[] values = new int[6];

		for (int i = 0; i < 6; i++) {
			switch (team [i]) {
			case "Healer":
				values [i] = 0;
				break;

			case "Tank":
				values [i] = 1;
				break;

			case "Mele":
				values [i] = 2;
				break;

			case "Distance":
				values [i] = 3;
				break;
			}
		}

		return values;
	}

	private string[] getTeamNames(int[] values){
		string[] names = new string[6];

		for (int i = 0; i < 6; i++) {
			switch (values [i]) {
			case 0:
				names [i] = "Healer";
				break;

			case 1:
				names [i] = "Tank";
				break;

			case 2:
				names [i] = "Mele";
				break;

			case 3:
				names [i] = "Distance";
				break;
			}
		}

		return names;
	}
}


