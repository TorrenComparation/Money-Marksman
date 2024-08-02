using UnityEngine;

public class PickUpItem : Item
{
    private Interactable previousInteractable;
    private Interactable interactable;

    private bool isLoocking;

    protected override void Update()
    {
        base.Update();

        TryPickUpItem();
    }

    private void TryPickUpItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, _pickUpRange))
        {
            if (hit.collider.CompareTag("Garbage"))
            {
                interactable = hit.collider.GetComponent<Interactable>();

                if (isLoocking && Input.GetKeyDown(KeyCode.E))
                {
                    itemConfig.items += GarbagePickUp(); 
                    hit.collider.gameObject.SetActive(false);

                }
            }
            else
            {
                interactable = null;
            }

            if (interactable != null)
            {
                if (interactable != this && interactable != previousInteractable)
                {
                    previousInteractable = interactable;
                    previousInteractable.OnHoverEnter();
                    isLoocking = true;
                }
            }
            else if (previousInteractable != null)
            {
                previousInteractable.OnHoverExit();
                previousInteractable = null;
                isLoocking = false;
            }
        }
    }
}

