using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    InputAction clickAction;
    public Image speaker;
    public Text text;
    public GameObject textBox;
    public int index;
    public float textSpeed;
    Dialogue currentDialogue;
    public Dialogue exampleDialogue;

    private void Awake()
    {
        clickAction = InputSystem.actions.FindAction("Click");
    }

    private void Start()
    {
        InitiateDialogue(exampleDialogue);
    }

    public void InitiateDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        textBox.SetActive(true);
        text.text = string.Empty;
        index = 0;
        speaker.sprite = dialogue.owner;
        StartCoroutine(TypeLine());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(text.text == currentDialogue.sentences[index])
            {
                // Next Line
                if (index < currentDialogue.sentences.Length - 1)
                {
                    index++;
                    text.text = string.Empty;
                    StartCoroutine(TypeLine());
                }
                else { textBox.SetActive(false); }
            }
            else
            {
                StopAllCoroutines();
                text.text = currentDialogue.sentences[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in currentDialogue.sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
