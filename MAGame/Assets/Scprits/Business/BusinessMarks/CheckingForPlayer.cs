using UnityEngine;

public class CheckingForPlayer : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private MarkUsing _information;
    [SerializeField] private FreezePlayer _freezePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _information.UpdateInformation();
            _animator.SetBool("HasArrived", true);
            _freezePlayer.ChangeConfiguration(false);
        }
    }

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _animator.SetBool("HasArrived", false);
        _freezePlayer.ChangeConfiguration(true);
    }
}
