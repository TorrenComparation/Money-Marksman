using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    public float interactableRadius = 2;
    protected GameObject subject;
    [SerializeField] private Outline outline;
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
