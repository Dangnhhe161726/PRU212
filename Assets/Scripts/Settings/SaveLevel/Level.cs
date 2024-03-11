using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
	public string levelName;
	public int score;
	public bool completed;

	public Level(string levelName, int score, bool completed)
	{
		this.levelName = levelName;
		this.score = score;
		this.completed = completed;
	}
}
