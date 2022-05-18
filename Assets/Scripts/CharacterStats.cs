using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;

    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int[] mpLevelBonus;
    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;

    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippednWpn;
    public string equippenArm;
    public Sprite characterImage;

    private void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
            if (i % 2 == 0)
                mpLevelBonus[i] = Mathf.FloorToInt(mpLevelBonus[i - 2] * 1.04f);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            AddExp(1500);
        }
    }

    public void AddExp(int exp)
    {
        currentEXP += exp;
        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;
            
                // Determine whether to add to str or def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxMP;

                currentMP += maxMP;
            }
        }

        if (playerLevel >= maxLevel)
            currentEXP = 0;
    }
}
