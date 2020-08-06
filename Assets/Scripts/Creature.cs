using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public struct abilities
    {
        public int strength;
        public int strength_over18;
        public int intelligence;
        public int wisdom;
        public int dexterity;
        public int constitution;
        public int charisma;
    };

    public enum sizes
    {
        small,
        medium,
        large
    };

    public enum alignments
    {
        lawfulGood,
        neutralGood,
        chaoticGood,
        lawfulNeutral,
        trueNeutral,
        chaoticNeutral,
        lawfulEvil,
        neutralEvil,
        chaoticEvil
    };

    public abilities _abilities;
    public sizes size;
    public alignments alignment;

    public Creature()
    {

    }

    public Creature(abilities __abilities, sizes _size, alignments _alignment)
    {
        _abilities = __abilities;
        size = _size;
        alignment = _alignment;
    }

    public void createCreature(abilities __abilities, sizes _size, alignments _alignment)
    {
        _abilities = __abilities;
        size = _size;
        alignment = _alignment;
    }

}
