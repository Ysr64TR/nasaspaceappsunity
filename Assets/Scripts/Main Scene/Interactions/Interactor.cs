using UnityEngine;

interface IInteractable
{
    void Interact();
    void OnTouchingPlayer();
    void OnNotTouchingPlayer();
}
public class Interactor : MonoBehaviour
{
    private IInteractable currentInteractible;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractible != null)
        {
            currentInteractible.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactible = collision.GetComponent<IInteractable>();
        if(interactible != null )
        {
            currentInteractible = interactible;
            currentInteractible.OnTouchingPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactible = collision.GetComponent<IInteractable>();
        if (interactible != null && interactible == currentInteractible)
        {
            currentInteractible.OnNotTouchingPlayer();
            currentInteractible = null;
        }
    }
}
