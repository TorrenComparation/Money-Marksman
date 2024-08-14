using System.Collections;
using UnityEngine;
public class CheckingForPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject panel;
    [SerializeField] private FreezePlayer freezePlayer;

    private void OnValidate()
    {
        if (animator == null)
            Debug.LogWarning("Animator is not assigned.", this);

        if (panel == null)
            Debug.LogWarning("Panel is not assigned.", this);

        if (freezePlayer == null)
            Debug.LogWarning("FreezePlayer is not assigned.", this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        SetCursorState(CursorLockMode.None, true);
        panel.SetActive(true);
        animator.SetBool("HasArrived", true);
        freezePlayer.ChangeConfiguration(false);  
    }

    public void ClosePanel()
    {
        SetCursorState(CursorLockMode.Locked, false);
        animator.SetBool("HasArrived", false);
        StartCoroutine(DisablePanelCoroutine());
        freezePlayer.ChangeConfiguration(true);  
    }

    private void SetCursorState(CursorLockMode lockMode, bool isVisible)
    {
        Cursor.lockState = lockMode;
        Cursor.visible = isVisible;
    }

    private IEnumerator DisablePanelCoroutine()
    {
        yield return new WaitForSeconds(0.8f);
        panel.SetActive(false);
    }
}
