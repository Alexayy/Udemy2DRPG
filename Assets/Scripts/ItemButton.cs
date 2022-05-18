using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amount;
    public int buttonValue;

    public void Press()
    {
        if (!string.IsNullOrEmpty(GameManager.instance.itemsHeld[buttonValue]))
        {
            GameMenu.Instance.SelectItem(GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[buttonValue]));
        }
    }
}
