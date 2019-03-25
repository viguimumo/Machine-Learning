using System;

[Serializable]
public class KeepData
{
	public int[] team;
	public string gameMode;

	public KeepData (int[] team)
	{
		this.team = team;
	}

	public KeepData(string gameMode)
	{
		this.gameMode = gameMode;
	}
}


