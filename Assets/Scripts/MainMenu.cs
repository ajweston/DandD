using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu
{
    private Transform menuTransform;
    private Button createCharacterButton;
    private Button loadCharacterButton;
    private Button exitButton;
    public bool createCharacterPress;
    public bool loadCharacterPress;
    public bool active;
    private GameObject menu;

    public MainMenu(GameObject _menu)
    {
        createCharacterPress = false;
        loadCharacterPress = false;
        active = true;
        menu = _menu;

        menuTransform = menu.GetComponent<Transform>();

        GameObject buttonObject = MenuController.GetChildWithName(menuTransform, "CreateCharacterButton");
        if (buttonObject != null) createCharacterButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        buttonObject = MenuController.GetChildWithName(menuTransform, "LoadCharacterButton");
        if (buttonObject != null) loadCharacterButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        buttonObject = MenuController.GetChildWithName(menuTransform, "ExitButton");
        if (buttonObject != null) exitButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        createCharacterButton.onClick.AddListener(createCharacterButtonClick);
        loadCharacterButton.onClick.AddListener(loadCharacterButtonClick);
        exitButton.onClick.AddListener(exitButtonClick);

    }

    public void Activate()
    {
        menu.SetActive(true);
        active = true;
    }

    public void Deactivate()
    {
        menu.SetActive(false);
        active = false;
    }

    void createCharacterButtonClick()
    {
        if (menu.activeSelf)
        {
            createCharacterPress = true;
            Debug.Log("Create Character Button Clicked");
        }
    }

    void loadCharacterButtonClick()
    {
        if (menu.activeSelf)
        {
            loadCharacterPress = true;
            Debug.Log("Load Character Button Clicked");
        }
    }

    void exitButtonClick()
    {
        if (menu.activeSelf)
        {
            Debug.Log("Exit Button Clicked");
            Application.Quit(0);
        }
    }
}
