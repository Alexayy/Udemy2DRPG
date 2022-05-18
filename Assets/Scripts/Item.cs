using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectSTR;

    [Header("Weapon/Armor Details")]
    public int weaponSTR; 
    public int armorSTR;

    public void Use(int charToUseOn)
    {
        CharacterStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += amountToChange;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }
                
            if (affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if (affectSTR)
            {
                selectedChar.strength += amountToChange;
            }
        }

        if (isWeapon)
        {
            if (!string.IsNullOrEmpty(selectedChar.equippednWpn))
            {
                GameManager.instance.AddItem(selectedChar.equippednWpn);
            }

            selectedChar.equippednWpn = itemName;
            selectedChar.weaponPower = weaponSTR;
        }

        if (isArmor)
        {
            if (!string.IsNullOrEmpty(selectedChar.equippenArm))
            {
                GameManager.instance.AddItem(selectedChar.equippenArm);
            }

            selectedChar.equippenArm = itemName;
            selectedChar.armorPower = armorSTR;
        }
        
        GameManager.instance.RemoveItem(itemName);
    }
}
