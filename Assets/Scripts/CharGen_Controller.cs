using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharGen_Controller : MonoBehaviour
{
    public GameObject Panel_Char;
    public GameObject RaceDropdown;
    public GameObject AlignmentDropdown;
    public GameObject ClassDropdown;
    public GameObject PlayerName;

    public GameObject Roll1;
    public GameObject Roll2;
    public GameObject Roll3;
    public GameObject Roll4;
    public GameObject Roll5;

    public GameObject Stat1;
    public GameObject Stat2;
    public GameObject Stat3;
    public GameObject Stat4;
    public GameObject Stat5;
    public GameObject Stat6;

    public GameObject StrengthPanel;
    public GameObject ConstitutionPanel;
    public GameObject CharismaPanel;
    public GameObject WisdomPanel;
    public GameObject IntelligencePanel;
    public GameObject DexterityPanel;

    public GameObject JsonOutput;

    public GameObject ArmorClassSlider;
    public GameObject SpeedWalkingSlider;
    public GameObject SpeedRunningSlider;
    public GameObject HeightJumpingSlider;
    public GameObject CurrHitPtsSlider;
    public GameObject MaxHitPtsSlider;
    public GameObject MaxXPSlider;
    public GameObject CurrentXPSlider;
    public GameObject ModifierSlider;

    public GameObject StrengthModText;
    public GameObject ConstitutionModText;
    public GameObject CharismaModText;
    public GameObject WisdomModText;
    public GameObject IntelligenceModText;
    public GameObject DexterityModText;

    public GameObject MakeJsonButton;
    public GameObject BackButton; 

    private int roll1 = 0;
    private int roll2 = 0;
    private int roll3 = 0;
    private int roll4 = 0;
    private int roll5 = 0;
    private int[] top3 = new int[3];
    private int[] stat = new int[6];
    private int statCount = 0;

    public List<string> Races = new List<string>
    {
        "Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling"
    };

    public List<string> AlignOptions = new List<string>
    {
        "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral",
        "Lawful Evil", "Neutral Evil", "Chaotic Evil"
    };

    public List<string> Classes = new List<string>
    {
        "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk","Paladin", "Ranger",
        "Sorcerer", "Warlock", "Wizard"
    };

    public void Awake()
    {
        Panel_Char = GameObject.Find("myPanel");
        Panel_Char.SetActive(true);

        PlayerName = GameObject.Find("PlayerNameInputField");

        MakeJsonButton = GameObject.Find("MakeJsonButton");
        BackButton = GameObject.Find("BackButton");

        Roll1 = GameObject.Find("Roll1Text");
        Roll2 = GameObject.Find("Roll2Text");
        Roll3 = GameObject.Find("Roll3Text");
        Roll4 = GameObject.Find("Roll4Text");
        Roll5 = GameObject.Find("Roll5Text");

        Stat1 = GameObject.Find("Stat1");
        Stat2 = GameObject.Find("Stat2");
        Stat3 = GameObject.Find("Stat3");
        Stat4 = GameObject.Find("Stat4");
        Stat5 = GameObject.Find("Stat5");
        Stat6 = GameObject.Find("Stat6");

        ArmorClassSlider = GameObject.Find("ArmorClassSlider");
        SpeedWalkingSlider = GameObject.Find("SpeedWalkingSlider");
        SpeedRunningSlider = GameObject.Find("SpeedRunningSlider");
        HeightJumpingSlider = GameObject.Find("HeightJumpingSlider");
        CurrHitPtsSlider = GameObject.Find("CurrHPSlider");
        MaxHitPtsSlider = GameObject.Find("MaxHPSlider");
        MaxXPSlider = GameObject.Find("MaxXPSlider");
        CurrentXPSlider = GameObject.Find("CurrXPSlider");
        ModifierSlider = GameObject.Find("ModifierSlider");

        StrengthPanel = GameObject.Find("StrengthPanel");
        ConstitutionPanel = GameObject.Find("ConstitutionPanel");
        CharismaPanel = GameObject.Find("CharismaPanel");
        WisdomPanel = GameObject.Find("WisdomPanel");
        IntelligencePanel = GameObject.Find("IntelligencePanel");
        DexterityPanel = GameObject.Find("DexterityPanel");

        StrengthModText = GameObject.Find("StrengthModText");
        ConstitutionModText = GameObject.Find("ConstitutionModText");
        CharismaModText = GameObject.Find("CharismaModText");
        WisdomModText = GameObject.Find("WisdomModText");
        IntelligenceModText = GameObject.Find("IntelligenceModText");
        DexterityModText = GameObject.Find("DexterityModText");

        JsonOutput = GameObject.Find("JsonInputField");

        //UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setRace("Dragonborn");
        //UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setClass("Barbarian");
        //UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setAlignment("Lawful Good");

        RaceDropdown = GameObject.Find("RaceDropdown");
        RaceDropdown.GetComponent<Dropdown>().ClearOptions();
        RaceDropdown.GetComponent<Dropdown>().AddOptions(Races);

        AlignmentDropdown = GameObject.Find("AlignmentDropdown");
        AlignmentDropdown.GetComponent<Dropdown>().ClearOptions();
        AlignmentDropdown.GetComponent<Dropdown>().AddOptions(AlignOptions);

        ClassDropdown = GameObject.Find("ClassDropdown");
        ClassDropdown.GetComponent<Dropdown>().ClearOptions();
        ClassDropdown.GetComponent<Dropdown>().AddOptions(Classes);
    }

    public void GoBack()
    {
        UI_Controller.Instance.Back();
    }

    public void MakeJson()
    {
        SetSlotStrength();
        SetSlotConstitution();
        SetSlotCharisma();
        SetSlotWisdom();
        SetSlotIntelligence();
        SetSlotDexterity();

        JsonOutput.GetComponent<InputField>().text = UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().SaveToString();
    }

    public void SetSlotStrength()
    {
        Image stat = StrengthPanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Strength", int.Parse(number));
        }
    }

    public void SetSlotConstitution()
    {
        Image stat = ConstitutionPanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Constitution", int.Parse(number));

        }
    }

    public void SetSlotCharisma()
    {
        Image stat = CharismaPanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Charisma", int.Parse(number));

        }
    }

    public void SetSlotWisdom()
    {
        Image stat = WisdomPanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Wisdom", int.Parse(number));

        }
    }

    public void SetSlotIntelligence()
    {
        Image stat = IntelligencePanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Intelligence", int.Parse(number));

        }
    }

    public void SetSlotDexterity()
    {
        Image stat = DexterityPanel.GetComponentInChildren(typeof(Image)) as Image;

        if ((stat.GetComponentInChildren(typeof(Text)) as Text) != null)
        {
            Text txt = stat.GetComponentInChildren(typeof(Text)) as Text;
            string number = txt.text;
            AbilityOnValueChanged("Dexterity", int.Parse(number));

        }
    }

    public void PlayerNameOnEndEdit()
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setPlayerName(PlayerName.GetComponent<InputField>().text);
    }

    private void RollHelper(int roll)
    {
        if (roll > top3[2])
        {
            if (roll > top3[1])
            {
                if (roll > top3[0])
                {
                    top3[2] = top3[1];
                    top3[1] = top3[0];
                    top3[0] = roll;
                }
                else
                {
                    top3[2] = top3[1];
                    top3[1] = roll;
                }
            }
            else
            {
                top3[2] = roll;
            }
        }
    }

    public void RollCharacter()
    {
        if (roll5 != 0)
        {
            roll1 = 0;
            Roll1.GetComponent<Text>().text = roll1.ToString();
            roll2 = 0;
            Roll2.GetComponent<Text>().text = roll2.ToString();
            roll3 = 0;
            Roll3.GetComponent<Text>().text = roll3.ToString();
            roll4 = 0;
            Roll4.GetComponent<Text>().text = roll4.ToString();
            roll5 = 0;
            Roll5.GetComponent<Text>().text = roll5.ToString();
            top3[0] = 0;
            top3[1] = 0;
            top3[2] = 0;
            statCount++;
        }

        if (statCount < 6)
        {
            if (roll1 == 0)
            {
                roll1 = Random.Range(1, 7);
                Roll1.GetComponent<Text>().text = roll1.ToString();
                top3[0] = roll1;
            }
            else
                       if (roll2 == 0)
            {
                roll2 = Random.Range(1, 7);
                Roll2.GetComponent<Text>().text = roll2.ToString();
                RollHelper(roll2);
            }
            else
                           if (roll3 == 0)
            {
                roll3 = Random.Range(1, 7);
                Roll3.GetComponent<Text>().text = roll3.ToString();
                RollHelper(roll3);
            }
            else
                               if (roll4 == 0)
            {
                roll4 = Random.Range(1, 7);
                Roll4.GetComponent<Text>().text = roll4.ToString();
                RollHelper(roll4);
            }
            else
                                   if (roll5 == 0)
            {
                roll5 = Random.Range(1, 7);
                Roll5.GetComponent<Text>().text = roll5.ToString();
                RollHelper(roll5);
                stat[statCount] = (top3[2] + top3[1] + top3[0]);
                switch (statCount)
                {
                    case 0:
                        Stat1.GetComponentInChildren<Text>().text = stat[0].ToString();
                        break;
                    case 1:
                        Stat2.GetComponentInChildren<Text>().text = stat[1].ToString();
                        break;
                    case 2:
                        Stat3.GetComponentInChildren<Text>().text = stat[2].ToString();
                        break;
                    case 3:
                        Stat4.GetComponentInChildren<Text>().text = stat[3].ToString();
                        break;
                    case 4:
                        Stat5.GetComponentInChildren<Text>().text = stat[4].ToString();
                        break;
                    case 5:
                        Stat6.GetComponentInChildren<Text>().text = stat[5].ToString();
                        break;
                    default:
                        Debug.Log("Error in PlayerState/setAbilities()/switchCase");
                        break;
                }
            }
        }


    }

    public void CurrentXPOnValueChange()
    {
        int curr = (int)(CurrentXPSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setCurrXP(curr);
        Text value = CurrentXPSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = curr.ToString();
    }

    public void MaxXPOnValueChange()
    {
        int max = (int)(MaxXPSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setMaxXP(max);
        Text value = MaxXPSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = max.ToString();
    }

    public void CurrHitPtsOnValueChange()
    {
        int curr = (int)(CurrHitPtsSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setCurrHitPts(curr);
        Text value = CurrHitPtsSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = curr.ToString();
    }

    public void MaxHitPtsOnValueChange()
    {
        int max = (int)(MaxHitPtsSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setMaxHitPts(max);
        Text value = MaxHitPtsSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = max.ToString();
    }

    public void ArmorClassOnValueChange()
    {
        int ac = (int)(ArmorClassSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setArmorClass(ac);
        Text value = ArmorClassSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = ac.ToString();
    }

    public void SpeedWalkingOnValueChange()
    {
        int sw = (int)(SpeedWalkingSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setSpeedWalking(sw);
        Text value = SpeedWalkingSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = sw.ToString();
    }

    public void SpeedRunningOnValueChange()
    {
        int sr = (int)(SpeedRunningSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setSpeedRunning(sr);
        Text value = SpeedRunningSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = sr.ToString();
    }

    public void HeightJumpingOnValueChange()
    {
        int hj = (int)(HeightJumpingSlider.GetComponent<Slider>().value);
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setHeightJumping(hj);
        Text value = HeightJumpingSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = hj.ToString();
    }

    public void ModifiersOnValueChange()
    {
        int mod = (int)(ModifierSlider.GetComponent<Slider>().value);
        changeMods("Strength", mod);
        changeMods("Constitution", mod);
        changeMods("Charisma", mod);
        changeMods("Wisdom", mod);
        changeMods("Intelligence", mod);
        changeMods("Dexterity", mod);
        Text value = ModifierSlider.GetComponent<Slider>().GetComponentInChildren<Text>();
        value.text = mod.ToString();
    }

    /**
     * <b>Summary:</b>  the ability defined by name will have the modifier value
     *                  defined by mod.  CURRENTLY PLAYER CAN ONLY change the 
     *                  ability modifiers as a group, NOT INDIVIDUALLY.
     */
    public void changeMods(string name, int mod)
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setModifiers(name, mod);
        string sign;
        if (mod > 0)
            sign = "+";
        else
            sign = "";
        switch (name)
        {
            case "Strength":
                StrengthModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            case "Constitution":
                ConstitutionModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            case "Charisma":
                CharismaModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            case "Wisdom":
                WisdomModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            case "Intelligence":
                IntelligenceModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            case "Dexterity":
                DexterityModText.GetComponent<Text>().text = sign + mod.ToString();
                break;
            default:
                Debug.Log("Error in UI_Controller/changeMods()/switchCase");
                break;
        }

    }

    public void ClassOnValueChanged()
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setClass(Classes[ClassDropdown.GetComponent<Dropdown>().value]);
    }

    public void AlignOnValueChanged()
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setAlignment(AlignOptions[AlignmentDropdown.GetComponent<Dropdown>().value]);
    }

    public void RaceOnValueChanged()
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setRace(Races[RaceDropdown.GetComponent<Dropdown>().value]);
    }

    public void AbilityOnValueChanged(string str, int num)
    {
        UI_Controller.Instance.myPlayer.GetComponent<PlayerState>().setAbilites(str, num);
    }

}
