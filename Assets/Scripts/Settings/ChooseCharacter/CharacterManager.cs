using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterDatabase CharacterDatabase;
    [SerializeField] private Text nameCharacter;
    [SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] GameObject currentObject;

	private int selectionOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("selectedOption"))
        {
            Load();
        }
        UpdateCharacter(selectionOption);
    }

    public void NextOption()
    {
		selectionOption++;
        if(selectionOption >= CharacterDatabase.CharacterCount)
        {
            selectionOption = 0;
        }

        UpdateCharacter(selectionOption);
        Save();
	}

    public void BackOption()
    {
        selectionOption--;
        if(selectionOption < 0)
        {
            selectionOption = CharacterDatabase.CharacterCount - 1;
        }

        UpdateCharacter(selectionOption);
        Save();
    }

    private void UpdateCharacter(int selectionOption)
    {
        Character character = CharacterDatabase.GetCharacter(selectionOption);
        spriteRenderer.sprite = character.characterSprite;
		nameCharacter.text = character.characterName;
        if(currentObject != null)
        {
			Animator animator = currentObject.GetComponent<Animator>();
			animator.runtimeAnimatorController = character.animatorOverrideController;
		}
	}

    private void Load()
    {
        selectionOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectionOption);
    }
}
