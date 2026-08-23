using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    public string text;
}

public class DialogueController : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameText;

    public DialogueLine[] lines;

    int index = 0;
    bool isTalking = false;

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        index = 0;
        isTalking = true;
        ShowLine();
    }

    void Update()
    {
        if (!isTalking) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            index++;

            if (index < lines.Length)
            {
                ShowLine();
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void ShowLine()
    {
        nameText.text = lines[index].speaker;
        dialogueText.text = lines[index].text;
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isTalking = false;
    }
}