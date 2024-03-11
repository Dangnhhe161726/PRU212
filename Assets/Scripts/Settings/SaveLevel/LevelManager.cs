using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	private string levelDataPath;
	private LevelList levelList;

	[SerializeField] private GameObject levelButtonPrefab;
	[SerializeField] private Transform buttonContainer;
	

	private void Start()
	{
		levelDataPath = Application.dataPath + "/Scripts/Settings/SaveLevel/LevelData.json";
		levelList = LoadLevelData();
		CreateLevelButtons();
	}

	private void CreateLevelButtons()
	{
		if (levelList != null && levelList.levels != null)
		{
			float buttonOffset = 0f;

			foreach (Level level in levelList.levels)
			{
				GameObject buttonObject = Instantiate(levelButtonPrefab, buttonContainer);
				Button buttonComponent = buttonObject.GetComponent<Button>();
				Text buttonTextComponent = buttonObject.GetComponentInChildren<Text>();
				buttonTextComponent.text = level.levelName;
				buttonComponent.interactable = level.completed;
				buttonObject.transform.localPosition += new Vector3(buttonOffset, 0f, 0f);
				buttonOffset += 150f;
				buttonComponent.onClick.AddListener(() => OnLevelButtonClick(level));
			}
		}
	}

	private void OnLevelButtonClick(Level level)
	{
		SceneManager.LoadScene(level.levelName);
	}



	private LevelList LoadLevelData()
	{
		if (File.Exists(levelDataPath))
		{
			string json = File.ReadAllText(levelDataPath);
			return JsonUtility.FromJson<LevelList>(json);
		}
		else
		{
			Debug.LogWarning("Level data file not found.");
			return null;
		}
	}
}
