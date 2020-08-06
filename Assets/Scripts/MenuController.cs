using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public static GameObject GetChildWithName(Transform trans, string name)
    {
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    private MainMenu mainMenu;
    private CreateCharacter_RollStats createCharacterRollStats;
    private PlayerInfoMenu playerInfoMenu;
    private Transform menuControllerTransform;
    private GameObject mainMenuObject;
    private GameObject createCharacterRollStatsObject;
    private GameObject playerInfoMenuObject;
    private Character character;


    // Start is called before the first frame update
    unsafe void Start()
    {
        menuControllerTransform = GetComponent<Transform>();

        mainMenuObject = GetChildWithName(menuControllerTransform, "MainMenu");
        mainMenu = new MainMenu(mainMenuObject);

        createCharacterRollStatsObject = GetChildWithName(menuControllerTransform, "CreateCharacter_RollStats");
        createCharacterRollStats = new CreateCharacter_RollStats(createCharacterRollStatsObject);

        playerInfoMenuObject = GetChildWithName(menuControllerTransform, "PlayerInfoMenu");
        playerInfoMenu = new PlayerInfoMenu(playerInfoMenuObject);

        character = new Character();


        fixed (Creature.abilities* p_abilities = &(character._abilities))
        {
            createCharacterRollStats._abilities = p_abilities;
            playerInfoMenu._abilities = p_abilities;
        }

        mainMenu.Activate();
        createCharacterRollStats.Deactivate();
        playerInfoMenu.Deactivate();
    }

    // Update is called once per frame
    unsafe void Update()
    {
        if (mainMenu.active)
        {
            if (mainMenu.createCharacterPress)
            {
                mainMenu.createCharacterPress = false;
                mainMenu.Deactivate();
                createCharacterRollStats.Activate();
            }
        }
        else if (mainMenu.loadCharacterPress)
        {
            mainMenu.loadCharacterPress = false;
        }
        
        if (createCharacterRollStats.active)
        {
            if (createCharacterRollStats.backPress)
            {
                createCharacterRollStats.backPress = false;
                createCharacterRollStats.Deactivate();
                mainMenu.Activate();
            }
            else if (createCharacterRollStats.continuePress)
            {
                createCharacterRollStats.continuePress = false;
                createCharacterRollStats.Deactivate();
                playerInfoMenu.setAbilities();
                playerInfoMenu.Activate();
            }
        }

        if (playerInfoMenu.active)
        {
            if (playerInfoMenu.backPress)
            {
                playerInfoMenu.backPress = false;
                playerInfoMenu.Deactivate();
                createCharacterRollStats.Activate();
            }
            else if (playerInfoMenu.continuePress)
            {
                
            }
        }

    }
}
