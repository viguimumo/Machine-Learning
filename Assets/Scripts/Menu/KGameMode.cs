using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class KGameMode
{
	public String mode;
	private String modePath;

	public KGameMode ()
	{
		charge ();
		modePath = Application.persistentDataPath + "/gameMode.txt";
	}

	public string Mode{
		get{ 
			charge ();
			return mode;
		}
		set{ 
			mode = value;
			save ();
		}
	}

	private void charge(){
		if (File.Exists (modePath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (modePath, FileMode.Open);

			KeepData info = (KeepData)bf.Deserialize (file);
			mode = info.gameMode;

			file.Close ();
		} else {
			mode = "";
		}
	}

	private void save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (modePath);

		KeepData info = new KeepData (mode);
		bf.Serialize (file, info);

		file.Close ();
	}
}

