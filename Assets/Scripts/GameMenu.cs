using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu;
    public GameObject[] windows;
    
    private CharacterStats[] _characterStats;

    public Text[] nameText, hpText, mpText, lvlText, expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;

    public GameObject[] statusButtons;

    public ItemButton[] itemButtons;

    public Text statusName,
        statusHP,
        statusMP,
        statusStrength,
        statusDefence,
        statusWeaponEquipped,
        statusWeaponPower,
        statusArmorEquipped,
        statusArmorPower,
        statusExp;

    public Image statusImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (theMenu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateMainStats()
    {
        _characterStats = GameManager.instance.playerStats;

        for (int i = 0; i < _characterStats.Length; i++)
        {
            if (_characterStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                nameText[i].text = _characterStats[i].charName;
                hpText[i].text = "HP: " + _characterStats[i].currentHP + " / " + _characterStats[i].maxHP;
                mpText[i].text = "MP: " + _characterStats[i].currentMP + " / " + _characterStats[i].maxMP;
                lvlText[i].text = "Lvl: " + _characterStats[i].playerLevel;
                expText[i].text = "" + _characterStats[i].currentEXP + " / " +
                                  _characterStats[i].expToNextLevel[_characterStats[i].playerLevel];
                expSlider[i].maxValue = _characterStats[i].expToNextLevel[_characterStats[i].playerLevel];
                expSlider[i].value = _characterStats[i].currentEXP;
                charImage[i].sprite = _characterStats[i].characterImage;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowId)
    {
        UpdateMainStats();
        
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowId)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        
        theMenu.SetActive(false);

        GameManager.instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStats();
        
        // Update information that is shown
        StatusCharacter(0);

        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(_characterStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = _characterStats[i].charName;
        }
    }

    public void StatusCharacter(int selected)
    {
        statusName.text = _characterStats[selected].charName;
        statusHP.text = $"{_characterStats[selected].currentHP} / {_characterStats[selected].maxHP}";
        statusMP.text = $"{_characterStats[selected].currentMP} / {_characterStats[selected].maxMP}";
        statusStrength.text = $"{_characterStats[selected].strength}";
        statusDefence.text = $"{_characterStats[selected].defence}";
        
        if (_characterStats[selected].equippednWpn != "")
            statusWeaponEquipped.text = _characterStats[selected].equippednWpn;
        
        statusWeaponPower.text = _characterStats[selected].weaponPower.ToString();
        
        if (_characterStats[selected].equippenItm != "")
            statusArmorPower.text = _characterStats[selected].equippenItm;
        
        statusArmorPower.text = _characterStats[selected].armorPower.ToString();
        statusExp.text = ( _characterStats[selected].expToNextLevel[_characterStats[selected].playerLevel] -
                          _characterStats[selected].currentEXP ).ToString();
        statusImage.sprite = _characterStats[selected].characterImage;
    }

    public void ShowItems()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;
 
            if (GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amount.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amount.text = "";
            }
        }
    }
}
