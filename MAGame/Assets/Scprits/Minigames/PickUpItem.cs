using UnityEngine;

public class PickUpItem : Item
{
    [SerializeField] private float _pickUpRange;
    [SerializeField] private LayerMask itemMask;

    private bool isLoocking;

    private Interactable previousInteractable;

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
            var interactable = hit.collider.GetComponent<Interactable>();

            if (isLoocking && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.SetActive(false);
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
