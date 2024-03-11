using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
	[SerializeField] private GameObject selectCharacter;
	[SerializeField] private GameObject levels;
	public void OnClickedButton(string buttonName)
	{
		switch (buttonName)
		{
			case "Menu":
				menu.SetActive(true);
				settings.SetActive(false);
				selectCharacter.SetActive(false);
				levels.SetActive(false);
				Debug.Log("menu");
				break;
			case "Settings":
				menu.SetActive(false);
				settings.SetActive(true);
				selectCharacter.SetActive(false);
				levels.SetActive(false);
				Debug.Log("Settings");
				break;
			case "SelectCharacter":
				menu.SetActive(false);
				settings.SetActive(false);
				selectCharacter.SetActive(true);
				levels.SetActive(false);
				Debug.Log("SelectCharacter");
				break;
			case "Levels":
				menu.SetActive(false);
				settings.SetActive(false);
				selectCharacter.SetActive(false);
				levels.SetActive(true);
				Debug.Log("SelectCharacter");
				break;
		}
	}

}
