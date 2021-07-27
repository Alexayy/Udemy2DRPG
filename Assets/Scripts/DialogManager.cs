using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;

    public int currentLine;

    public static DialogManager instance;

    private bool justStarted;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogueLines.Length)
                    {
                        dialogueBox.SetActive(false);
                        GameManager.instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();
                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogueLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        justStarted = true;
        
        nameBox.SetActive(isPerson);

        GameManager.instance.dialogActive = true;
    }

    public void CheckIfName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}