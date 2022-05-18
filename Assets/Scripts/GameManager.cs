using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CharacterStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingScenes;

    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingScenes)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     AddItem("Iron Armor");
        //     AddItem("ASDSAD");
        //     
        //     RemoveItem("Iron Sword");
        //     RemoveItem("Iron Armor");
        //     RemoveItem("sdasd");
        // }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }

        return null;
    }

    /**
     * What the fuck
     */
    public void SortItems()
    {
        bool status = true;
        while (status)
        {
            status = false;
            for (int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if (string.IsNullOrEmpty(itemsHeld[i]))
                {
                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";
                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;

                    if (itemsHeld[i] != "")
                    {
                        status = true;
                    }
                }
            }
        }
    }

    public void AddItem(string itemToAdd)
    {
        int newItemPos = 0;
        bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (string.IsNullOrEmpty(itemsHeld[i]) || itemsHeld[i] == itemToAdd)
            {
                newItemPos = i;
                i = itemsHeld.Length;
                foundSpace = true;
            }
        }

        if (foundSpace)
        {
            bool itemExists = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == itemToAdd)
                {
                    itemExists = true;
                    i = referenceItems.Length;
                }
            }

            if (itemExists)
            {
                itemsHeld[newItemPos] = itemToAdd;
                numberOfItems[newItemPos]++;
            }
            else
            {
                Debug.LogError("What the fuck is this shit: " + itemToAdd);
            }
        }

        GameMenu.Instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPos = 0;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPos = i;
                i = itemsHeld.Length;
            }
        }

        if (foundItem)
        {
            numberOfItems[itemPos]--;
            if (numberOfItems[itemPos] <= 0)
            {
                itemsHeld[itemPos] = "";
            }

            GameMenu.Instance.ShowItems();
        }
        else
        {
            Debug.LogError("WHAT THE FUCK IS THIS TUTORIAL??? " + itemToRemove);
        }
    }
}