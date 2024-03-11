using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OpenNewLevel : MonoBehaviour
{
	private string levelDataPath;
	[SerializeField] private string newLevel;

	void Start()
	{
		levelDataPath = Application.dataPath + "/Scripts/Settings/SaveLevel/LevelData.json";
		SaveLevelData();
	}

	private void SaveLevelData()
	{
		string json = File.ReadAllText(levelDataPath);
		LevelList currentListLevel = JsonUtility.FromJson<LevelList>(json);

		for (int i = 0; i < currentListLevel.levels.Length; i++)
		{
			if (currentListLevel.levels[i].levelName.Equals(newLevel))
			{
				currentListLevel.levels[i].completed = true;
			}
		}
		string dataSave = JsonUtility.ToJson(currentListLevel);
		Debug.Log(dataSave);
		File.WriteAllText(levelDataPath, dataSave);
	}
}