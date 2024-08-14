using TMPro;
using UnityEngine;

public class RemoveItems : Item
{
    [SerializeField] private MinigamesLoader minigamesLoader;

    private Interactable previousInteractable;
    private Interactable interactable;
    private TrashbinClear trashbinIntraction;

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
            if (MinigamesLoader.isMinigamePlaying && hit.collider.CompareTag("Trash"))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                if (trashbinIntraction == null)
                {
                    trashbinIntraction = hit.collider.GetComponent<TrashbinClear>();
                }

                trashbinIntraction.UpdateText(itemConfig);

                if (isLoocking && Input.GetKeyDown(KeyCode.E))
                {
                    UpdateConfig();
                }

                 if (Vector3.Distance(trashbinIntraction.transform.position, gameObject.transform.position) > 4)
                {
                    interactable = null;
                }
                
            }
            else
            {
                interactable = null;
            }
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
            trashbinIntraction.ClearText();
            previousInteractable = null;
            isLoocking = false;
        }
    }


    private void UpdateConfig()
    {
        itemConfig.itemsCleared += itemConfig.items;
        itemConfig.items = 0;
        if (itemConfig.itemsInLevel == itemConfig.itemsCleared)
        {
            trashbinIntraction = null;
            minigamesLoader.EndedMinigame();
        }
    }
}

