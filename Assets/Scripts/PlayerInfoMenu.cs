using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoMenu
{
    private Transform menuTransform;
    private Button rollStatsButton;
    private Button continueButton;
    private Button backButton;
    public bool continuePress;
    public bool backPress;
    public bool active;
    private GameObject menu;
    private Text abilityText;
    unsafe public Creature.abilities* _abilities;
    private Dropdown sexDropdown;
    private Dropdown raceDropdown;
    private Dropdown classDropdown;
    private Dropdown alignmentDropdown;
    private Dropdown religeonDropdown;
    private bool complete;
    public Character.races race;
    public Character.classes _class;
    public Creature.alignments alignment;

    public PlayerInfoMenu(GameObject _menu)
    {
        continuePress = false;
        backPress = false;

        menu = _menu;

        active = true;
        complete = false;

        menuTransform = menu.GetComponent<Transform>();

        //button, text and dropdown objects
        GameObject buttonObject = MenuController.GetChildWithName(menuTransform, "ContinueButton");
        if (buttonObject != null) continueButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        buttonObject = MenuController.GetChildWithName(menuTransform, "BackButton");
        if (buttonObject != null) backButton = buttonObject.GetComponent<Button>();
        else Debug.Log("Error getting a button componenet");

        abilityText = MenuController.GetChildWithName(menuTransform, "Abilities").GetComponent<Text>();
        if (abilityText == null) Debug.Log("Error getting the ability text");

        sexDropdown = MenuController.GetChildWithName(menuTransform, "SexDropDown").GetComponent<Dropdown>();
        if (sexDropdown == null) Debug.Log("error getting dropdown");

        raceDropdown = MenuController.GetChildWithName(menuTransform, "RaceDropdown").GetComponent<Dropdown>();
        if (raceDropdown == null) Debug.Log("error getting dropdown");

        classDropdown = MenuController.GetChildWithName(menuTransform, "ClassDropdown").GetComponent<Dropdown>();
        if (classDropdown == null) Debug.Log("error getting dropdown");

        alignmentDropdown = MenuController.GetChildWithName(menuTransform, "AlignmentDropdown").GetComponent<Dropdown>();
        if (alignmentDropdown == null) Debug.Log("error getting dropdown");

        religeonDropdown = MenuController.GetChildWithName(menuTransform, "ReligeonDropdown").GetComponent<Dropdown>();
        if (religeonDropdown == null) Debug.Log("error getting dropdown");

        sexDropdown.onValueChanged.AddListener(delegate { sexDropdownChange(); });
        raceDropdown.onValueChanged.AddListener(delegate { raceDropdownChange(); });
        classDropdown.onValueChanged.AddListener(delegate { classDropdownChange(); });
        alignmentDropdown.onValueChanged.AddListener(delegate { alignmentDropdownChange(); });
        religeonDropdown.onValueChanged.AddListener(delegate { religeonDropdownChange(); });

        continueButton.onClick.AddListener(ContinueButtonClick);
        backButton.onClick.AddListener(BackButtonClick);

        clearSexDropdown();

    }

    private void sexDropdownChange()
    {
        GameObject labelObject = MenuController.GetChildWithName(sexDropdown.GetComponent<Transform>(), "Label");
        Text text = labelObject.GetComponent<Text>();

        if(text.text == "-")
        {
            clearRaceDropdown();
        }
        else
        {
            clearRaceDropdown();
            if (text.text == "Male") restrictRaces(true);
            else restrictRaces(false);
        }
        
    }

    private void raceDropdownChange()
    {
        GameObject labelObject = MenuController.GetChildWithName(raceDropdown.GetComponent<Transform>(), "Label");
        Text text = labelObject.GetComponent<Text>();

        if (text.text == "-")
        {
            text.fontSize = 30;
            clearClassDropdown();
        }
        else
        {
            if (text.text == "Dwarf") race = Character.races.dwarf;
            if (text.text == "Elf") race = Character.races.elf;
            if (text.text == "Gnome") race = Character.races.gnome;
            if (text.text == "Half Elf") race = Character.races.half_elf;
            if (text.text == "Halfling") race = Character.races.halfling;
            if (text.text == "Half Orc") race = Character.races.half_orc;
            if (text.text == "Human") race = Character.races.human;

            if (text.text == "Half Elf" || text.text == "Half Orc" || text.text == "Halfling") text.fontSize = 20;
            else text.fontSize = 30;

            clearClassDropdown();
            restrictClasses();
        }
    }

    private void classDropdownChange()
    {
        GameObject labelObject = MenuController.GetChildWithName(classDropdown.GetComponent<Transform>(), "Label");
        Text text = labelObject.GetComponent<Text>();

        if (text.text == "-")
        {
            text.fontSize = 30;
            clearAlignmentDropdown();
        }
        else
        {
            clearAlignmentDropdown();

            if (text.text == "Cleric") _class = Character.classes.cleric;
            if (text.text == "Druid") _class = Character.classes.druid;
            if (text.text == "Fighter") _class = Character.classes.fighter;
            if (text.text == "Paladin") _class = Character.classes.paladin;
            if (text.text == "Ranger") _class = Character.classes.ranger;
            if (text.text == "Magic User") _class = Character.classes.magic_user;
            if (text.text == "Illusionist") _class = Character.classes.illusionist;
            if (text.text == "Theif") _class = Character.classes.theif;
            if (text.text == "Assassin") _class = Character.classes.assassin;
            if (text.text == "Monk") _class = Character.classes.monk;

            if (text.text == "Magic User") text.fontSize = 20;
            else text.fontSize = 30;

            restrictAlignment();
        }
    }

    private void alignmentDropdownChange()
    {
        GameObject labelObject = MenuController.GetChildWithName(alignmentDropdown.GetComponent<Transform>(), "Label");
        Text text = labelObject.GetComponent<Text>();

        if (text.text == "-")
        {
            text.fontSize = 30;
            clearReligeonDropdown();
        }
        else
        {
            text.fontSize = 20;

            if (text.text == "Lawful Good") alignment = Creature.alignments.lawfulGood;
            if (text.text == "Neutral Good") alignment = Creature.alignments.neutralGood;
            if (text.text == "Chaotic Good") alignment = Creature.alignments.chaoticGood;
            if (text.text == "Lawful Neutral") alignment = Creature.alignments.lawfulGood;
            if (text.text == "True Neutral") alignment = Creature.alignments.trueNeutral;
            if (text.text == "Chaotic Neutral") alignment = Creature.alignments.chaoticNeutral;
            if (text.text == "Lawful Evil") alignment = Creature.alignments.lawfulEvil;
            if (text.text == "Neutral Evil") alignment = Creature.alignments.neutralEvil;
            if (text.text == "Chaotic Evil") alignment = Creature.alignments.chaoticEvil;

            restrictReligeon();
        }
    }

    private void religeonDropdownChange()
    {
        GameObject labelObject = MenuController.GetChildWithName(alignmentDropdown.GetComponent<Transform>(), "Label");
        Text text = labelObject.GetComponent<Text>();

        if (text.text == "-")
        {
            clearReligeonDropdown();
        }
        else
        {
            complete = true;
        }
    }

    private void clearSexDropdown()
    {
        clearRaceDropdown();

        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "SexDropDown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { "-", "Male", "Female" };
        dropdown.AddOptions(m_DropOptions);
    }

    private void clearRaceDropdown()
    {
        clearClassDropdown();

        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "RaceDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { "-" };
        dropdown.AddOptions(m_DropOptions);

    }

    private void clearClassDropdown()
    {
        clearAlignmentDropdown();

        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "ClassDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { "-" };
        dropdown.AddOptions(m_DropOptions);
    }

    private void clearAlignmentDropdown()
    {
        clearReligeonDropdown();

        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "AlignmentDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { "-" };
        dropdown.AddOptions(m_DropOptions);
    }

    private void clearReligeonDropdown()
    {
        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "ReligeonDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string> { "-" };
        dropdown.AddOptions(m_DropOptions);
    }


    public void Activate()
    {
        menu.SetActive(true);
    }

    public void Deactivate()
    {
        menu.SetActive(false);
    }

    unsafe public void setAbilities() 
    {
        if (_abilities->strength == 18)
        {
            abilityText.text = String.Format("{0}  {1}\n\n{2}\n\n{3}\n\n{4}\n\n{5}\n\n{6}", _abilities->strength, _abilities->strength_over18, _abilities->intelligence, _abilities->wisdom, _abilities->dexterity, _abilities->constitution, _abilities->charisma);
        }
        else abilityText.text = String.Format("{0}\n\n{1}\n\n{2}\n\n{3}\n\n{4}\n\n{5}", _abilities->strength, _abilities->intelligence, _abilities->wisdom, _abilities->dexterity, _abilities->constitution, _abilities->charisma);

    }

    unsafe private void restrictRaces(bool male)
    {
        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "RaceDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();

        List<string> m_DropOptions = new List<string> { "-" };


        if (male)
        {
            if(8 <= _abilities->strength && _abilities->strength <= 18)
            {
                if(3 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if(3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 17)
                        {
                            if (12 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if(3 <= _abilities->charisma && _abilities->charisma <= 16)
                                {
                                    m_DropOptions.Add("Dwarf");
                                }
                            }
                        }
                    }
                }
            }

            if (3 <= _abilities->strength && _abilities->strength <= 18)
            {
                if (8 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (7 <= _abilities->dexterity && _abilities->dexterity <= 19)
                        {
                            if (6 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (8 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Elf");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 18)
            {
                if (7 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (8 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Gnome");
                                }
                            }
                        }
                    }
                }
            }

            if (3 <= _abilities->strength && _abilities->strength <= 18)
            {
                if (4 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (6 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (6 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Half Elf");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 17)
            {
                if (6 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 17)
                    {
                        if (8 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (10 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Halfling");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 18)
            {
                if (3 <= _abilities->intelligence && _abilities->intelligence <= 17)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 14)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 17)
                        {
                            if (13 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 12)
                                {
                                    m_DropOptions.Add("Half Orc");
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            if (8 <= _abilities->strength && _abilities->strength <= 17)
            {
                if (3 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 17)
                        {
                            if (12 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 16)
                                {
                                    m_DropOptions.Add("Dwarf");
                                }
                            }
                        }
                    }
                }
            }

            if (3 <= _abilities->strength && _abilities->strength <= 16)
            {
                if (8 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (7 <= _abilities->dexterity && _abilities->dexterity <= 19)
                        {
                            if (6 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (8 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Elf");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 15)
            {
                if (7 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (8 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Gnome");
                                }
                            }
                        }
                    }
                }
            }

            if (3 <= _abilities->strength && _abilities->strength <= 17)
            {
                if (4 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 18)
                    {
                        if (6 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (6 <= _abilities->constitution && _abilities->constitution <= 18)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Half Elf");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 14)
            {
                if (6 <= _abilities->intelligence && _abilities->intelligence <= 18)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 17)
                    {
                        if (8 <= _abilities->dexterity && _abilities->dexterity <= 18)
                        {
                            if (10 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 18)
                                {
                                    m_DropOptions.Add("Halfling");
                                }
                            }
                        }
                    }
                }
            }

            if (6 <= _abilities->strength && _abilities->strength <= 18)
            {
                if (3 <= _abilities->intelligence && _abilities->intelligence <= 17)
                {
                    if (3 <= _abilities->wisdom && _abilities->wisdom <= 14)
                    {
                        if (3 <= _abilities->dexterity && _abilities->dexterity <= 17)
                        {
                            if (13 <= _abilities->constitution && _abilities->constitution <= 19)
                            {
                                if (3 <= _abilities->charisma && _abilities->charisma <= 12)
                                {
                                    m_DropOptions.Add("Half Orc");
                                }
                            }
                        }
                    }
                }
            }
        }

        m_DropOptions.Add("Human");
        dropdown.AddOptions(m_DropOptions);
    }

    unsafe private void restrictClasses()
    {
        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "ClassDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();

        List<string> m_DropOptions = new List<string> { "-" };

        if (race == Character.races.half_elf || race == Character.races.half_orc || race == Character.races.human)
        {
            if (_abilities->wisdom >= 9) m_DropOptions.Add("Cleric");
        }

        if(race == Character.races.half_elf || race == Character.races.human)
        {
            if(_abilities->wisdom >= 12 && _abilities->charisma >= 15)
            {
                m_DropOptions.Add("Druid");
            }
        }

        if(_abilities->strength >= 9 && _abilities->constitution >= 7) m_DropOptions.Add("Fighter");

        if(race == Character.races.human)
        {
            if (_abilities->strength >= 12 && _abilities->intelligence >= 9 && _abilities->wisdom >= 13 && _abilities->constitution >= 9 && _abilities->charisma >= 17) m_DropOptions.Add("Paladin");
        }

        if(race == Character.races.half_elf || race == Character.races.human)
        {
            if (_abilities->strength >= 13 && _abilities->intelligence >= 13 && _abilities->wisdom >= 14 && _abilities->constitution >= 14) m_DropOptions.Add("Ranger");
        }

        if(race == Character.races.elf || race == Character.races.half_elf || race == Character.races.human)
        {
            if (_abilities->intelligence >= 9 && _abilities->dexterity >= 6) m_DropOptions.Add("Magic User");
        }

        if (race == Character.races.gnome || race == Character.races.human)
        {
            if (_abilities->intelligence >= 15 && _abilities->dexterity >= 16) m_DropOptions.Add("Illusionist");
        }

        if (_abilities->dexterity >= 0) m_DropOptions.Add("Theif");

        if (race != Character.races.halfling)
        {
            if (_abilities->strength >= 12 && _abilities->intelligence >= 11 && _abilities->dexterity >= 12) m_DropOptions.Add("Assassin");
        }
        
        if(race == Character.races.human)
        {
            if (_abilities->strength >= 15 && _abilities->dexterity >= 15 && _abilities->wisdom >= 15 && _abilities->constitution >= 11) m_DropOptions.Add("Monk");
        }

        dropdown.AddOptions(m_DropOptions);
    }

    private void restrictAlignment()
    {
        GameObject dropDownObject = MenuController.GetChildWithName(menuTransform, "AlignmentDropdown");
        Dropdown dropdown = dropDownObject.GetComponent<Dropdown>();

        dropdown.ClearOptions();

        List<string> m_DropOptions = new List<string> { "-" };

        if(_class == Character.classes.cleric)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Neutral Good");
            m_DropOptions.Add("Chaotic Good");
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        }else if (_class == Character.classes.druid)
        {
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
        }
        else if (_class == Character.classes.fighter)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Neutral Good");
            m_DropOptions.Add("Chaotic Good");
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        } else if (_class == Character.classes.paladin)
        {
            m_DropOptions.Add("Lawful Good");
        } else if (_class == Character.classes.ranger)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Neutral Good");
            m_DropOptions.Add("Chaotic Good");
        } else if (_class == Character.classes.magic_user)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Neutral Good");
            m_DropOptions.Add("Chaotic Good");
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        } else if (_class == Character.classes.illusionist)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Neutral Good");
            m_DropOptions.Add("Chaotic Good");
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        } else if (_class == Character.classes.theif)
        {
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("True Neutral");
            m_DropOptions.Add("Chaotic Neutral");
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        } else if (_class == Character.classes.assassin)
        {
            m_DropOptions.Add("Lawful Evil");
            m_DropOptions.Add("Neutral Evil");
            m_DropOptions.Add("Chaotic Evil");
        } else if (_class == Character.classes.assassin)
        {
            m_DropOptions.Add("Lawful Good");
            m_DropOptions.Add("Lawful Neutral");
            m_DropOptions.Add("Lawful Evil");
        }

        dropdown.AddOptions(m_DropOptions);

    }

    private void restrictReligeon()
    {

    }


    void ContinueButtonClick()
    {
        if (menu.activeSelf && complete)
        {
            continuePress = true;

            Debug.Log("Continue Button Clicked");
        }
    }

    void BackButtonClick()
    {
        if (menu.activeSelf)
        {
            clearSexDropdown();
            backPress = true;
            Debug.Log("Back Button Clicked");
        }
    }
}
