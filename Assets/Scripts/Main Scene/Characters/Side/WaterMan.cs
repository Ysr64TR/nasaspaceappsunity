using UnityEngine;

public class WaterMan : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public void Interact()
    {
        DialogueManager.instance.InitiateDialogue(dialogue);
    }

    public void OnTouchingPlayer()
    {

    }

    public void OnNotTouchingPlayer()
    {

    }
}
