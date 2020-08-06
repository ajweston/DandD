using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter_RollStats
{
    private Transform menuTransform;
    private Button rollStatsButton;
    private Button continueButton;
    private Button backButton;
    public bool continuePress;
    public bool backPress;
    public bool active;
    private bool rollHasBeenPressed;
    private GameObject menu;
    private Text abilityText;
    unsafe public Creature.abilities* _abilities;

    public CreateCharacter_RollStats(GameObject _menu)
    {
        continuePress = false;
        backPress = false;
        rollHasBeenPressed = false;

        menu = _menu;

        active = true;

        menuTransform = menu.GetComponent<Transform>();

        GameObject buttonObject = MenuController.GetChildWithName(menuTransform, "RollStatsButton");
        if (buttonObject != null) rollStatsButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        buttonObject = MenuController.GetChildWithName(menuTransform, "ContinueButton");
        if (buttonObject != null) continueButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        buttonObject = MenuController.GetChildWithName(menuTransform, "BackButton");
        if (buttonObject != null) backButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        abilityText = MenuController.GetChildWithName(menuTransform, "Abilities").GetComponent<Text>();
        if (abilityText == null) Debug.Log("Error getting the ability text");

        rollStatsButton.onClick.AddListener(RollStatsButtonClick);
        continueButton.onClick.AddListener(ContinueButtonClick);
        backButton.onClick.AddListener(BackButtonClick);

    }

    unsafe public void setAbilitiesPointer(Creature.abilities* _a)
    {
        _abilities = _a;
    }

    public void Activate()
    {
        menu.SetActive(true);
    }

    public void Deactivate()
    {
        menu.SetActive(false);
    }

    int rollDice(System.Random r)
    {
        int[] diceRolls = new int[4];
        int lowestIndex = -1;
        int lowestRoll = 7;

        for (int i = 0; i < 4; i++)
        {
            diceRolls[i] = r.Next(1, 7);
            if (diceRolls[i] < lowestRoll)
            {
                lowestRoll = diceRolls[i];
                lowestIndex = i;
            }
        }
        int score = 0;
        for (int i = 0; i < 4; i++)
        {
            if (i == lowestIndex) continue;
            score += diceRolls[i];
        }
        return score;
    }

    unsafe void RollStatsButtonClick()
    {
        if (menu.activeSelf)
        {
            rollHasBeenPressed = true;
            Debug.Log("Create Character Button Clicked");

            System.Random r = new System.Random();

            _abilities->strength = rollDice(r);

            if (_abilities->strength == 18)
            {
                _abilities->strength_over18 = r.Next(0, 101);
            }

            _abilities->intelligence = rollDice(r);
            _abilities->wisdom = rollDice(r);
            _abilities->dexterity = rollDice(r);
            _abilities->constitution = rollDice(r);
            _abilities->charisma = rollDice(r);

            if (_abilities->strength == 18) 
            {
                abilityText.text = String.Format("{0}  {1}\n\n{2}\n\n{3}\n\n{4}\n\n{5}\n\n{6}", _abilities->strength, _abilities->strength_over18, _abilities->intelligence, _abilities->wisdom, _abilities->dexterity, _abilities->constitution, _abilities->charisma);
            }
            else abilityText.text = String.Format("{0}\n\n{1}\n\n{2}\n\n{3}\n\n{4}\n\n{5}", _abilities->strength, _abilities->intelligence, _abilities->wisdom, _abilities->dexterity, _abilities->constitution, _abilities->charisma);

        }
    }

    void ContinueButtonClick()
    {
        if (menu.activeSelf && rollHasBeenPressed)
        {
            continuePress = true;

            Debug.Log("Load Character Button Clicked");
        }
    }

    void BackButtonClick()
    {
        if (menu.activeSelf)
        {
            rollHasBeenPressed = false;
            abilityText.text = "-\n\n-\n\n-\n\n-\n\n-\n\n-";
            backPress = true;
            Debug.Log("Exit Button Clicked");
        }
    }
}
