using TMPro;
using UnityEngine;

public class RemoveItems : Item
{
    [SerializeField] private MinigamesLoader minigamesLoader;
    [SerializeField] private TextMeshProUGUI messageText;
    
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
            if (MinigamesLoader.isMinigamePlaying && hit.collider.CompareTag("Trash"))
            {
                interactable = hit.collider.GetComponent<Interactable>();
                messageText.text = $"Remain trash: {itemConfig.itemsInLevel - itemConfig.itemsCleared} \n\n Press E to take out the trash";

                if (isLoocking && Input.GetKeyDown(KeyCode.E))
                {
                    UpdateConfig();
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
                    messageText.gameObject.SetActive(true);
                    isLoocking = true;
                }
            }
            else if (previousInteractable != null)
            {
                previousInteractable.OnHoverExit();
                messageText.gameObject.SetActive(false);
                previousInteractable = null;
                isLoocking = false;
            }
        }
    }

    private void UpdateConfig()
    {
        itemConfig.itemsCleared += itemConfig.items;
        itemConfig.items = 0;

        if(itemConfig.itemsInLevel == itemConfig.itemsCleared)
        {
            minigamesLoader.EndedMinigame();
        }
    }
}
