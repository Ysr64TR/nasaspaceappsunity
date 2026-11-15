using UnityEngine;

public class WaterMan : MonoBehaviour, IInteractable
{
    public GameObject interactSprite;

    public Dialogue dialogue;
    public void Interact()
    {
        DialogueManager.instance.InitiateDialogue(dialogue);
    }

    public void OnTouchingPlayer()
    {
        interactSprite.SetActive(true);
    }

    public void OnNotTouchingPlayer()
    {
        interactSprite.SetActive(false);
    }
}
