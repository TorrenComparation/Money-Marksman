using UnityEngine;

public class RemoveItems : Item
{
    [SerializeField] private float _pickUpRange;
    [SerializeField] private int collectedItems;
    [SerializeField] private ItemConfig itemConfig;
    private bool isLoocking;

    private Interactable previousInteractable;
    private Interactable interactable;

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
            if (hit.collider.CompareTag("Trash"))
            {
                interactable = hit.collider.GetComponent<Interactable>();

                if (isLoocking && Input.GetKeyDown(KeyCode.E))
                {
                    itemConfig.itemsCleared += itemConfig.items;
                    itemConfig.items = 0;
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
                previousInteractable = null;
                isLoocking = false;
            }
        }
    }
}
