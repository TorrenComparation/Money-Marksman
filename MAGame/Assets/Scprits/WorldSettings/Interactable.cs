using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] protected ItemConfig itemConfig;
    [SerializeField] protected float _pickUpRange = 5;
    protected GameObject subject;
    private bool hasInteractable = false;

    public abstract void Interact(GameObject subject);

    private void OnEnable()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
    }
    protected virtual void Update()
    {

    }

    public void OnHoverEnter()
    {
        outline.OutlineWidth = 2;
    }
    public void OnHoverExit()
    {
        outline.OutlineWidth = 0;
    }
}
