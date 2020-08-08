using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Creature
{

    public enum classes
    {
        cleric,
        druid,
        fighter,
        paladin,
        ranger,
        magic_user,
        illusionist,
        theif,
        assassin,
        monk
    };

    public enum races
    {
        dwarf,
        elf,
        gnome,
        half_elf,
        halfling,
        half_orc,
        human
    }


    //ability related structures
    public struct strengthModifiers
    {
        public int over18;
        public int hitProbability;
        public int damageAdjustment;
        public int weightAllowance;
        public int openDoors;
        public int openMagicDoor;
        public int bendBarsLiftGates;

    };

    public struct intelligenceModifiers
    {
        public int possibleLanguages;
        public int knowSpellChance;
        public int minSpellsPerLevel;
        public int maxSpellsPerLevel;
    };

    public struct wisdomModifiers
    {
        public int magicalAttackAdjustment;
        public int spellBonus;
        public int spellFailure;
    };

    public struct dexterityModifiers
    {
        public int reactionAdjustment;
        public int defensiveAdjustment;
        public int pickPockets;
        public int openLocks;
        public int locateRemoveTrap;
        public int moveSilently;
        public int hideInShadows;
    };

    public struct constitutionModifiers
    {
        public int hitpointAdjustment;
        public int systemShockSurvival;
        public int resurrectionSurvival;
    };

    public struct charismaModifiers
    {
        public int maxHenchmen;
        public int loyaltyBase;
        public int reactionAdjustment;
    }

    public struct abilityModifiers
    {
        public strengthModifiers strengthMods;
        public intelligenceModifiers intelligenceMods;
        public wisdomModifiers wisdomMods;
        public dexterityModifiers dexterityMods;
        public constitutionModifiers constitutionModifiers;
        public charismaModifiers charismaMods;
    };

    public struct racialModifiers
    {
        public int strength;
        public int intelligence;
        public int wisdom;
        public int dexterity;
        public int constitution;
        public int charisma;
    }


    //ability related functions
    strengthModifiers createStrengthModifiers(int strength, int over18, bool isFighter)
    {
        strengthModifiers mod;
        mod.over18 = over18;

        mod.openMagicDoor = 0;

        if (strength == 3)
        {
            mod.hitProbability = -3;
            mod.damageAdjustment = -1;
            mod.weightAllowance = -250;
            mod.openDoors = 1;
            mod.bendBarsLiftGates = 0;
        }
        else if (strength == 4 || strength == 5)
        {
            mod.hitProbability = -2;
            mod.damageAdjustment = -1;
            mod.weightAllowance = -350;
            mod.openDoors = 1;
            mod.bendBarsLiftGates = 0;
        }
        else if (strength == 6 || strength == 7)
        {
            mod.hitProbability = -1;
            mod.damageAdjustment = 0;
            mod.weightAllowance = -150;
            mod.openDoors = 1;
            mod.bendBarsLiftGates = 0;
        }
        else if (strength == 8 || strength == 9)
        {
            mod.hitProbability = 0;
            mod.damageAdjustment = 0;
            mod.weightAllowance = 0;
            mod.openDoors = 2;
            mod.bendBarsLiftGates = 1;
        }
        else if (strength == 10 || strength == 11)
        {
            mod.hitProbability = 0;
            mod.damageAdjustment = 0;
            mod.weightAllowance = 0;
            mod.openDoors = 2;
            mod.bendBarsLiftGates = 2;
        }
        else if (strength == 12 || strength == 13)
        {
            mod.hitProbability = 0;
            mod.damageAdjustment = 0;
            mod.weightAllowance = 100;
            mod.openDoors = 2;
            mod.bendBarsLiftGates = 4;
        }
        else if (strength == 14 || strength == 15)
        {
            mod.hitProbability = 0;
            mod.damageAdjustment = 0;
            mod.weightAllowance = 200;
            mod.openDoors = 2;
            mod.bendBarsLiftGates = 7;
        }
        else if (strength == 16)
        {
            mod.hitProbability = 0;
            mod.damageAdjustment = 1;
            mod.weightAllowance = 350;
            mod.openDoors = 3;
            mod.bendBarsLiftGates = 10;
        }
        else if (strength == 17)
        {
            mod.hitProbability = 1;
            mod.damageAdjustment = 1;
            mod.weightAllowance = 500;
            mod.openDoors = 3;
            mod.bendBarsLiftGates = 13;
        }
        else if (strength == 18 && over18 == 0)
        {
            mod.hitProbability = 1;
            mod.damageAdjustment = 2;
            mod.weightAllowance = 750;
            mod.openDoors = 3;
            mod.bendBarsLiftGates = 16;
        }
        else if (strength == 18 && over18 >= 1 && over18 <= 50)
        {
            mod.hitProbability = 1;
            mod.damageAdjustment = 3;
            mod.weightAllowance = 1000;
            mod.openDoors = 3;
            mod.bendBarsLiftGates = 20;
        }
        else if (strength == 18 && over18 >= 51 && over18 <= 75)
        {
            mod.hitProbability = 2;
            mod.damageAdjustment = 3;
            mod.weightAllowance = 1250;
            mod.openDoors = 4;
            mod.bendBarsLiftGates = 25;
        }
        else if (strength == 18 && over18 >= 76 && over18 <= 90)
        {
            mod.hitProbability = 2;
            mod.damageAdjustment = 4;
            mod.weightAllowance = 1500;
            mod.openDoors = 4;
            mod.bendBarsLiftGates = 30;
        }
        else if (strength == 18 && over18 >= 91 && over18 <= 99)
        {
            mod.hitProbability = 2;
            mod.damageAdjustment = 5;
            mod.weightAllowance = 2000;
            mod.openDoors = 4;
            mod.openMagicDoor = 1;
            mod.bendBarsLiftGates = 35;
        }
        else
        {
            mod.hitProbability = 3;
            mod.damageAdjustment = 6;
            mod.weightAllowance = 3000;
            mod.openDoors = 5;
            mod.openMagicDoor = 2;
            mod.bendBarsLiftGates = 40;
        }

        return mod;
    }

    intelligenceModifiers createIntelligenceModifiers(int intelligence, bool isMagickUser)
    {
        intelligenceModifiers mod;

        mod.possibleLanguages = 0;
        mod.knowSpellChance = 0;
        mod.minSpellsPerLevel = 0;
        mod.maxSpellsPerLevel = 0;

        if (intelligence == 8)
        {
            mod.possibleLanguages = 1;
        }
        else if (intelligence == 9)
        {
            mod.possibleLanguages = 1;
            if (isMagickUser)
            {
                mod.knowSpellChance = 35;
                mod.minSpellsPerLevel = 4;
                mod.maxSpellsPerLevel = 6;
            }
        }
        else if (intelligence == 10)
        {
            mod.possibleLanguages = 2;
            if (isMagickUser)
            {
                mod.knowSpellChance = 45;
                mod.minSpellsPerLevel = 5;
                mod.maxSpellsPerLevel = 7;
            }
        }
        else if (intelligence == 11)
        {
            mod.possibleLanguages = 2;
            if (isMagickUser)
            {
                mod.knowSpellChance = 45;
                mod.minSpellsPerLevel = 5;
                mod.maxSpellsPerLevel = 7;
            }
        }
        else if (intelligence == 12)
        {
            mod.possibleLanguages = 3;
            if (isMagickUser)
            {
                mod.knowSpellChance = 45;
                mod.minSpellsPerLevel = 5;
                mod.maxSpellsPerLevel = 7;
            }
        }
        else if (intelligence == 13)
        {
            mod.possibleLanguages = 3;
            if (isMagickUser)
            {
                mod.knowSpellChance = 55;
                mod.minSpellsPerLevel = 6;
                mod.maxSpellsPerLevel = 9;
            }
        }
        else if (intelligence == 14)
        {
            mod.possibleLanguages = 4;
            if (isMagickUser)
            {
                mod.knowSpellChance = 55;
                mod.minSpellsPerLevel = 6;
                mod.maxSpellsPerLevel = 9;
            }
        }
        else if (intelligence == 15)
        {
            mod.possibleLanguages = 4;
            if (isMagickUser)
            {
                mod.knowSpellChance = 65;
                mod.minSpellsPerLevel = 7;
                mod.maxSpellsPerLevel = 11;
            }
        }
        else if (intelligence == 16)
        {
            mod.possibleLanguages = 5;
            if (isMagickUser)
            {
                mod.knowSpellChance = 65;
                mod.minSpellsPerLevel = 7;
                mod.maxSpellsPerLevel = 11;
            }
        }
        else if (intelligence == 17)
        {
            mod.possibleLanguages = 6;
            if (isMagickUser)
            {
                mod.knowSpellChance = 75;
                mod.minSpellsPerLevel = 8;
                mod.maxSpellsPerLevel = 14;
            }
        }
        else if (intelligence == 18)
        {
            mod.possibleLanguages = 7;
            if (isMagickUser)
            {
                mod.knowSpellChance = 85;
                mod.minSpellsPerLevel = 9;
                mod.maxSpellsPerLevel = 18;
            }
        }
        else
        {
            mod.possibleLanguages = 7;
            if (isMagickUser)
            {
                mod.knowSpellChance = 95;
                mod.minSpellsPerLevel = 10;
                mod.maxSpellsPerLevel = 100000;
            }
        }

        return mod;
    }

    wisdomModifiers createWisdomModifiers(int wisdom, bool isCleric)
    {
        wisdomModifiers mod;

        mod.spellBonus = 0;
        mod.spellFailure = 0;

        if (wisdom == 3)
        {
            mod.magicalAttackAdjustment = -3;
        }
        else if (wisdom == 4)
        {
            mod.magicalAttackAdjustment = -2;
        }
        else if (wisdom == 5)
        {
            mod.magicalAttackAdjustment = -1;
        }
        else if (wisdom == 6)
        {
            mod.magicalAttackAdjustment = -1;
        }
        else if (wisdom == 7)
        {
            mod.magicalAttackAdjustment = -1;
        }
        else if (wisdom == 8)
        {
            mod.magicalAttackAdjustment = 0;
        }
        else if (wisdom == 9)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 0;
                mod.spellFailure = 20;
            }
        }
        else if (wisdom == 10)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 0;
                mod.spellFailure = 15;
            }
        }
        else if (wisdom == 11)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 0;
                mod.spellFailure = 10;
            }
        }
        else if (wisdom == 12)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 0;
                mod.spellFailure = 5;
            }
        }
        else if (wisdom == 13)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 11;
                mod.spellFailure = 0;
            }
        }
        else if (wisdom == 14)
        {
            mod.magicalAttackAdjustment = 0;
            if (isCleric)
            {
                mod.spellBonus = 11;
                mod.spellFailure = 0;
            }
        }
        else if (wisdom == 15)
        {
            mod.magicalAttackAdjustment = 1;
            if (isCleric)
            {
                mod.spellBonus = 12;
                mod.spellFailure = 0;
            }
        }
        else if (wisdom == 16)
        {
            mod.magicalAttackAdjustment = 2;
            if (isCleric)
            {
                mod.spellBonus = 12;
                mod.spellFailure = 0;
            }
        }
        else if (wisdom == 17)
        {
            mod.magicalAttackAdjustment = 3;
            if (isCleric)
            {
                mod.spellBonus = 13;
                mod.spellFailure = 0;
            }
        }
        else
        {
            mod.magicalAttackAdjustment = 4;
            if (isCleric)
            {
                mod.spellBonus = 14;
                mod.spellFailure = 0;
            }
        }

        return mod;
    }

    dexterityModifiers createDexterityModifiers(int dexterity, bool isTheif)
    {
        dexterityModifiers mod;

        mod.pickPockets = 0;
        mod.openLocks = 0;
        mod.locateRemoveTrap = 0;
        mod.moveSilently = 0;
        mod.hideInShadows = 0;

        if (dexterity == 3)
        {
            mod.reactionAdjustment = -3;
            mod.defensiveAdjustment = 4;
        }
        else if (dexterity == 4)
        {
            mod.reactionAdjustment = -2;
            mod.defensiveAdjustment = 3;

        }
        else if (dexterity == 5)
        {
            mod.reactionAdjustment = -1;
            mod.defensiveAdjustment = 2;

        }
        else if (dexterity == 6)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 1;

        }
        else if (dexterity == 7)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;

        }
        else if (dexterity == 8)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;

        }
        else if (dexterity == 9)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = -15;
                mod.openLocks = -10;
                mod.locateRemoveTrap = -10;
                mod.moveSilently = -20;
                mod.moveSilently = -10;
            }

        }
        else if (dexterity == 10)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = -10;
                mod.openLocks = -5;
                mod.locateRemoveTrap = -10;
                mod.moveSilently = -10;
                mod.moveSilently = -5;
            }
        }
        else if (dexterity == 11)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = -5;
                mod.openLocks = 0;
                mod.locateRemoveTrap = -5;
                mod.moveSilently = -10;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 12)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = 0;
                mod.openLocks = 0;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = -5;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 13)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = 0;
                mod.openLocks = 0;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = 0;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 14)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = 0;
            if (isTheif)
            {
                mod.pickPockets = 0;
                mod.openLocks = 0;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = 0;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 15)
        {
            mod.reactionAdjustment = 0;
            mod.defensiveAdjustment = -1;
            if (isTheif)
            {
                mod.pickPockets = 0;
                mod.openLocks = 0;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = 0;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 16)
        {
            mod.reactionAdjustment = 1;
            mod.defensiveAdjustment = -2;
            if (isTheif)
            {
                mod.pickPockets = 0;
                mod.openLocks = 5;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = 0;
                mod.moveSilently = 0;
            }
        }
        else if (dexterity == 17)
        {
            mod.reactionAdjustment = 2;
            mod.defensiveAdjustment = -3;
            if (isTheif)
            {
                mod.pickPockets = 5;
                mod.openLocks = 10;
                mod.locateRemoveTrap = 0;
                mod.moveSilently = 5;
                mod.moveSilently = 5;
            }
        }
        else
        {
            mod.reactionAdjustment = 3;
            mod.defensiveAdjustment = -4;
            if (isTheif)
            {
                mod.pickPockets = 10;
                mod.openLocks = 15;
                mod.locateRemoveTrap = 5;
                mod.moveSilently = 10;
                mod.moveSilently = 10;
            }
        }


        return mod;
    }

    constitutionModifiers createConstitutionModifiers(int constitution, bool isFighter)
    {
        constitutionModifiers mod;

        if (constitution == 3)
        {
            mod.hitpointAdjustment = -2;
            mod.systemShockSurvival = 35;
            mod.resurrectionSurvival = 40;
        }
        else if (constitution == 4)
        {
            mod.hitpointAdjustment = -1;
            mod.systemShockSurvival = 40;
            mod.resurrectionSurvival = 45;

        }
        else if (constitution == 5)
        {
            mod.hitpointAdjustment = -1;
            mod.systemShockSurvival = 45;
            mod.resurrectionSurvival = 50;

        }
        else if (constitution == 6)
        {
            mod.hitpointAdjustment = -1;
            mod.systemShockSurvival = 50;
            mod.resurrectionSurvival = 55;

        }
        else if (constitution == 7)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 55;
            mod.resurrectionSurvival = 60;

        }
        else if (constitution == 8)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 60;
            mod.resurrectionSurvival = 65;

        }
        else if (constitution == 9)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 65;
            mod.resurrectionSurvival = 70;

        }
        else if (constitution == 10)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 70;
            mod.resurrectionSurvival = 75;

        }
        else if (constitution == 11)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 75;
            mod.resurrectionSurvival = 80;

        }
        else if (constitution == 12)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 80;
            mod.resurrectionSurvival = 85;

        }
        else if (constitution == 13)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 85;
            mod.resurrectionSurvival = 90;

        }
        else if (constitution == 14)
        {
            mod.hitpointAdjustment = 0;
            mod.systemShockSurvival = 88;
            mod.resurrectionSurvival = 92;

        }
        else if (constitution == 15)
        {
            mod.hitpointAdjustment = 1;
            mod.systemShockSurvival = 91;
            mod.resurrectionSurvival = 94;

        }
        else if (constitution == 16)
        {
            mod.hitpointAdjustment = 2;
            mod.systemShockSurvival = 95;
            mod.resurrectionSurvival = 96;

        }
        else if (constitution == 17)
        {
            mod.hitpointAdjustment = 2;
            mod.systemShockSurvival = 97;
            mod.resurrectionSurvival = 98;
            if (isFighter)
            {
                mod.hitpointAdjustment = 3;
            }

        }
        else
        {
            mod.hitpointAdjustment = 3;
            mod.systemShockSurvival = 99;
            mod.resurrectionSurvival = 100;
            if (isFighter)
            {
                mod.hitpointAdjustment = 4;
            }

        }

        return mod;
    }

    charismaModifiers createCharismaModifiers(int charisma)
    {
        charismaModifiers mod;

        if(charisma == 3)
        {
            mod.maxHenchmen = 1;
            mod.loyaltyBase = -30;
            mod.reactionAdjustment = -25;
        }
        else if (charisma == 4)
        {
            mod.maxHenchmen = 1;
            mod.loyaltyBase = -25;
            mod.reactionAdjustment = -20;

        }
        else if (charisma == 5)
        {
            mod.maxHenchmen = 2;
            mod.loyaltyBase = -20;
            mod.reactionAdjustment = -15;

        }
        else if (charisma == 6)
        {
            mod.maxHenchmen = 0;
            mod.loyaltyBase = -15;
            mod.reactionAdjustment = -10;

        }
        else if (charisma == 7)
        {
            mod.maxHenchmen = 3;
            mod.loyaltyBase = -10;
            mod.reactionAdjustment = -5;

        }
        else if (charisma == 8)
        {
            mod.maxHenchmen = 3;
            mod.loyaltyBase = -5;
            mod.reactionAdjustment = 0;

        }
        else if (charisma == 9)
        {
            mod.maxHenchmen = 4;
            mod.loyaltyBase = 0;
            mod.reactionAdjustment = 0;

        }
        else if (charisma == 10)
        {
            mod.maxHenchmen = 4;
            mod.loyaltyBase = 0;
            mod.reactionAdjustment = 0;

        }
        else if (charisma == 11)
        {
            mod.maxHenchmen = 4;
            mod.loyaltyBase = 0;
            mod.reactionAdjustment = 0;

        }
        else if (charisma == 12)
        {
            mod.maxHenchmen = 5;
            mod.loyaltyBase = 0;
            mod.reactionAdjustment = 0;

        }
        else if (charisma == 13)
        {
            mod.maxHenchmen = 5;
            mod.loyaltyBase = 0;
            mod.reactionAdjustment = 5;

        }
        else if (charisma == 14)
        {
            mod.maxHenchmen = 6;
            mod.loyaltyBase = 5;
            mod.reactionAdjustment = 10;

        }
        else if (charisma == 15)
        {
            mod.maxHenchmen = 7;
            mod.loyaltyBase = 15;
            mod.reactionAdjustment = 15;

        }
        else if (charisma == 16)
        {
            mod.maxHenchmen = 8;
            mod.loyaltyBase = 20;
            mod.reactionAdjustment = 25;

        }
        else if (charisma == 17)
        {
            mod.maxHenchmen = 10;
            mod.loyaltyBase = 30;
            mod.reactionAdjustment = 30;

        }
        else
        {
            mod.maxHenchmen = 15;
            mod.loyaltyBase = 40;
            mod.reactionAdjustment = 35;

        }

        return mod;
    }


    //variables
    public abilityModifiers _abilityModifiers;
    public races race;
    public racialModifiers _racialModifiers;

    public Character():base()
    {

    }

    public Character(Creature.abilities _abilities, classes _class, races _race, Creature.alignments alignment) :base(_abilities, Creature.sizes.medium, alignment)
    {

        bool isFighter = (_class == classes.fighter) || (_class == classes.ranger) || (_class == classes.paladin);
        bool isMagicUser = (_class == classes.magic_user) || (_class == classes.illusionist);
        bool isCleric = (_class == classes.cleric) || (_class == classes.druid);
        bool isTheif = (_class == classes.theif) || (_class == classes.assassin);

        _abilityModifiers.strengthMods = createStrengthModifiers(_abilities.strength, _abilities.strength_over18, isFighter);
        _abilityModifiers.intelligenceMods = createIntelligenceModifiers(_abilities.intelligence, isMagicUser);
        _abilityModifiers.wisdomMods = createWisdomModifiers(_abilities.wisdom, isCleric);
        _abilityModifiers.dexterityMods = createDexterityModifiers(_abilities.dexterity, isTheif);
        _abilityModifiers.constitutionModifiers = createConstitutionModifiers(_abilities.constitution, isFighter);
        _abilityModifiers.charismaMods = createCharismaModifiers(_abilities.charisma);

        race = _race;
    }

    public void createCharacter(Creature.abilities _abilities, classes _class, races _race, Creature.alignments alignment)
    {
        base.createCreature(_abilities, Creature.sizes.medium, alignment);


        bool isFighter = (_class == classes.fighter) || (_class == classes.ranger) || (_class == classes.paladin);
        bool isMagicUser = (_class == classes.magic_user) || (_class == classes.illusionist);
        bool isCleric = (_class == classes.cleric) || (_class == classes.druid);
        bool isTheif = (_class == classes.theif) || (_class == classes.assassin);

        _abilityModifiers.strengthMods = createStrengthModifiers(_abilities.strength, _abilities.strength_over18, isFighter);
        _abilityModifiers.intelligenceMods = createIntelligenceModifiers(_abilities.intelligence, isMagicUser);
        _abilityModifiers.wisdomMods = createWisdomModifiers(_abilities.wisdom, isCleric);
        _abilityModifiers.dexterityMods = createDexterityModifiers(_abilities.dexterity, isTheif);
        _abilityModifiers.constitutionModifiers = createConstitutionModifiers(_abilities.constitution, isFighter);
        _abilityModifiers.charismaMods = createCharismaModifiers(_abilities.charisma);

        race = _race;
    }

    public Creature.abilities getAbilities() 
    {
        return base._abilities;
    }

}
