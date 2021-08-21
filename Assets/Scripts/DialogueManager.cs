using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;

    public int currentLine;

    private bool justStarted;
    public static DialogueManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(dialogueBox.activeInHierarchy)
        {

            if(Input.GetButtonUp("Fire1"))
            {
                if(!justStarted)
                {
                    currentLine++;

                    if(currentLine >= dialogueLines.Length)
                    {
                        dialogueBox.SetActive(false);

                        PlayerController.instance.canMove = true;
                    } else
                    {
                        dialogueText.text = dialogueLines[currentLine];
                    }
                } else
                {
                    justStarted = false;
                }
            }

        }
    }

    public void ShowDialogue(string[] newLines)
    {
        dialogueLines = newLines;

        currentLine = 0;

        dialogueText.text = dialogueLines[0];
        dialogueBox.SetActive(true);
        justStarted = true;
        PlayerController.instance.canMove = false;
    }
}
