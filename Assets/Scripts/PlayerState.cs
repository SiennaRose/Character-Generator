using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [System.Serializable]
    public class Abilities
    {
        public int strength = 0;
        public int constitution = 0;
        public int charisma = 0;
        public int wisdom = 0;
        public int intelligence = 0;
        public int dexterity = 0;

        public int strengthMod = 2;
        public int constitutionMod = 2;
        public int charismaMod = 2;
        public int wisdomMod = 2;
        public int intelligenceMod = 2;
        public int dexterityMod = 2; 

    }

    [System.Serializable]
    public class Items
    {
        public string name;
        public GameObject item; 
    }
    
    public string playerName;
    public string race = "Dragonborn";
    public string playerClass = "Barbarian"; 
    public string alignment = "Lawful Good";
    public int speedWalking;
    public int speedRunning;
    public int heightJumping;
    public int currHitPts;
    public int maxHitPts;
    public int currXP;
    public int maxXP;
    public int armorClass;
    public List<Items> items = new List<Items>();
    public Abilities ability = new Abilities();
    public Dictionary<string, int> Ability = new Dictionary<string, int>(0);
    
    

    public void setAbilites(string abili, int num)
    {
        switch(abili)
        {
            case "Strength":
                ability.strength = num;
                Ability.Add("Strength", num);
                break;
            case "Constitution":
                ability.constitution = num;
                Ability.Add("Constitution", num);
                break;
            case "Charisma":
                ability.charisma = num;
                Ability.Add("Charisma", num);
                break;
            case "Wisdom":
                ability.wisdom = num;
                Ability.Add("Wisdom", num);
                break;
            case "Intelligence":
                ability.intelligence = num;
                Ability.Add("Intelligence", num);
                break;
            case "Dexterity":
                ability.dexterity = num;
                Ability.Add("Dexterity", num);
                break;
            default:
                Debug.Log("Error in PlayerState/setAbilities()/switchCase");
                break;
        }
    }

    public void setModifiers(string abili, int num)
    {
        switch (abili)
        {
            case "Strength":
                ability.strengthMod = num;
                break;
            case "Constitution":
                ability.constitutionMod = num;
                break;
            case "Charisma":
                ability.charismaMod = num;
                break;
            case "Wisdom":
                ability.wisdomMod = num;
                break;
            case "Intelligence":
                ability.intelligenceMod = num;
                break;
            case "Dexterity":
                ability.dexterityMod = num;
                break;
            default:
                Debug.Log("Error in PlayerState/setModifiers()/switchCase");
                break;
        }
    }

    public void addItem(string myName, GameObject myItem)
    {
        Items it = new Items();
        it.name = myName;
        it.item = myItem;
        items.Add(it);
    }

    public void setPlayerName(string player)
    {
        playerName = player; 
    }

    public void setRace(string raceType)
    {
        race = raceType;
    }

    public void setAlignment(string align)
    {
        alignment = align;
    }

    public void setClass(string cla)
    {
        playerClass = cla;
    }

    public void setCurrXP(int xp)
    {
        currXP = xp;
    }

    public void setMaxXP(int xp)
    {
        maxXP = xp;
    }

    public void setSpeedWalking(int walk)
    {
        speedWalking = walk;
    }

    public void setSpeedRunning(int run)
    {
        speedRunning = run; 
    }

    public void setHeightJumping(int height)
    {
        heightJumping = height;
    }

    public void setCurrHitPts(int curr)
    {
        currHitPts = curr; 
    }

    public void setMaxHitPts(int max)
    {
        maxHitPts = max; 
    }

    public void setArmorClass(int armor)
    {
        armorClass = armor;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this); 
    }
}
